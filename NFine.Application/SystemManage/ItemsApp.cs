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
    public class ItemsApp
    {
        private IItemsRepository service = new ItemsRepository();

        public List<ItemsEntity> GetList()
        {
            return service.GetList().ToList();
        }
        public ItemsEntity GetForm(string keyValue)
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
        public void SubmitForm(ItemsEntity itemsEntity, string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                itemsEntity.Modify(keyValue);
                service.Update(itemsEntity, m => m.F_Id == keyValue);
            }
            else
            {
                itemsEntity.Create();
                service.Insert(itemsEntity);
            }
        }
    }
}
