﻿/*******************************************************************************
    * Copyright 2016 Roc.Framework 版权所有
    * Author: Roc Ching
    * Description: Roc 快速开发平台
    * Date：2016-09-12
    *********************************************************************************/
using System;
using Roc.Data;

namespace Roc.Model.Entity.SystemManage
{
    [Table("Sys_User")]
    public class UserEntity : IEntity<UserEntity>, ICreationAudited, IDeleteAudited, IModificationAudited
    {
        [Key]
        public string F_Id { get; set; }
        public string F_Account { get; set; }
        public string F_RealName { get; set; }
        public string F_NickName { get; set; }
        public string F_HeadIcon { get; set; }
        public bool? F_Gender { get; set; }
        public DateTime? F_Birthday { get; set; }
        public string F_MobilePhone { get; set; }
        public string F_Email { get; set; }
        public string F_WeChat { get; set; }
        public string F_ManagerId { get; set; }
        public int? F_SecurityLevel { get; set; }
        public string F_Signature { get; set; }
        public string F_OrganizeId { get; set; }
        public string F_DepartmentId { get; set; }
        public string F_RoleId { get; set; }
        public string F_DutyId { get; set; }
        public bool? F_IsAdministrator { get; set; }
        public int? F_SortCode { get; set; }
        public bool? F_DeleteMark { get; set; }
        public bool? F_EnabledMark { get; set; }
        public string F_Description { get; set; }
        public DateTime? F_CreatorTime { get; set; }
        public string F_CreatorUserId { get; set; }
        public DateTime? F_LastModifyTime { get; set; }
        public string F_LastModifyUserId { get; set; }
        public DateTime? F_DeleteTime { get; set; }
        public string F_DeleteUserId { get; set; }
    }
}
