using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMSApp.CMSPages
{
    public partial class OpenIdConnectLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //create nonce
            var state = Guid.NewGuid().ToString("N");
            var nonce = Guid.NewGuid().ToString("N");

            var url = "https://localhost:9443/oauth2/authorize" +
                        "?client_id=ffpg7u7fdJsTrrw7426lalpgKcwa" +
                        "&redirect_uri=http://localhost/cmsPages/OpenIdSignInCallback.aspx" +
                        "&response_mode=form_post" +
                        "&response_type=id_token token" +
                        "&scope=openid" +
                        "&state=" + state +
                        "&nonce=" + nonce;

            //SetTempCookie(state, nonce);
            Response.Redirect(url);
        }
    }
}