using MySql.Data.MySqlClient;

namespace _04_PersistenciaDatos
{
    public class MySQLConnectionSingleton
    {
        private static MySQLConnectionSingleton instance = null;
        private string connectionString;

        private MySQLConnectionSingleton(string server, string database, string user, string password)
        {
            connectionString = $"Server={server};Database={database};User ID={user};Password={password};";
        }

        public static MySQLConnectionSingleton Instance(string server, string database, string user, string password)
        {
            if (instance == null)
            {
                instance = new MySQLConnectionSingleton(server, database, user, password);
            }
            return instance;
        }

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}
