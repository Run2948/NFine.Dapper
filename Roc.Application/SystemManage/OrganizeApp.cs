﻿/*******************************************************************************
    * Copyright 2016 Roc.Framework 版权所有
    * Author: Roc Ching
    * Description: Roc 快速开发平台
    * Date：2016-09-12
    *********************************************************************************/
using Roc.Model.Entity.SystemManage;
using Roc.Model.IRepository.SystemManage;
using Roc.Repository.SystemManage;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Roc.Application.SystemManage
{
    public class OrganizeApp
    {
        private IOrganizeRepository service = new OrganizeRepository();

        public List<OrganizeEntity> GetList()
        {
            return service.GetList().OrderBy(t => t.F_CreatorTime).ToList();
        }
        public OrganizeEntity GetForm(string keyValue)
        {
            return service.Get(m => m.F_Id == keyValue);
        }
        public void DeleteForm(string keyValue)
        {
            if (service.Count(m => m.F_ParentId, m => m.F_ParentId == keyValue) > 0)
            {
                throw new Exception("删除失败！操作的对象包含了下级数据。");
            }
            else
            {
                service.Delete(m => m.F_Id == keyValue);
            }
        }
        public void SubmitForm(OrganizeEntity organizeEntity, string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                organizeEntity.Modify(keyValue);
                service.Update(organizeEntity, m => m.F_Id == keyValue);
            }
            else
            {
                organizeEntity.Create();
                service.Insert(organizeEntity);
            }
        }
    }
}
