/*******************************************************************************
    * Copyright 2018 Roc.Framework 版权所有
    * Author: Roc Qing
    * Description: Roc 快速开发平台
    * Date：2018-09-12
    *********************************************************************************/
using Roc.Data;
using Roc.Model.Entity.SystemManage;
using Roc.Model.IRepository.SystemManage;
using Roc.Repository.SystemManage;
using System.Collections.Generic;

namespace Roc.Repository.SystemManage
{
    public class RoleRepository : RepositoryBase<RoleEntity>, IRoleRepository
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

                    var query = new SqlLam<RoleAuthorizeEntity>().Delete(m => m.F_ObjectId == keyValue);
                    db.Execute(query.SqlString, query.Parameters, tran);
                    tran.Commit();
                }
                catch
                {
                    tran.Rollback();
                }
            }
        }
        public void SubmitForm(RoleEntity roleEntity, List<RoleAuthorizeEntity> roleAuthorizeEntitys, string keyValue)
        {
            using (var db = base.Connection)
            {
                var tran = db.BeginTransaction();
                try
                {
                    if (!string.IsNullOrEmpty(keyValue))
                    {
                        var sql = base.GetSqlLam().Update(roleEntity).Where(m => m.F_Id == keyValue);
                        db.Execute(sql.SqlString, sql.Parameters, tran);
                    }
                    else
                    {
                        roleEntity.F_Category = 1;
                        var sql = base.GetSqlLam().Insert(roleEntity);
                        db.Execute(sql.SqlString, sql.Parameters, tran);
                    }
                    var query = new SqlLam<RoleAuthorizeEntity>().Delete(m => m.F_ObjectId == roleEntity.F_Id);
                    db.Execute(query.SqlString, query.Parameters, tran);

                    query = new SqlLam<RoleAuthorizeEntity>().Insert(roleAuthorizeEntitys);
                    db.Execute(query.SqlString, query.Parameters, tran);
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
