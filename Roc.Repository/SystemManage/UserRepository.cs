/*******************************************************************************
    * Copyright 2016 Roc.Framework 版权所有
    * Author: Roc Ching
    * Description: Roc 快速开发平台
    * Date：2016-09-12
    *********************************************************************************/
using Roc.Uility;
using Roc.Data;
using Roc.Model.Entity.SystemManage;
using Roc.Model.IRepository.SystemManage;
using Roc.Repository.SystemManage;

namespace Roc.Repository.SystemManage
{
    public class UserRepository : RepositoryBase<UserEntity>, IUserRepository
    {
        public void DeleteForm(string keyValue)
        {
            using (var db = base.Connection)
            {
                var tran = db.BeginTransaction();
                try
                {
                    var sql = base.GetSqlLam().Delete(m => m.F_Id == keyValue);
                    db.Execute(sql.SqlString, sql.Parameters, tran);

                    var query = new SqlLam<UserLogOnEntity>().Delete(m => m.F_UserId == keyValue);
                    db.Execute(query.SqlString, query.Parameters, tran);
                    tran.Commit();
                }
                catch
                {
                    tran.Rollback();
                }
            }
        }
        public void SubmitForm(UserEntity userEntity, UserLogOnEntity userLogOnEntity, string keyValue)
        {
            using (var db = base.Connection)
            {
                var tran = db.BeginTransaction();
                try
                {
                    if (!string.IsNullOrEmpty(keyValue))
                    {
                        var sql = base.GetSqlLam().Update(userEntity).Where(m => m.F_Id == keyValue);
                        db.Execute(sql.SqlString, sql.Parameters, tran);
                    }
                    else
                    {
                        userLogOnEntity.F_Id = userEntity.F_Id;
                        userLogOnEntity.F_UserId = userEntity.F_Id;
                        userLogOnEntity.F_UserSecretkey = Md5.md5(Common.CreateNo(), 16).ToLower();
                        userLogOnEntity.F_UserPassword = Md5.md5(DESEncrypt.Encrypt(Md5.md5(userLogOnEntity.F_UserPassword, 32).ToLower(), userLogOnEntity.F_UserSecretkey).ToLower(), 32).ToLower();
                        var sql = base.GetSqlLam().Insert(userEntity);
                        db.Execute(sql.SqlString, sql.Parameters, tran);

                        var query = new SqlLam<UserLogOnEntity>().Insert(userLogOnEntity);
                        db.Execute(query.SqlString, query.Parameters, tran);
                    }
                    tran.Commit();
                }
                catch
                {
                    tran.Rollback();
                }
            }
        }
    }
}
