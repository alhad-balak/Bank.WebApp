using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;


namespace DataAccessLibrary
{
    public class SQLDataAccess : ISQLDataAccess
    {
        private readonly IConfiguration _config;
        public string ConnectionName { get; set; } = "Default";
        public SQLDataAccess(IConfiguration config)
        {
            _config = config;
        }

        public List<T> Load<T, U>(string sql, U parameter)
        {
            string connectionstring = _config.GetConnectionString(ConnectionName)!;
            using (IDbConnection connection = new SqlConnection(connectionstring))
            {
                var data = connection.Query<T>(sql, parameter); //'sql' is a Query that we'll provide and 'parameter' is those data which is provided.
                return data.ToList();
            }
        }

        public async Task Save<T>(string Query, T parameter)
        {
            string connectionstring = _config.GetConnectionString(ConnectionName)!;
            using (IDbConnection connection = new SqlConnection(connectionstring))
            {
                await connection.ExecuteAsync(Query, parameter);
            }
        }
    }
    public interface ISQLDataAccess
    {
        List<T> Load<T, U>(string sql, U parameter);
        Task Save<T>(string Query, T parameter);
    }
}
