using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json.Linq;
using CMS.Membership;
using System.Web.Security;
using CMS.Helpers;

namespace CMSApp.CMSPages
{
    public partial class OpenIdSignInCallback : System.Web.UI.Page
    {
        string userAttributesURL = "https://localhost:9443/oauth2/userinfo?schema=openid";

        protected void Page_Load(object sender, EventArgs e)
        {
            var token = Request.QueryString["id_token"];
            var accessToken = Request.QueryString["access_token"];
            var state = Request.QueryString["state"];
            if (!string.IsNullOrEmpty(accessToken))
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(userAttributesURL);
                request.Method = "GET";
                request.Headers["Authorization"] = "Bearer " + accessToken;

                WebResponse response = request.GetResponse();
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);

                var result = reader.ReadToEnd();
                stream.Dispose();
                reader.Dispose();
                var userAttributes = JObject.Parse(result);
                if (userAttributes != null && userAttributes["sub"] != null)
                {
                    var externalUser = new UserInfo()
                    {
                        IsExternal = true,
                        UserName = userAttributes["sub"].ToString(),
                        FullName = userAttributes["given_name"].ToString() + " " + userAttributes["family_name"].ToString(),
                        Email = userAttributes["email"].ToString(),
                        FirstName = userAttributes["given_name"].ToString(),
                        LastName = userAttributes["family_name"].ToString(),

                        Enabled = true
                    };
                    externalUser.SetValue("UserToken", token);

                    if (externalUser != null)
                    {
                        CMS.Membership.AuthenticationHelper.EnsureExternalUser(externalUser);
                        CMS.Membership.AuthenticationHelper.AuthenticateUser(externalUser.UserName, false);
                        CookieHelper.EnsureResponseCookie(FormsAuthentication.FormsCookieName);
                        Response.Redirect("/");
                    }

                }

            }
            
            
        }
    }
}