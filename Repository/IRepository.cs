using System.Data.SqlClient;

namespace ToDoList.Repository
{
    public interface IRepository
    {
        public SqlConnection GetConnection();
        public bool ExecuteQuery(string statement);
        public SqlDataReader FetchDataFromDB(string statement);
    }
}
