/*******************************************************************************
    * Copyright 2018 Roc.Framework 版权所有
    * Author: Roc Qing
    * Description: Roc 快速开发平台
    * Date：2018-09-12
    *********************************************************************************/
using Roc.Application.SystemManage;
using Roc.Uility;
using Roc.Model.Entity.SystemManage;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;

namespace Roc.Web.Controllers
{
    [HandlerLogin]
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Default()
        {
            return View();
        }
        [HttpGet]
        public ActionResult About()
        {
            return View();
        }
    }
}
