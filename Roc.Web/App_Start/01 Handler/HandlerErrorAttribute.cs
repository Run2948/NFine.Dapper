/*******************************************************************************
    * Copyright 2018 Roc.Framework 版权所有
    * Author: Roc Qing
    * Description: Roc 快速开发平台
    * Date：2018-09-12
    *********************************************************************************/using Roc.Uility;
using System.Web.Mvc;

namespace Roc.Web
{
    public class HandlerErrorAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);

            //context.ExceptionHandled = true;
            //context.HttpContext.Response.StatusCode = 200;
            //context.Result = new ContentResult { Content = new AjaxResult { state = ResultType.error.ToString(), message = context.Exception.Message }.ToJson() };
        }
        private void WriteLog(ExceptionContext context)
        {
            if (context == null)
                return;
            var log = LogFactory.GetLogger(context.Controller.ToString());
            log.Error(context.Exception);
        }
    }
}