/*******************************************************************************
    * Copyright 2018 Roc.Framework 版权所有
    * Author: Roc Qing
    * Description: Roc 快速开发平台
    * Date：2018-09-12
    *********************************************************************************/
using Roc.Uility;
using Roc.Model.Entity.SystemManage;
using Roc.Model.IRepository.SystemManage;
using Roc.Repository.SystemManage;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Roc.Application.SystemManage
{
    public class ModuleApp
    {
        private IModuleRepository service = new ModuleRepository();

        public List<ModuleEntity> GetList()
        {
            return service.GetList().OrderBy(t => t.F_SortCode).ToList();
        }
        public ModuleEntity GetForm(string keyValue)
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
        public void SubmitForm(ModuleEntity moduleEntity, string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                moduleEntity.Modify(keyValue);
                service.Update(moduleEntity, m => m.F_Id == keyValue);
            }
            else
            {
                moduleEntity.Create();
                service.Insert(moduleEntity);
            }
        }
    }
}
