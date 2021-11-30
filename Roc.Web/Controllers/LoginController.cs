/*******************************************************************************
    * Copyright 2018 Roc.Framework 版权所有
    * Author: Roc Qing
    * Description: Roc 快速开发平台
    * Date：2018-09-12
    *********************************************************************************/
using Roc.Model.Entity.SystemSecurity;
using Roc.Application.SystemSecurity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Roc.Model.Entity.SystemManage;
using Roc.Application.SystemManage;
using Roc.Uility;
using Roc.Application;

namespace Roc.Web.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public virtual ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetAuthCode()
        {
            return File(new VerifyCode().GetVerifyCode(), @"image/Gif");
        }
        [HttpGet]
        public ActionResult OutLogin()
        {
            new LogApp().WriteDbLog(new LogEntity
            {
                F_ModuleName = "系统登录",
                F_Type = DbLogType.Exit.ToString(),
                F_Account = OperatorProvider.Provider.GetCurrent().UserCode,
                F_NickName = OperatorProvider.Provider.GetCurrent().UserName,
                F_Result = true,
                F_Description = "安全退出系统",
            });
            Session.Abandon();
            Session.Clear();
            OperatorProvider.Provider.RemoveCurrent();
            return RedirectToAction("Index", "Login");
        }
        [HttpPost]
        [HandlerAjaxOnly]
        public ActionResult CheckLogin(string username, string password, string code)
        {
            LogEntity logEntity = new LogEntity
            {
                F_ModuleName = "系统登录",
                F_Type = DbLogType.Login.ToString()
            };
            try
            {
                if (Session["nfine_session_verifycode"].IsEmpty() || Md5.md5(code.ToLower(), 16) != Session["nfine_session_verifycode"].ToString())
                {
                    throw new Exception("验证码错误，请重新输入");
                }

                UserEntity userEntity = new UserApp().CheckLogin(username, password);
                if (userEntity != null)
                {
                    OperatorModel operatorModel = new OperatorModel
                    {
                        UserId = userEntity.F_Id,
                        UserCode = userEntity.F_Account,
                        UserName = userEntity.F_RealName,
                        CompanyId = userEntity.F_OrganizeId,
                        DepartmentId = userEntity.F_DepartmentId,
                        RoleId = userEntity.F_RoleId,
                        LoginIPAddress = Net.Ip,
                        LoginIPAddressName = string.Empty, //Net.GetLocation(operatorModel.LoginIPAddress);
                        LoginTime = DateTime.Now,
                        LoginToken = DESEncrypt.Encrypt(Guid.NewGuid().ToString())
                    };
                    operatorModel.IsSystem = userEntity.F_Account == "admin" ? true : false;
                    OperatorProvider.Provider.AddCurrent(operatorModel);
                    logEntity.F_Account = userEntity.F_Account;
                    logEntity.F_NickName = userEntity.F_RealName;
                    logEntity.F_Result = true;
                    logEntity.F_Description = "登录成功";
                    new LogApp().WriteDbLog(logEntity);
                }
                return Content(new AjaxResult { state = ResultType.success.ToString(), message = "登录成功。" }.ToJson());
            }
            catch (Exception ex)
            {
                logEntity.F_Account = username;
                logEntity.F_NickName = username;
                logEntity.F_Result = false;
                logEntity.F_Description = "登录失败，" + ex.Message;
                new LogApp().WriteDbLog(logEntity);
                return Content(new AjaxResult { state = ResultType.error.ToString(), message = ex.Message }.ToJson());
            }
        }
    }
}
