using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConnectionSql
{
    public class ConxaoSql
    {
        public string _connectionString;
        protected Guid _connectionID { get; set; }
        public bool _getClientConnectionID = false;

        public ConxaoSql(string connectionString,  bool getconnectionClientID = false)
        {
            _connectionString = connectionString;
            _getClientConnectionID = getconnectionClientID;
        }

        protected async Task<int> ExecuteAsync(string query, object param = null, CommandType? commandType = null)
        {
            try
            {
                SqlConnection connection = new SqlConnection(_connectionString);
                connection.Open();

                GetClientConnection(connection);

                return await ExecuteAsync(query, param, commandType: commandType);

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        protected async Task<T> QueryFirsOrDefaultAsync<T>(string query, object param = null, CommandType? commandType = null)
        {
            try
            {
                SqlConnection connection = new SqlConnection(_connectionString);
                connection.Open();

                GetClientConnection(connection);

                return await QueryFirsOrDefaultAsync<T>(query, param, commandType: commandType);
            }
            catch (Exception)
            {

                throw;
            }
        } 

        protected async Task<IEnumerable<T>> QueryAsync<T>(string query, object param = null, CommandType? commandType= null)
        {
            try
            {
                using SqlConnection connection = new SqlConnection(_connectionString);
                connection.Open();
                
                GetClientConnection(connection);

                return await QueryAsync<T>(query, param:param, commandType: commandType);

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected async Task<T>MultipleQueryAsync<T>(string query, object param = null, CommandType? commandType = null)
        {
            try
            {
               using SqlConnection connection = new SqlConnection(_connectionString);
                connection.Open();  
                GetClientConnection(connection);

                return await MultipleQueryAsync<T>( query, param, commandType: commandType);
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void GetClientConnection(IDbConnection connection)
        {
            if (_getClientConnectionID)
                _connectionID = (connection as SqlConnection).ClientConnectionId;
        }
    }
}
