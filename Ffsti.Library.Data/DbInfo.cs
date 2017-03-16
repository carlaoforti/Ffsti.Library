using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ffsti.Library.Data.Model;

namespace Ffsti.Library.Data
{
    public class DbInfo
    {
        private readonly Db _db;

        public DbInfo(Db db)
        {
            _db = db;
        }

        public virtual TableInfo GetTableInfo(string tableName)
        {
            return new TableInfo
            {
                Name = tableName,
                Columns = GetTableColumns(tableName)
            };
        }

        protected virtual List<ColumnInfo> GetTableColumns(string tableName)
        {
            var result = new List<ColumnInfo>();
            var query = $"SELECT * FROM {tableName} WHERE 1 = 2";

            var adapter = _db.CreateDataAdapter();

            using (var command = _db.GetCommand(query))
            {
                if (adapter != null)
                {
                    adapter.SelectCommand = command as DbCommand;
                    adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;

                    var dt = new DataTable();
                    adapter.FillSchema(dt, SchemaType.Source);

                    result.AddRange(from DataColumn col in dt.Columns
                                    select new ColumnInfo
                                    {
                                        Name = col.ColumnName,
                                        IsAutoIncrement = col.AutoIncrement,
                                        IsPrimaryKey = dt.PrimaryKey.Any(c => c.ColumnName == col.ColumnName),
                                        IsNullable = col.AllowDBNull
                                    });
                }
            }

            adapter?.Dispose();

            return result;
        }
    }
}