/* License: http://www.apache.org/licenses/LICENSE-2.0 */

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using NFine.Data.Adapter;

namespace NFine.Data.Builder
{
    /// <summary>
    /// Implements the whole SQL building logic. Continually adds and stores the SQL parts as the requests come. 
    /// When requested to return the QueryString, the parts are combined and returned as a single query string.
    /// The query parameters are stored in a dictionary implemented by an ExpandoObject that can be requested by QueryParameters.
    /// </summary>
    public partial class SqlQueryBuilder
    {
        internal ISqlAdapter Adapter { get; set; }
        internal SqlType Type { get; set; }

        private const string PARAMETER_PREFIX = "Param";

        private readonly List<string> _tableNames = new List<string>();
        private readonly List<string> _joinExpressions = new List<string>();
        private readonly List<string> _selectionList = new List<string>();
        private readonly List<string> _conditions = new List<string>();
        private readonly List<string> _sortList = new List<string>();
        private readonly List<string> _groupingList = new List<string>();
        private readonly List<string> _havingConditions = new List<string>();
        private readonly List<string> _splitColumns = new List<string>();
        private readonly List<string> _parameters = new List<string>();
        private int _paramIndex;

        public List<string> TableNames { get { return _tableNames; } }
        public List<string> JoinExpressions { get { return _joinExpressions; } }
        public List<string> SelectionList { get { return _selectionList; } }
        public List<string> WhereConditions { get { return _conditions; } }
        public List<string> OrderByList { get { return _sortList; } }
        public List<string> GroupByList { get { return _groupingList; } }
        public List<string> HavingConditions { get { return _havingConditions; } }
        public List<string> SplitColumns { get { return _splitColumns; } }
        public int CurrentParamIndex { get { return _paramIndex; } }
        public DynamicParameters Parameters { get; private set; }

        private string Source
        {
            get
            {
                var joinExpression = string.Join(" ", _joinExpressions);
                return string.Format("{0} {1}", Adapter.Table(_tableNames.First()), joinExpression);
            }
        }
        private string Selection
        {
            get
            {
                if (_selectionList.Count == 0)
                    return string.Format("{0}.*", Adapter.Table(_tableNames.First()));
                else
                    return string.Join(", ", _selectionList);
            }
        }
        private string Conditions
        {
            get
            {
                if (_conditions.Count == 0)
                    return "";
                else
                    return "WHERE " + string.Join("", _conditions);
            }
        }
        private string Order
        {
            get
            {
                if (_sortList.Count == 0)
                    return "";
                else
                    return "ORDER BY " + string.Join(", ", _sortList);
            }
        }
        private string Grouping
        {
            get
            {
                if (_groupingList.Count == 0)
                    return "";
                else
                    return "GROUP BY " + string.Join(", ", _groupingList);
            }
        }
        private string Having
        {
            get
            {
                if (_havingConditions.Count == 0)
                    return "";
                else
                    return "HAVING " + string.Join(" ", _havingConditions);
            }
        }
        private string ParameterString
        {
            get
            {
                if (_parameters.Count == 0) return "";
                return string.Join(", ", _parameters);
            }
        }

        public string InsertKeySqlText { get; set; }

        public string SqlString()
        {
            string sql = string.Empty;
            switch (this.Type)
            {
                case SqlType.Query:
                    sql = Adapter.QueryString(Selection, Source, Conditions, Grouping, Having, Order);
                    break;
                case SqlType.Insert:
                    sql = Adapter.InsertString(Source, Selection, ParameterString, InsertKeySqlText);
                    break;
                case SqlType.Update:
                    sql = Adapter.UpdateString(Source, Selection, Conditions);
                    break;
                case SqlType.Delete:
                    sql = Adapter.DeleteString(Source, Conditions);
                    break;
                default:
                    break;
            }
            return sql;
        }

        public string QueryStringPage(int pageSize, int? pageNumber = null)
        {
            if (pageNumber.HasValue)
            {
                if (_sortList.Count == 0)
                    throw new Exception("Pagination requires the ORDER BY statement to be specified");

                return Adapter.QueryStringPage(Source, Selection, Conditions, Order, pageSize, pageNumber.Value);
            }

            return Adapter.QueryStringPage(Source, Selection, Conditions, Order, pageSize);
        }

        internal SqlQueryBuilder(SqlType type, string tableName, ISqlAdapter adapter)
        {
            _paramIndex = 0;
            _tableNames.Add(tableName);
            this.Adapter = adapter;
            this.Parameters = new DynamicParameters();
            this.Type = type;
        }

        public void Clear()
        {
            if (_joinExpressions.Count > 0)
            {
                string tableName = _tableNames[0];
                _tableNames.Clear();
                _joinExpressions.Clear();
                _tableNames.Add(tableName);
            }
            _selectionList.Clear();
            _conditions.Clear();
            _sortList.Clear();
            _groupingList.Clear();
            _havingConditions.Clear();
            _splitColumns.Clear();
            _parameters.Clear();
            _paramIndex = 0;
            this.Parameters = new DynamicParameters();
            this.Type = SqlType.Query;
        }

        public void UpdateSqlType(SqlType type)
        {
            this.Type = type;
        }

        #region helpers
        private string NextParamId()
        {
            ++_paramIndex;
            return PARAMETER_PREFIX + _paramIndex.ToString(CultureInfo.InvariantCulture);
        }

        private void AddParameter(string key, object value)
        {
            //if (!Parameters.ContainsKey(key))
            Parameters.Add(key, value);
        }
        #endregion
    }
}
