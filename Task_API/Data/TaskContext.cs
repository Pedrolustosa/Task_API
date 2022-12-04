using System.Data;

namespace Task_API.Data
{
    public class TaskContext
    {
        public delegate Task<IDbConnection> GetConnection();
    }
}
