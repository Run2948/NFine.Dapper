/*******************************************************************************
    * Copyright 2018 Roc.Framework 版权所有
    * Author: Roc Qing
    * Description: Roc 快速开发平台
    * Date：2018-09-12
    *********************************************************************************/
using Roc.Uility;
using Roc.Model.Entity.SystemSecurity;
using Roc.Model.IRepository.SystemSecurity;
using Roc.Repository.SystemSecurity;
using System.Collections.Generic;
using System.Linq;

namespace Roc.Application.SystemSecurity
{
    public class FilterIPApp
    {
        private IFilterIPRepository service = new FilterIPRepository();

        public List<FilterIPEntity> GetList(string keyword)
        {
            var expression = ExtLinq.True<FilterIPEntity>();
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.F_StartIP.Contains(keyword));
            }
            return service.GetList(expression, m => m.F_DeleteTime, false).ToList();
        }
        public FilterIPEntity GetForm(string keyValue)
        {
            return service.Get(m => m.F_Id == keyValue);
        }
        public void DeleteForm(string keyValue)
        {
            service.Delete(m => m.F_Id == keyValue);
        }
        public void SubmitForm(FilterIPEntity filterIPEntity, string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                filterIPEntity.Modify(keyValue);
                service.Update(filterIPEntity, m => m.F_Id == keyValue);
            }
            else
            {
                filterIPEntity.Create();
                service.Insert(filterIPEntity);
            }
        }
    }
}
