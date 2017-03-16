using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using Dapper;
using Ffsti.Library.Data.ExtensionMethods;
using Ffsti.Library.Data.Model;

namespace Ffsti.Library.Data
{
    public class Db : IDisposable
    {
        //SqlServer Connection String - .NET Framework Data Provider for SQL Server
        //Provider - System.Data.SqlClient
        //
        //Standard Security
        //Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password=myPassword;
        //
        //Trusted Connection
        //Server=myServerAddress;Database=myDataBase;Trusted_Connection=True;

        //Oracle Connection String - Oracle Data Provider for .NET / ODP.NET
        //Provider -  Oracle.DataAccess.Client
        //
        //Using TNS
        //Data Source=TORCL;User Id=myUsername;Password=myPassword;
        //
        //Using Integrated Security
        //Data Source=TORCL;Integrated Security=SSPI;
        //
        //Using ODP.NET without tnsnames.ora
        //Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=MyHost)(PORT=MyPort)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=MyOracleSID)));User Id=myUsername;Password=myPassword;

        private readonly string _connectionString;

        private DbProviderFactory _dbProviderFactory;

        private IDbConnection Connection { get; set; }

        public ConnectionState State => Connection.State;

        private IDbTransaction Transaction { get; set; }

        private static Db _db;

        public static Db GetInstance(string connectionString = "", string providerName = "")
        {
            if (_db == null && string.IsNullOrWhiteSpace(connectionString) && string.IsNullOrWhiteSpace(providerName))
            {
                throw new Exception(@"You need to enter the Connection String and the Provider Name");
            }

            return _db ?? (_db = new Db(connectionString, providerName));
        }

        private Db(string connectionString, string providerName)
        {
            _connectionString = connectionString;

            _dbProviderFactory = DbProviderFactories.GetFactory(providerName);

            Connection = _dbProviderFactory.CreateConnection();
            if (Connection == null)
                return;

            Connection.ConnectionString = _connectionString;
            Connection.Open();
        }

        public virtual void OpenConnection()
        {
            Connection = _dbProviderFactory.CreateConnection();
            if (Connection == null)
                return;

            Connection.ConnectionString = _connectionString;
            Connection.Open();
        }

        public virtual void CloseConnection()
        {
            Connection.Close();
        }

        public virtual IDbCommand GetCommand(string commandText)
        {
            var comm = Connection.CreateCommand();
            comm.CommandText = commandText;
            if (Transaction != null)
                comm.Transaction = Transaction;

            return comm;
        }

        public virtual DataTable GetDataTable(string query)
        {
            return GetDataTable(query, null);
        }

        public virtual DataTable GetDataTable(string query, params IDataParameter[] parameters)
        {
            using (var command = GetCommand(query))
            {
                foreach (var parameter in parameters)
                {
                    command.AddParameter(parameter.ParameterName, parameter.Value, parameter.DbType, parameter.Direction);
                }

                return GetDataTable(command);
            }
        }

        public virtual DataTable GetDataTable(IDbCommand command)
        {
            using (var dataAdapter = _dbProviderFactory.CreateDataAdapter())
            {
                if (dataAdapter == null)
                    return null;

                dataAdapter.SelectCommand = (DbCommand)command;

                var table = new DataTable();
                dataAdapter.Fill(table);

                return table;
            }
        }

        //public virtual IDataReader ExecuteReader(string commandText)
        //{
        //    return GetCommand(commandText).ExecuteReader();
        //}

        public virtual object ExecuteScalar(string commandText)
        {
            return GetCommand(commandText).ExecuteScalar();
        }

        public virtual int ExecuteNonQuery(string commandText)
        {
            return GetCommand(commandText).ExecuteNonQuery();
        }

        public virtual IEnumerable<T> Query<T>(string commandText, object param = null, IDbTransaction transaction = null)
        {
            return Connection.Query<T>(commandText, param, transaction);
        }

        public virtual int Execute(string commandText, object param = null, IDbTransaction transaction = null)
        {
            return Connection.Execute(commandText, param, transaction);
        }

        public virtual IDataReader ExecuteReader(string commandText, object param = null, IDbTransaction transaction = null)
        {
            return Connection.ExecuteReader(commandText, param, transaction);
        }

        public virtual T ExecuteScalar<T>(string commandText, object param = null, IDbTransaction transaction = null)
        {
            return Connection.ExecuteScalar<T>(commandText, param, transaction);
        }

        public virtual bool OpenTransaction()
        {
            Transaction = Connection.BeginTransaction();
            return Transaction != null;
        }

        public virtual void CommitTransaction()
        {
            Transaction.Commit();
            Transaction.Dispose();
            Transaction = null;
        }

        public virtual void RollbackTransaction()
        {
            Transaction.Rollback();
            Transaction.Dispose();
            Transaction = null;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing)
                return;

            Transaction?.Dispose();
            _dbProviderFactory = null;

            if (Connection == null)
                return;

            Connection.Close();
            Connection.Dispose();
        }

        public void Dispose()
        {
            Dispose(true);
        }

        internal virtual DbDataAdapter CreateDataAdapter()
        {
            return _dbProviderFactory.CreateDataAdapter();
        }

        public virtual DataTable GetSchema(string schemaName)
        {
            return ((DbConnection)Connection).GetSchema(schemaName);
        }
    }
}
