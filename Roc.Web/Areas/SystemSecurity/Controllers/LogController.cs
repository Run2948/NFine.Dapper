/*******************************************************************************
    * Copyright 2018 Roc.Framework 版权所有
    * Author: Roc Qing
    * Description: Roc 快速开发平台
    * Date：2018-09-12
    *********************************************************************************/
using Roc.Application.SystemSecurity;
using Roc.Uility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Roc.Web.Areas.SystemSecurity.Controllers
{
    public class LogController : ControllerBase
    {
        private LogApp logApp = new LogApp();

        [HttpGet]
        public ActionResult RemoveLog()
        {
            return View();
        }
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetGridJson(Pagination pagination, string queryJson)
        {
            var data = new
            {
                rows = logApp.GetList(pagination, queryJson),
                total = pagination.total,
                page = pagination.page,
                records = pagination.records
            };
            return Content(data.ToJson());
        }
        [HttpPost]
        [HandlerAjaxOnly]
        [HandlerAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitRemoveLog(string keepTime)
        {
            logApp.RemoveLog(keepTime);
            return Success("清空成功。");
        }
    }
}
