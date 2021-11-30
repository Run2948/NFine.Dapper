/*******************************************************************************
    * Copyright 2018 Roc.Framework 版权所有
    * Author: Roc Qing
    * Description: Roc 快速开发平台
    * Date：2018-09-12
    *********************************************************************************/

using NFine.Data;
using NFine.Model.Entity.SystemSecurity;
using NFine.Model.IRepository.SystemSecurity;
using NFine.Uility;

namespace NFine.Repository.SystemSecurity
{
    public class DbBackupRepository : RepositoryBase<DbBackupEntity>, IDbBackupRepository
    {
        public void DeleteForm(string keyValue)
        {
            var dbBackupEntity = base.Get(m => m.F_Id == keyValue);
            if (dbBackupEntity != null)
            {
                FileHelper.DeleteFile(dbBackupEntity.F_FilePath);
            }
            base.Delete(m => m.F_Id == keyValue);
        }
        public void ExecuteDbBackup(DbBackupEntity dbBackupEntity)
        {
            //DbHelper.ExecuteSqlCommand(string.Format("backup database {0} to disk ='{1}'", dbBackupEntity.F_DbName, dbBackupEntity.F_FilePath));
            //dbBackupEntity.F_FileSize = FileHelper.ToFileSize(FileHelper.GetFileSize(dbBackupEntity.F_FilePath));
            //dbBackupEntity.F_FilePath = "/Resource/DbBackup/" + dbBackupEntity.F_FileName;
            //this.Insert(dbBackupEntity);
        }
    }
}
