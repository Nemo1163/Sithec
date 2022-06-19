using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace sitech.Data.DB
{
    public class Extensions
    {
        public async Task<List<T>> MapToListBase<T>(DbDataReader dr)
        {
            var props = typeof(T).GetRuntimeProperties();
            Dictionary<string, DbColumn> colMapping = ColumnMapping(dr, props);
            List<T> lstColumns = await ExecuteReader<T>(dr, props, colMapping);
            return lstColumns;
        }

        private static Dictionary<string, DbColumn> ColumnMapping(DbDataReader dr, IEnumerable<PropertyInfo> props)
        {
            return dr.GetColumnSchema()
                            .Where(x => props.Any(y => y.Name.ToLower() == x.ColumnName.ToLower()))
                            .ToDictionary(key => key.ColumnName.ToLower());
        }
        private static async Task<List<T>> ExecuteReader<T>(DbDataReader dr, IEnumerable<PropertyInfo> props, Dictionary<string, DbColumn> colMapping)
        {
            var objList = new List<T>();
            if (dr.HasRows)
            {
                while (await dr.ReadAsync())
                {
                    T obj = Activator.CreateInstance<T>();
                    foreach (var prop in props)
                    {
                        var val = dr.GetValue(colMapping[prop.Name.ToLower()].ColumnOrdinal.Value);
                        prop.SetValue(obj, val == DBNull.Value ? null : val);
                    }
                    objList.Add(obj);
                }
            }

            return objList;
        }
    }
}
