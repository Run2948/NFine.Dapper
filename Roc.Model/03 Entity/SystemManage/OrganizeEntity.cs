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
    [Table("Sys_Organize")]
    public class OrganizeEntity : IEntity<OrganizeEntity>, ICreationAudited, IDeleteAudited, IModificationAudited
    {
        [Key]
        public string F_Id { get; set; }
        public string F_ParentId { get; set; }
        public int? F_Layers { get; set; }
        public string F_EnCode { get; set; }
        public string F_FullName { get; set; }
        public string F_ShortName { get; set; }
        public string F_CategoryId { get; set; }
        public string F_ManagerId { get; set; }
        public string F_TelePhone { get; set; }
        public string F_MobilePhone { get; set; }
        public string F_WeChat { get; set; }
        public string F_Fax { get; set; }
        public string F_Email { get; set; }
        public string F_AreaId { get; set; }
        public string F_Address { get; set; }
        public bool? F_AllowEdit { get; set; }
        public bool? F_AllowDelete { get; set; }
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
