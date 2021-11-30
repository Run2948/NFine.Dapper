/*******************************************************************************
    * Copyright 2018 Roc.Framework 版权所有
    * Author: Roc Qing
    * Description: Roc 快速开发平台
    * Date：2018-09-12
    *********************************************************************************/
using System.Web.Mvc;
using NFine.Uility;

namespace NFine.Web.Areas.ExampleManage.Controllers
{
    public class SendMailController : ControllerBase
    {
        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult SendMail(string account, string title, string content)
        {
            MailHelper mail = new MailHelper
            {
                MailServer = Configs.GetValue("MailHost"),
                MailUserName = Configs.GetValue("MailUserName"),
                MailPassword = Configs.GetValue("MailPassword"),
                MailName = "NFine.Dapper快速开发平台"
            };
            mail.Send(account, title, content);
            return Success("发送成功。");
        }
    }
}
