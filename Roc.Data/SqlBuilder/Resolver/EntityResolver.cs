using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Linq.Expressions;

namespace Roc.Data.Resolver
{
    partial class LambdaResolver
    {
        public void ResolveUpdate<T>(T entity)
        {
            string tableName = GetTableName<T>();
            ResolveParameter<T>(tableName, entity);
        }

        public void ResolveUpdate(Type type, object obj)
        {
            string tableName = GetTableName(type);
            ResolveParameter<object>(tableName, obj);
        }

        public void ResolveInsert<T>(bool key, T entity)
        {
            string tableName = GetTableName<T>();
            ResolveParameter<T>(key, tableName, entity);
        }

        public void ResolveInsert(bool key, Type type, object obj)
        {
            string tableName = GetTableName(type);
            ResolveParameter<object>(key, tableName, obj);
        }

        private void ResolveParameter<T>(string tableName, T entity)
        {
            Type type = entity.GetType();
            var ps = type.GetProperties();
            foreach (PropertyInfo item in ps)
            {
                object obj = item.GetValue(entity, null);
                _builder.UpdateByField(tableName, item.Name, _operationDictionary[ExpressionType.Equal], obj);
            }
        }

        private void ResolveParameter<T>(bool key, string tableName, T entity)
        {
            _builder.InsertKey(key);

            Type type = entity.GetType();
            var ps = type.GetProperties();
            foreach (PropertyInfo item in ps)
            {
                object obj = item.GetValue(entity, null);
                _builder.InsertByField(tableName, item.Name, obj);
            }
        }
    }
}
