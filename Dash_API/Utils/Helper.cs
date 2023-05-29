using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Http.ModelBinding;

namespace Dash_API.Utils
{
    public static class Helper
    {
        // using DBNull.Value comparison
        public static T DbNullGetValue<T>(this IDataReader reader, string columnName)
        {
            var value = reader[columnName]; // read column value

            return value == DBNull.Value ? default(T) : (T)value;
        }
    }
}