/*******************************************************************************
    * Copyright 2018 Roc.Framework 版权所有
    * Author: Roc Qing
    * Description: Roc 快速开发平台
    * Date：2018-09-12
    *********************************************************************************/
using NFine.Uility;
using NFine.Model.Entity.SystemManage;
using NFine.Model.IRepository.SystemManage;
using NFine.Repository.SystemManage;
using System.Collections.Generic;
using System.Linq;

namespace NFine.Application.SystemManage
{
    public class DutyApp
    {
        private IRoleRepository service = new RoleRepository();

        public List<RoleEntity> GetList(string keyword = "")
        {
            var expression = ExtLinq.True<RoleEntity>();
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.F_FullName.Contains(keyword));
                expression = expression.Or(t => t.F_EnCode.Contains(keyword));
            }
            expression = expression.And(t => t.F_Category == 2);
            return service.GetList(expression, m => m.F_SortCode).ToList();
        }
        public RoleEntity GetForm(string keyValue)
        {
            return service.Get(m => m.F_Id == keyValue);
        }
        public void DeleteForm(string keyValue)
        {
            service.Delete(m => m.F_Id == keyValue);
        }
        public void SubmitForm(RoleEntity roleEntity, string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                roleEntity.Modify(keyValue);
                service.Update(roleEntity, m => m.F_Id == keyValue);
            }
            else
            {
                roleEntity.Create();
                roleEntity.F_Category = 2;
                service.Insert(roleEntity);
            }
        }
    }
}
