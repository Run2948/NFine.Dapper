/*******************************************************************************
    * Copyright 2018 Roc.Framework 版权所有
    * Author: Roc Qing
    * Description: Roc 快速开发平台
    * Date：2018-09-12
    *********************************************************************************/
using System;
using Roc.Data;

namespace Roc.Model.Entity.SystemManage
{
    [Table("Sys_UserLogOn")]
    public class UserLogOnEntity
    {
        [Key]
        public string F_Id { get; set; }
        public string F_UserId { get; set; }
        public string F_UserPassword { get; set; }
        public string F_UserSecretkey { get; set; }
        public DateTime? F_AllowStartTime { get; set; }
        public DateTime? F_AllowEndTime { get; set; }
        public DateTime? F_LockStartDate { get; set; }
        public DateTime? F_LockEndDate { get; set; }
        public DateTime? F_FirstVisitTime { get; set; }
        public DateTime? F_PreviousVisitTime { get; set; }
        public DateTime? F_LastVisitTime { get; set; }
        public DateTime? F_ChangePasswordDate { get; set; }
        public bool? F_MultiUserLogin { get; set; }
        public int? F_LogOnCount { get; set; }
        public bool? F_UserOnLine { get; set; }
        public string F_Question { get; set; }
        public string F_AnswerQuestion { get; set; }
        public bool? F_CheckIPAddress { get; set; }
        public string F_Language { get; set; }
        public string F_Theme { get; set; }
    }
}
