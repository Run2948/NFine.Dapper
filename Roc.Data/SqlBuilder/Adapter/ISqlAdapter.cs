/* License: http://www.apache.org/licenses/LICENSE-2.0 */

using System;
using System.Collections.Generic;

namespace Roc.Data.Adapter
{
    /// <summary>
    /// SQL adapter provides db specific functionality related to db specific SQL syntax
    /// </summary>
    interface ISqlAdapter
    {
        string QueryString(string selection, string source, string conditions,
            string order, string grouping, string having);

        string QueryStringPage(string selection, string source, string conditions, string order,
            int pageSize, int pageNumber);

        string QueryStringPage(string selection, string source, string conditions, string order,
            int pageSize);

        string InsertString(string source, string selection, string parameters, string key);

        string UpdateString(string source, string selction, string conditions);

        string DeleteString(string source, string conditions);

        string Table(string tableName);
        string Field(string filedName);
        string Field(string tableName, string fieldName);
        string Parameter(string parameterId);
    }
}
