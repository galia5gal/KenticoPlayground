using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CMS.Base;
using CMS.Membership;
using CMS.EventLog;
using CMS.DataEngine;
using System.Net;
using System.Text;
using System.IO;
using Newtonsoft.Json.Linq;

[WIFAuthenticationHandler]
public partial class CMSModuleLoader
{
    public class WIFAuthenticationHandler : CMSLoaderAttribute
    {
        /// <summary>
        /// The system executes the Init method of the CMSModuleLoader attributes when the application starts.
        /// </summary>
        public override void Init()
        {
            // Assigns a handler to the event
            // This event occurs when users attempt to access a restricted section of Kentico
            //SecurityEvents.AuthenticationRequested.Execute += SignIn_Execute;
            //SecurityEvents.Authenticate.Execute += OnAuthentication;
        }

        // The handler method, which writes the URL, from which the authentication request was made, to the event log
        // You can replace it with your custom code
        private void SignIn_Execute(object sender, AuthenticationRequestEventArgs e)
        {
            // Gets the credentials entered during the authentication

            string message = string.Format("Custom code handled the authentication event on URL: {0}", e.RequestedUrl);
            EventLogProvider.LogInformation("Custom code", "SIGN_IN", message);
        }

        private void OnAuthentication(object sender, AuthenticationEventArgs e)
        {
            // Checks if the user was authenticated by the default system. Only continues if authentication failed.
            if (e.User == null)
            {
                // Object representing the external user
                UserInfo externalUser = null;

                // Gets the credentials entered during the authentication
                string username = SqlHelper.GetSafeQueryString(e.UserName);
                string password = SqlHelper.GetSafeQueryString(e.Password);
                //1. Issue a request to the Identity Provder to get the security token
                var authorizationURL = "https://localhost:9443/oauth2/token";
                var userAttributesURL = "https://localhost:9443/oauth2/userinfo?schema=openid";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(authorizationURL);
                request.Method = "POST";
                request.Headers["Authorization"] = "Basic RU5ZVVF2VHVVUzVoZEpIV1l5b3FTOERWRmo4YTpaWjBJdXJ6X0VNamdZNWlXbkRMWUtwTzNaSE1h";
                request.ContentType = "application/x-www-form-urlencoded";
                string postData = string.Format("grant_type=password&username={0}&password={1}&scope=openid", username, password);
                byte[] bytes = Encoding.UTF8.GetBytes(postData);
                request.ContentLength = bytes.Length;

                Stream requestStream = request.GetRequestStream();
                requestStream.Write(bytes, 0, bytes.Length);

                WebResponse response = request.GetResponse();
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);

                var result = reader.ReadToEnd();
                stream.Dispose();
                reader.Dispose();

                var authorizationObject = JObject.Parse(result);
                if (authorizationObject!=null)
                {
                    var accessToken = authorizationObject["access_token"] != null ? authorizationObject["access_token"].ToString() : string.Empty;
                    if (!string.IsNullOrEmpty(accessToken))
                    {
                        request = (HttpWebRequest)WebRequest.Create(userAttributesURL);
                        request.Method = "GET";
                        request.Headers["Authorization"] = "Bearer " + accessToken;

                        response = request.GetResponse();
                        stream = response.GetResponseStream();
                        reader = new StreamReader(stream);

                        result = reader.ReadToEnd();
                        stream.Dispose();
                        reader.Dispose();
                        var userAttributes = JObject.Parse(result);
                        if (userAttributes != null && userAttributes["sub"]!=null)
                        {
                            externalUser = new UserInfo()
                            {
                                IsExternal = true,
                                UserName = userAttributes["sub"].ToString(),
                                FullName = userAttributes["given_name"].ToString() + " " + userAttributes["family_name"].ToString(),
                                Email = userAttributes["email"].ToString(),
                                FirstName = userAttributes["given_name"].ToString(),
                                LastName = userAttributes["family_name"].ToString(),
                                Enabled = true
                            };
                        }

                    }
                }

                //if (username == password)
                //{
                //    externalUser = new UserInfo()
                //    {
                //        IsExternal = true,
                //        UserName = e.UserName,
                //        FullName = "Marry Jones",
                //        Enabled = true
                //    };
                //}

                //// Path to an XML database file
                //string xmlPath = HttpContext.Current.Server.MapPath("~/userdatabase.xml");

                //// Reads data from the external database
                //DataSet userData = new DataSet();
                //userData.ReadXml(xmlPath);

                //// Authenticates against the external database
                //DataRow[] rows = userData.Tables[0].Select("UserName = '" + username + "' AND Password='" + password + "'");
                //if (rows.Count() > 0)
                //{
                //    // Creates a user record if external authentication is successful
                //    externalUser = new UserInfo()
                //    {
                //        IsExternal = true,
                //        UserName = e.UserName,
                //        FullName = "ExternalUser Fullname",
                //        Enabled = true
                //    };
                //}

                // Passes the object representing the user (or null if external authentication failed)
                e.User = externalUser;
            }
        }
    }
}