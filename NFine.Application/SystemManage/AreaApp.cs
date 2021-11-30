/*******************************************************************************
    * Copyright 2018 Roc.Framework 版权所有
    * Author: Roc Qing
    * Description: Roc 快速开发平台
    * Date：2018-09-12
    *********************************************************************************/
using NFine.Model.Entity.SystemManage;
using NFine.Model.IRepository.SystemManage;
using NFine.Repository.SystemManage;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NFine.Application.SystemManage
{
    public class AreaApp
    {
        private IAreaRepository service = new AreaRepository();

        public List<AreaEntity> GetList()
        {
            return service.GetList().ToList();
        }
        public AreaEntity GetForm(string keyValue)
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
        public void SubmitForm(AreaEntity areaEntity, string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                areaEntity.Modify(keyValue);
                service.Update(areaEntity, m => m.F_Id == keyValue);
            }
            else
            {
                areaEntity.Create();
                service.Insert(areaEntity);
            }
        }
    }
}
