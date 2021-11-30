/*******************************************************************************
    * Copyright 2018 Roc.Framework 版权所有
    * Author: Roc Qing
    * Description: Roc 快速开发平台
    * Date：2018-09-12
    *********************************************************************************/
using Roc.Uility;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;

namespace Roc.Data
{
    /// <summary>
    /// 仓储接口
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    public interface IRepositoryBase<TEntity> where TEntity : class,new()
    {
        string DbKey { get; set; }

        int Insert(TEntity entity);
        TKey Insert<TKey>(TEntity entity);
        int Insert(IEnumerable<TEntity> entitys);

        int Update(object entity, Expression<Func<TEntity, bool>> expression);
        int Update(TEntity entity, Expression<Func<TEntity, bool>> expression);

        int Delete(Expression<Func<TEntity, bool>> expression);

        TEntity Get(Expression<Func<TEntity, bool>> expression);
        TEntity Get(SqlLam<TEntity> sql);

        IEnumerable<TEntity> GetList();
        IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> expression);
        IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> expression, Expression<Func<TEntity, object>> orderBy, bool asc = true);
        IEnumerable<TEntity> GetList(SqlLam<TEntity> sql);

        IEnumerable<TEntity> GetPagingList(Pagination p, Expression<Func<TEntity, bool>> expression, Expression<Func<TEntity, object>> orderBy);
        IEnumerable<TEntity> GetPagingList(Pagination p, SqlLam<TEntity> sql, SqlLam<TEntity> sqlCount);

        long Count(Expression<Func<TEntity, object>> key);
        long Count(Expression<Func<TEntity, object>> key, Expression<Func<TEntity, bool>> where);

        TKey Max<TKey>(Expression<Func<TEntity, object>> key);
        TKey Max<TKey>(Expression<Func<TEntity, object>> key, Expression<Func<TEntity, bool>> where);
    }
}
