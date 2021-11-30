/*******************************************************************************
    * Copyright 2018 Roc.Framework 版权所有
    * Author: Roc Qing
    * Description: Roc 快速开发平台
    * Date：2018-09-12
    *********************************************************************************/
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Roc.Uility;
using System;

namespace Roc.Data
{
    public class DbHelper
    {
        private static string db_key = "NFineBaseKey";
        private static DbHelper instance = null;

        public DbEntity GetDbEntity(string key = "")
        {
            if (string.IsNullOrEmpty(key)) key = db_key;
            ICache cache = CacheFactory.Cache();
            DbEntity db = cache.GetCache<DbEntity>(key);
            if (db == null)
            {
                var manager = ConfigurationManager.ConnectionStrings[key];
                db = new DbEntity()
                {
                    Name = key,
                    ConnectionString = manager.ConnectionString,
                    ProviderName = manager.ProviderName
                };
                cache.WriteCache<DbEntity>(db, key);
            }
            return db;
        }

        public string GetConnectionString(string key)
        {
            DbEntity db = GetDbEntity(key);
            return db.ConnectionString;
        }

        public IDbConnection CreateConnection(string key)
        {
            DbConnection dbConnection = null;
            try
            {
                var db = GetDbEntity(key);
                DbProviderFactory dbfactory = DbProviderFactories.GetFactory(db.ProviderName);
                dbConnection = dbfactory.CreateConnection();
                dbConnection.ConnectionString = db.ConnectionString;
            }
            catch { }
            if (dbConnection == null)
                throw new Exception("IDbConnection 未初始化!");

            return dbConnection;
        }

        public static DbHelper GetInstance()
        {
            if (instance == null)
            {
                instance = new DbHelper();
            }
            return instance;
        }

        public static string GetDefaultDbKey()
        {
            return db_key;
        }
        //public static int ExecuteSqlCommand(string cmdText)
        //{
        //    using (DbConnection conn = new SqlConnection(connstring))
        //    {
        //        DbCommand cmd = new SqlCommand();
        //        PrepareCommand(cmd, conn, null, CommandType.Text, cmdText, null);
        //        return cmd.ExecuteNonQuery();
        //    }
        //}
        //private static void PrepareCommand(DbCommand cmd, DbConnection conn, DbTransaction isOpenTrans, CommandType cmdType, string cmdText, DbParameter[] cmdParms)
        //{
        //    if (conn.State != ConnectionState.Open)
        //        conn.Open();
        //    cmd.Connection = conn;
        //    cmd.CommandText = cmdText;
        //    if (isOpenTrans != null)
        //        cmd.Transaction = isOpenTrans;
        //    cmd.CommandType = cmdType;
        //    if (cmdParms != null)
        //    {
        //        cmd.Parameters.AddRange(cmdParms);
        //    }
        //}
    }

    public class DbEntity
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 连接字符串
        /// </summary>
        public string ConnectionString { get; set; }
        /// <summary>
        /// 实例提供者
        /// </summary>
        public string ProviderName { get; set; }
    }

    public enum DataBaseType
    {
        SqlServer
    }
}
