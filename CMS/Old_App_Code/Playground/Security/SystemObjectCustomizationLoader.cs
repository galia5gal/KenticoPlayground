using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using CMS.Base;
using CMS.SiteProvider;
using CMS.DataEngine;
using BFM.Data;

[SystemObjectCustomizationLoader]
public partial class CMSModuleLoader
{
    private class SystemObjectCustomizationLoader : CMSLoaderAttribute
    {
        public override void Init()
        {
            // Assigns a handler to the OnLoadRelatedData event of the SiteInfo object type
            CMS.Membership.UserInfo.TYPEINFO.OnLoadRelatedData += UserInfo_OnLoadRelatedData;
        }

        static object UserInfo_OnLoadRelatedData(BaseInfo infoObj)
        {
            UserCustomData userData = new UserCustomData();

            userData.UserToken = string.Empty;
            return userData;
        }
    }
}