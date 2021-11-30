/*******************************************************************************
    * Copyright 2018 Roc.Framework 版权所有
    * Author: Roc Qing
    * Description: Roc 快速开发平台
    * Date：2018-09-12
    *********************************************************************************/
using System.Collections.Generic;
using NFine.Data;
using NFine.Model.Entity.SystemManage;
using NFine.Model.IRepository.SystemManage;

namespace NFine.Repository.SystemManage
{
    public class ModuleButtonRepository : RepositoryBase<ModuleButtonEntity>, IModuleButtonRepository
    {
        public void SubmitCloneButton(List<ModuleButtonEntity> entitys)
        {
            base.Insert(entitys);
        }
    }
}
