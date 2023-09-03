using Dapper;
using System.Data;
using System.Data.SqlClient;
using static Dapper.SqlMapper;

namespace ConnectionSql.Repositories
{
    public class BaseRepository
    {
        protected readonly string _connetionString;
        public Guid ConnectionId { get; private set; }

        private readonly bool _captureClientConnectionId = false;


        public BaseRepository(string connectionString, bool captureClientConnection = false) =>
              (_connetionString, _captureClientConnectionId) = (connectionString, captureClientConnection);
        protected async Task<int> ExecuteAsync(string query, object param = null, CommandType? commandType = null)
        {
            try
            {
                SqlConnection connection = new SqlConnection(_connetionString);
                connection.Open();

                GetClientConnection(connection);

                return await connection.ExecuteAsync(query, param, commandType: commandType);

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                var message = Task.FromResult(0);
                return await message;
            }

        }

        protected async Task<T> QueryFirstOrDefaultAsync<T>(string query, object param = null, CommandType? commandType = null)
        {
            using IDbConnection conn = new SqlConnection(_connetionString);
            conn.Open();

            GetClientConnection(conn);

            return await conn.QueryFirstOrDefaultAsync<T>(query, param, commandType: commandType);
        }

        protected async Task<IEnumerable<T>> QueryAsync<T>(string query, object param = null, CommandType? commandType = null)
        {
            using IDbConnection conn = new SqlConnection(_connetionString);
            conn.Open();

            GetClientConnection(conn);

            return await conn.QueryAsync<T>(query, param, commandType: commandType);
        }

        protected async Task<T> MultipleQueryAsync<T>(string query, Func<GridReader, Task<T>> mapearRetorno, object param = null, CommandType? commandType = null)
        {
            using IDbConnection conn = new SqlConnection(_connetionString);
            conn.Open();

            GetClientConnection(conn);

            using (var retorno = await conn.QueryMultipleAsync(query, param, commandType: commandType))
            {
                return await mapearRetorno(retorno);
            }
        }

        protected async Task<IEnumerable<T2>> QueryAsync<T, T1, T2>(string query, Func<T, T1, T2> map, object param = null, CommandType? commandType = null, string splitOn = "id")
        {
            using IDbConnection conn = new SqlConnection(_connetionString);
            conn.Open();
            GetClientConnection(conn);

            return await conn.QueryAsync(query, map, param: param, commandType: commandType, splitOn: splitOn);

        }

        protected async Task<IEnumerable<T3>> QueryAsync<T, T1, T2, T3>(string query, Func<T, T1, T2, T3> map, object param = null, CommandType? commandType = null, string splitOn = "id")
        {
            using IDbConnection conn = new SqlConnection(_connetionString);
            conn.Open();
            GetClientConnection(conn);

            return await conn.QueryAsync(query, map, param: param, commandType: commandType, splitOn: splitOn);

        }

        protected async Task<IEnumerable<T4>> QueryAsync<T, T1, T2, T3, T4>(string query, Func<T, T1, T2, T3, T4> map, object param = null, CommandType? commandType = null, string splitOn = "id")
        {
            using IDbConnection conn = new SqlConnection(_connetionString);
            conn.Open();
            GetClientConnection(conn);

            return await conn.QueryAsync(query, map, param: param, commandType: commandType, splitOn: splitOn);

        }

        private void GetClientConnection(IDbConnection conn)
        {
            if (_captureClientConnectionId)
                ConnectionId = (conn as SqlConnection).ClientConnectionId;
        }
    }
}

