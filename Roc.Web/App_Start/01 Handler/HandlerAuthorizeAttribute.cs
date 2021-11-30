/*******************************************************************************
    * Copyright 2018 Roc.Framework 版权所有
    * Author: Roc Qing
    * Description: Roc 快速开发平台
    * Date：2018-09-12
    *********************************************************************************/using Roc.Application.SystemManage;
using Roc.Uility;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Roc.Web
{
    public class HandlerAuthorizeAttribute : ActionFilterAttribute
    {
        public bool Ignore { get; set; }
        public HandlerAuthorizeAttribute(bool ignore = true)
        {
            Ignore = ignore;
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (OperatorProvider.Provider.GetCurrent().IsSystem)
            {
                return;
            }
            if (Ignore == false)
            {
                return;
            }
            if (!this.ActionAuthorize(filterContext))
            {
                StringBuilder sbScript = new StringBuilder();
                sbScript.Append("<script type='text/javascript'>alert('很抱歉！您的权限不足，访问被拒绝！');</script>");
                filterContext.Result = new ContentResult() { Content = sbScript.ToString() };
                return;
            }
        }
        private bool ActionAuthorize(ActionExecutingContext filterContext)
        {
            var operatorProvider = OperatorProvider.Provider.GetCurrent();
            var roleId = operatorProvider.RoleId;
            var moduleId = WebHelper.GetCookie("nfine_currentmoduleid");
            var action = HttpContext.Current.Request.ServerVariables["SCRIPT_NAME"].ToString();
            return new RoleAuthorizeApp().ActionValidate(roleId, moduleId, action);
        }
    }
}