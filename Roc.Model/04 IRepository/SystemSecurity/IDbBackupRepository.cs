/*******************************************************************************
    * Copyright 2018 Roc.Framework 版权所有
    * Author: Roc Qing
    * Description: Roc 快速开发平台
    * Date：2018-09-12
    *********************************************************************************/
using Roc.Data;
using Roc.Model.Entity.SystemSecurity;

namespace Roc.Model.IRepository.SystemSecurity
{
    public interface IDbBackupRepository : IRepositoryBase<DbBackupEntity>
    {
        void DeleteForm(string keyValue);
        void ExecuteDbBackup(DbBackupEntity dbBackupEntity);
    }
}
