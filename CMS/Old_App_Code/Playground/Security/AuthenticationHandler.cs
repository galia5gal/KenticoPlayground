using System.Data;

using CMS.Base;
using CMS.Membership;
using CMS.DataEngine;
using System.Web;

[AuthenticationHandler]
public partial class CMSModuleLoader
{
    private class AuthenticationHandler : CMSLoaderAttribute
    {
        /// <summary>
        /// Called automatically when the application starts
        /// </summary>
        public override void Init()
        {
            // Assigns a handler to the SecurityEvents.Authenticate.Execute event
            // This event occurs when users attempt to log in on the website
            //SecurityEvents.Authenticate.Execute += OnAuthentication;
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

                if(username==password)
                {
                    externalUser = new UserInfo()
                    {
                        IsExternal = true,
                        UserName = e.UserName,
                        FullName = "Marry Jones",
                        Enabled = true
                    };
                }

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