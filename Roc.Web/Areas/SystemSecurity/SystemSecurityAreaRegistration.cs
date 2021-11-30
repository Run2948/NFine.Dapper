/*******************************************************************************
    * Copyright 2018 Roc.Framework 版权所有
    * Author: Roc Qing
    * Description: Roc 快速开发平台
    * Date：2018-09-12
    *********************************************************************************/using System.Web.Mvc;

namespace Roc.Web.Areas.SystemSecurity
{
    public class SystemSecurityAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "SystemSecurity";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                 this.AreaName + "_Default",
                 this.AreaName + "/{controller}/{action}/{id}",
                 new { area = this.AreaName, controller = "Home", action = "Index", id = UrlParameter.Optional },
                 new string[] { "Roc.Web.Areas." + this.AreaName + ".Controllers" }
           );
        }
    }
}
