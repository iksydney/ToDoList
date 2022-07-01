using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace ToDoList.Repository
{
    public class Repositorry : IRepository 
    {
        private readonly string _dbConnection;
        public Repositorry(IConfiguration configure)
        {
            _dbConnection = configure.GetSection("Data-connection:Path").Value;
        }
        public bool ExecuteQuery(string statement)
        {
            var con = GetConnection();
            try
            {
                con.Open();
                using (var cmd = new SqlCommand(statement, con))
                {
                    var res = cmd.ExecuteNonQuery();
                    if (res > 0)
                        return true;
                    else
                        return false;
                }
            }
            finally
            {
                con.Close();
            }
        }
        public SqlDataReader FetchDataFromDB(string statement)
        {
            var con = GetConnection();
            con.Open();
            using (var cmd = new SqlCommand(statement, con))
            {
                var rows = cmd.ExecuteReader();
                return rows;
            }
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(_dbConnection);
        }
    }
}

