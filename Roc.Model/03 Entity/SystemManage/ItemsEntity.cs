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
    [Table("Sys_Items")]
    public class ItemsEntity : IEntity<ItemsEntity>, ICreationAudited, IDeleteAudited, IModificationAudited
    {
        [Key]
        public string F_Id { get; set; }
        public string F_ParentId { get; set; }
        public string F_EnCode { get; set; }
        public string F_FullName { get; set; }
        public bool? F_IsTree { get; set; }
        public int? F_Layers { get; set; }
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
