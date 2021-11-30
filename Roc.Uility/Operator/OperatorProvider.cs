/*******************************************************************************
    * Copyright 2018 Roc.Framework 版权所有
    * Author: Roc Qing
    * Description: Roc 快速开发平台
    * Date：2018-09-12
    *********************************************************************************/
namespace Roc.Uility
{
    public class OperatorProvider
    {
        public static OperatorProvider Provider
        {
            get { return new OperatorProvider(); }
        }
        private string LoginUserKey = "roc_login_key";
        private string LoginProvider = Configs.GetValue("LoginProvider");

        public OperatorModel GetCurrent()
        {
            OperatorModel operatorModel = null;
            if (LoginProvider == "Cookie")
            {
                operatorModel = DESEncrypt.Decrypt(WebHelper.GetCookie(LoginUserKey).ToString()).ToObject<OperatorModel>();
            }
            else
            {
                operatorModel = DESEncrypt.Decrypt(WebHelper.GetSession(LoginUserKey).ToString()).ToObject<OperatorModel>();
            }
            if (operatorModel == null) operatorModel = new OperatorModel();
            return operatorModel;
        }
        public void AddCurrent(OperatorModel operatorModel)
        {
            if (LoginProvider == "Cookie")
            {
                WebHelper.WriteCookie(LoginUserKey, DESEncrypt.Encrypt(operatorModel.ToJson()), 60);
            }
            else
            {
                WebHelper.WriteSession(LoginUserKey, DESEncrypt.Encrypt(operatorModel.ToJson()));
            }
            //WebHelper.WriteCookie("nfine_mac", Md5.md5(Net.GetMacByNetworkInterface().ToJson(), 32));
            //WebHelper.WriteCookie("nfine_licence", Licence.GetLicence());
        }
        public void RemoveCurrent()
        {
            if (LoginProvider == "Cookie")
            {
                WebHelper.RemoveCookie(LoginUserKey.Trim());
            }
            else
            {
                WebHelper.RemoveSession(LoginUserKey.Trim());
            }
        }
    }
}
