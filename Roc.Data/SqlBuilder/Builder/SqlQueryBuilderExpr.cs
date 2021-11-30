/* License: http://www.apache.org/licenses/LICENSE-2.0 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using Roc.Data.ValueObjects;

namespace Roc.Data.Builder
{
    /// <summary>
    /// Implements the expression buiding for the WHERE statement
    /// </summary>
    partial class SqlQueryBuilder
    {
        public void BeginExpression()
        {
            _conditions.Add("(");
        }

        public void EndExpression()
        {
            _conditions.Add(")");
        }

        public void And()
        {
            if (_conditions.Count > 0)
                _conditions.Add(" AND ");
        }

        public void Or()
        {
            if (_conditions.Count > 0)
                _conditions.Add(" OR ");
        }

        public void Not()
        {
            _conditions.Add(" NOT ");
        }

        public void QueryByField(string tableName, string fieldName, string op, object fieldValue)
        {
            var paramId = NextParamId();
            string newCondition = string.Format("{0} {1} {2}",
                Adapter.Field(tableName, fieldName),
                op,
                Adapter.Parameter(paramId));

            _conditions.Add(newCondition);
            AddParameter(paramId, fieldValue);
        }

        public void QueryConstByField(string fieldName, string op, object fieldValue)
        {
            string newCondition = string.Format("{0} {1} {2}", fieldName, op, fieldValue);
            _conditions.Add(newCondition);
        }

        public void UpdateByField(string tableName, string fieldName, string op, object fieldValue)
        {
            var paramId = fieldName;// NextParamId();
            string newCondition = string.Format("{0} {1} {2}",
                Adapter.Field(tableName, fieldName),
                op,
                Adapter.Parameter(paramId));
            _selectionList.Add(newCondition);
            AddParameter(paramId, fieldValue);
        }

        public void InsertByField(string tableName, string fieldName, object fieldValue)
        {
            var paramId = Adapter.Parameter(fieldName);//NextParamId();
            _selectionList.Add(Adapter.Field(fieldName));
            _parameters.Add(paramId);
            AddParameter(paramId, fieldValue);
        }

        public void InsertKey(bool flag)
        {
            this.InsertKeySqlText = flag ? "true" : "";
        }

        public void QueryByFieldLike(string tableName, string fieldName, string fieldValue)
        {
            var paramId = NextParamId();
            string newCondition = string.Format("{0} LIKE {1}",
                Adapter.Field(tableName, fieldName),
                Adapter.Parameter(paramId));

            _conditions.Add(newCondition);
            AddParameter(paramId, fieldValue);
        }

        public void QueryByFieldNull(string tableName, string fieldName)
        {
            _conditions.Add(string.Format("{0} IS NULL", Adapter.Field(tableName, fieldName)));
        }

        public void QueryByFieldNotNull(string tableName, string fieldName)
        {
            _conditions.Add(string.Format("{0} IS NOT NULL", Adapter.Field(tableName, fieldName)));
        }

        public void QueryByFieldComparison(string leftTableName, string leftFieldName, string op,
            string rightTableName, string rightFieldName)
        {
            string newCondition = string.Format("{0} {1} {2}",
            Adapter.Field(leftTableName, leftFieldName),
            op,
            Adapter.Field(rightTableName, rightFieldName));

            _conditions.Add(newCondition);
        }

        public void QueryByIsIn(string tableName, string fieldName, SqlLamBase sqlQuery)
        {
            var innerQuery = sqlQuery.SqlString;
            var names = sqlQuery.Parameters.ParameterNames;
            foreach (var name in names)
            {
                var param = sqlQuery.Parameters.Get(name);
                var innerParamKey = "Inner" + param.Name;
                innerQuery = Regex.Replace(innerQuery, param.Name, innerParamKey);
                AddParameter(innerParamKey, param.Value);
            }

            var newCondition = string.Format("{0} IN ({1})", Adapter.Field(tableName, fieldName), innerQuery);

            _conditions.Add(newCondition);
        }

        public void QueryByIsIn(string tableName, string fieldName, IEnumerable<object> values)
        {
            var paramIds = values.Select(x =>
                                             {
                                                 var paramId = NextParamId();
                                                 AddParameter(paramId, x);
                                                 return Adapter.Parameter(paramId);
                                             });

            var newCondition = string.Format("{0} IN ({1})", Adapter.Field(tableName, fieldName), string.Join(",", paramIds));
            _conditions.Add(newCondition);
        }
    }
}
