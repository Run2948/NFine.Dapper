/* License: http://www.apache.org/licenses/LICENSE-2.0 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Roc.Data.Adapter
{
    /// <summary>
    /// Provides functionality common to all supported SQL Server versions
    /// </summary>
    class SqlServerAdapterBase : SqlAdapterBase
    {
        public string QueryStringPage(string source, string selection, string conditions, string order,
            int pageSize)
        {
            return string.Format("SELECT TOP({4}) {0} FROM {1} {2} {3}", selection, source, conditions, order, pageSize);
        }

        public string InsertString(string source, string selection, string parameters, string key)
        {
            string sql = string.Format("INSERT INTO {0} ({1}) VALUES({2}) ", source, selection, parameters);
            if (!string.IsNullOrEmpty(key))
                sql += ";SELECT ISNULL(SCOPE_IDENTITY(),0) AS ID ";
            return sql;
        }

        public string UpdateString(string source, string selction, string conditions)
        {
            return string.Format("UPDATE {0} SET {1} {2} ", source, selction, conditions);
        }

        public string DeleteString(string source, string conditions)
        {
            return string.Format("DELETE FROM {0} {1} ", source, conditions);
        }

        public string Table(string tableName)
        {
            return string.Format("[{0}]", tableName);
        }

        public string Field(string filedName)
        {
            return string.Format("[{0}]", filedName);
        }

        public string Field(string tableName, string fieldName)
        {
            return string.Format("[{0}].[{1}]", tableName, fieldName);
        }

        public string Parameter(string parameterId)
        {
            return "@" + parameterId;
        }
    }
}
