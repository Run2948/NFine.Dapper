/*******************************************************************************
    * Copyright 2018 Roc.Framework 版权所有
    * Author: Roc Qing
    * Description: Roc 快速开发平台
    * Date：2018-09-12
    *********************************************************************************/
using System.Configuration;
using System.Web;

namespace Roc.Uility
{
    public sealed class Licence
    {
        public static bool IsLicence(string key)
        {
            string host = HttpContext.Current.Request.Url.Host.ToLower();
            if (host.Equals("localhost"))
                return true;
            string licence = ConfigurationManager.AppSettings[GetKey()];
            if (licence != null && licence == Md5.md5(key, 32))
                return true;

            return false;
        }
        public static string GetLicence()
        {
            string key = GetKey();
            var licence = Configs.GetValue(key);
            if (string.IsNullOrEmpty(licence))
            {
                licence = Common.GuId();
                Configs.SetValue(key, licence);
            }
            return Md5.md5(licence, 32);
        }

        private static string GetKey()
        {
            return "LicenceKey";
        }
    }
}
