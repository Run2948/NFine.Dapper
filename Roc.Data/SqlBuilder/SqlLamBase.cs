/* License: http://www.apache.org/licenses/LICENSE-2.0 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Roc.Data;
using Roc.Data.Adapter;
using Roc.Data.Builder;
using Roc.Data.Resolver;
using Roc.Data.ValueObjects;

namespace Roc.Data
{
    /// <summary>
    /// Base functionality for the SqlLam class that is not related to any specific entity type
    /// </summary>
    public abstract class SqlLamBase
    {
        internal static ISqlAdapter _defaultAdapter;
        internal SqlQueryBuilder _builder;
        internal LambdaResolver _resolver;
        internal SqlType _type;
        internal SqlAdapter _adapter;

        public SqlQueryBuilder SqlBuilder { get { return _builder; } }

        public SqlType SqlType { get { return _type; } set { _type = value; } }

        public SqlLamBase()
        {
            SqlLamBase.SetAdapter(_adapter);
        }

        public string SqlString
        {
            get
            {
                return _builder.SqlString();
            }
        }

        public string QueryPage(int pageSize, int? pageNumber = null)
        {
            return _builder.QueryStringPage(pageSize, pageNumber);
        }

        public DynamicParameters Parameters
        {
            get { return _builder.Parameters; }
        }

        public string[] SplitColumns
        {
            get { return _builder.SplitColumns.ToArray(); }
        }

        public static void SetAdapter(SqlAdapter adapter)
        {
            _defaultAdapter = GetAdapterInstance(adapter);
        }

        private static ISqlAdapter GetAdapterInstance(SqlAdapter adapter)
        {
            switch (adapter)
            {
                case SqlAdapter.SqlServer2008:
                    return new SqlServer2008Adapter();
                case SqlAdapter.SqlServer2012:
                    return new SqlServer2012Adapter();
                default:
                    throw new ArgumentException("The specified Sql Adapter was not recognized");
            }
        }
    }
}
