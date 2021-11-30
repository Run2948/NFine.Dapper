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
using System.Collections.Generic;
using System.Linq;

namespace Roc.Application.SystemManage
{
    public class ItemsDetailApp
    {
        private IItemsDetailRepository service = new ItemsDetailRepository();

        public List<ItemsDetailEntity> GetList(string itemId = "", string keyword = "")
        {
            var expression = ExtLinq.True<ItemsDetailEntity>();
            if (!string.IsNullOrEmpty(itemId))
            {
                expression = expression.And(t => t.F_ItemId == itemId);
            }
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.F_ItemName.Contains(keyword));
                expression = expression.Or(t => t.F_ItemCode.Contains(keyword));
            }
            return service.GetList(expression, m => m.F_SortCode).ToList();
        }
        public List<ItemsDetailEntity> GetItemList(string enCode)
        {
            return service.GetItemList(enCode);
        }
        public ItemsDetailEntity GetForm(string keyValue)
        {
            return service.Get(m => m.F_Id == keyValue);
        }
        public void DeleteForm(string keyValue)
        {
            service.Delete(m => m.F_Id == keyValue);
        }
        public void SubmitForm(ItemsDetailEntity itemsDetailEntity, string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                itemsDetailEntity.Modify(keyValue);
                service.Update(itemsDetailEntity, m => m.F_Id == keyValue);
            }
            else
            {
                itemsDetailEntity.Create();
                service.Insert(itemsDetailEntity);
            }
        }
    }
}
