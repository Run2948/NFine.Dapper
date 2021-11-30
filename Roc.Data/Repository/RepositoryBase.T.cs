
/*******************************************************************************
    * Copyright 2018 Roc.Framework 版权所有
    * Author: Roc Qing
    * Description: Roc 快速开发平台
    * Date：2018-09-12
    *********************************************************************************/
using Roc.Uility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Roc.Data
{
    /// <summary>
    /// 仓储实现
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class,new()
    {
        DbHelper helper = DbHelper.GetInstance();
        string key = DbHelper.GetDefaultDbKey();
        IDbConnection connection;

        public RepositoryBase(string key)
            : this()
        {
            this.key = key;
        }

        public RepositoryBase()
        {
            this.DbKey = key;
            connection = helper.CreateConnection(key);
        }

        public SqlLam<TEntity> GetSqlLam()
        {
            string key = typeof(TEntity).FullName;
            ICache cache = CacheFactory.Cache();
            SqlLam<TEntity> sql = cache.GetCache<SqlLam<TEntity>>(key);
            if (sql == null)
            {
                sql = new SqlLam<TEntity>();
                cache.WriteCache<SqlLam<TEntity>>(sql, key);
            }
            else
            {
                sql.Clear();
            }
            return sql;
        }

        public IDbConnection Connection { get { return connection; } }

        public string DbKey { get { return key; } set { key = value; } }

        public int Insert(TEntity entity)
        {
            var sql = this.GetSqlLam().Insert(entity);
            return connection.Execute(sql.SqlString, sql.Parameters);
        }

        public TKey Insert<TKey>(TEntity entity)
        {
            var sql = this.GetSqlLam().Insert(entity, true);
            TKey result = connection.Query<TKey>(sql.SqlString, sql.Parameters).FirstOrDefault();
            return result;
        }

        public int Insert(IEnumerable<TEntity> entitys)
        {
            var sql = this.GetSqlLam().Insert(entitys.ElementAt(0));
            return connection.Execute(sql.SqlString, entitys);
        }

        public int Update(object entity, Expression<Func<TEntity, bool>> expression)
        {
            var sql = this.GetSqlLam();
            sql.Update((dynamic)entity).Where(expression);
            return connection.Execute(sql.SqlString, sql.Parameters);
        }

        public int Update(TEntity entity, Expression<Func<TEntity, bool>> expression)
        {
            var sql = this.GetSqlLam().Update(entity).Where(expression);
            return connection.Execute(sql.SqlString, sql.Parameters);
        }

        public int Delete(Expression<Func<TEntity, bool>> expression)
        {
            var sql = this.GetSqlLam().Delete(expression);
            return connection.Execute(sql.SqlString, sql.Parameters);
        }

        public TEntity Get(Expression<Func<TEntity, bool>> expression)
        {
            var sql = this.GetSqlLam().Where(expression);
            return this.Get(sql);
        }
        public TEntity Get(SqlLam<TEntity> sql)
        {
            return connection.Query<TEntity>(sql.SqlString, sql.Parameters).FirstOrDefault();
        }

        public IEnumerable<TEntity> GetList()
        {
            var sql = this.GetSqlLam();
            return this.GetList(sql);
        }
        public IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> expression)
        {
            var sql = this.GetSqlLam().Where(expression);
            return this.GetList(sql);
        }
        public IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> expression, Expression<Func<TEntity, object>> orderBy, bool asc = true)
        {
            var sql = this.GetSqlLam().Where(expression);
            if (asc) sql.OrderBy(orderBy);
            else sql.OrderByDescending(orderBy);
            return this.GetList(sql);
        }
        public IEnumerable<TEntity> GetList(SqlLam<TEntity> sql)
        {
            return connection.Query<TEntity>(sql.SqlString, sql.Parameters);
        }
        public IEnumerable<TEntity> GetPagingList(Pagination p, Expression<Func<TEntity, bool>> expression, Expression<Func<TEntity, object>> orderBy)
        {
            var sql = this.GetSqlLam().Where(expression).OrderBy(orderBy);
            // TODO: (已实现) 修复用户管理列表查询出错 - Roc Qing                
            //var sqlCount = new SqlLam<TEntity>().Where(expression);
            var sqlCount = new SqlLam<TEntity>().Where(expression).Count();
            return this.GetPagingList(p, sql, sqlCount);
        }

        public IEnumerable<TEntity> GetPagingList(Pagination p, SqlLam<TEntity> sql, SqlLam<TEntity> sqlCount)
        {
            string sqlText = sql.QueryPage(p.rows, p.page) + @";" + sqlCount.SqlString;
            var reader = connection.QueryMultiple(sqlText, sql.Parameters);
            var list = reader.Read<TEntity>();
            var records = reader.Read<int>().FirstOrDefault();
            p.records = records;
            return list;
        }

        public long Count(Expression<Func<TEntity, object>> key)
        {
            var sql = this.GetSqlLam().SelectCount(key);
            return connection.Query<long>(sql.SqlString).FirstOrDefault();
        }

        public long Count(Expression<Func<TEntity, object>> key, Expression<Func<TEntity, bool>> where)
        {
            var sql = this.GetSqlLam().SelectCount(key).Where(where);
            return connection.Query<long>(sql.SqlString, sql.Parameters).FirstOrDefault();
        }

        public TKey Max<TKey>(Expression<Func<TEntity, object>> key)
        {
            var sql = this.GetSqlLam().SelectMax(key);
            return connection.Query<TKey>(sql.SqlString).FirstOrDefault();
        }

        public TKey Max<TKey>(Expression<Func<TEntity, object>> key, Expression<Func<TEntity, bool>> where)
        {
            var sql = this.GetSqlLam().SelectMax(key).Where(where);
            return connection.Query<TKey>(sql.SqlString, sql.Parameters).FirstOrDefault();
        }

        //public List<TEntity> FindList(Pagination pagination)
        //{
        //    bool isAsc = pagination.sord.ToLower() == "asc" ? true : false;
        //    string[] _order = pagination.sidx.Split(',');
        //    MethodCallExpression resultExp = null;
        //    //var tempData = dbcontext.Set<TEntity>().AsQueryable();
        //    foreach (string item in _order)
        //    {
        //        string _orderPart = item;
        //        _orderPart = Regex.Replace(_orderPart, @"\s+", " ");
        //        string[] _orderArry = _orderPart.Split(' ');
        //        string _orderField = _orderArry[0];
        //        bool sort = isAsc;
        //        if (_orderArry.Length == 2)
        //        {
        //            isAsc = _orderArry[1].ToUpper() == "ASC" ? true : false;
        //        }
        //        var parameter = Expression.Parameter(typeof(TEntity), "t");
        //        var property = typeof(TEntity).GetProperty(_orderField);
        //        var propertyAccess = Expression.MakeMemberAccess(parameter, property);
        //        var orderByExp = Expression.Lambda(propertyAccess, parameter);
        //        resultExp = Expression.Call(typeof(Queryable), isAsc ? "OrderBy" : "OrderByDescending", new Type[] { typeof(TEntity), property.PropertyType }, tempData.Expression, Expression.Quote(orderByExp));
        //    }
        //    tempData = tempData.Provider.CreateQuery<TEntity>(resultExp);
        //    pagination.records = tempData.Count();
        //    tempData = tempData.Skip<TEntity>(pagination.rows * (pagination.page - 1)).Take<TEntity>(pagination.rows).AsQueryable();
        //    return tempData.ToList();
        //}
        //public List<TEntity> FindList(Expression<Func<TEntity, bool>> predicate, Pagination pagination)
        //{
        //    bool isAsc = pagination.sord.ToLower() == "asc" ? true : false;
        //    string[] _order = pagination.sidx.Split(',');
        //    MethodCallExpression resultExp = null;
        //    var tempData = dbcontext.Set<TEntity>().Where(predicate);
        //    foreach (string item in _order)
        //    {
        //        string _orderPart = item;
        //        _orderPart = Regex.Replace(_orderPart, @"\s+", " ");
        //        string[] _orderArry = _orderPart.Split(' ');
        //        string _orderField = _orderArry[0];
        //        bool sort = isAsc;
        //        if (_orderArry.Length == 2)
        //        {
        //            isAsc = _orderArry[1].ToUpper() == "ASC" ? true : false;
        //        }
        //        var parameter = Expression.Parameter(typeof(TEntity), "t");
        //        var property = typeof(TEntity).GetProperty(_orderField);
        //        var propertyAccess = Expression.MakeMemberAccess(parameter, property);
        //        var orderByExp = Expression.Lambda(propertyAccess, parameter);
        //        resultExp = Expression.Call(typeof(Queryable), isAsc ? "OrderBy" : "OrderByDescending", new Type[] { typeof(TEntity), property.PropertyType }, tempData.Expression, Expression.Quote(orderByExp));
        //    }
        //    tempData = tempData.Provider.CreateQuery<TEntity>(resultExp);
        //    pagination.records = tempData.Count();
        //    tempData = tempData.Skip<TEntity>(pagination.rows * (pagination.page - 1)).Take<TEntity>(pagination.rows).AsQueryable();
        //    return tempData.ToList();
        //}
    }
}
