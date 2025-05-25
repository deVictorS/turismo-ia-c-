using MySql.Data.MySqlClient;
using DotNetEnv;

namespace bancoDados
{
    public class DataBase
    {
        private static string? connectionString;

        static DataBase()
        {
            Env.TraversePath().Load();

            string server = Environment.GetEnvironmentVariable("DB_SERVER");
            string user = Environment.GetEnvironmentVariable("DB_USER");
            string password = Environment.GetEnvironmentVariable("DB_PASSWORD");
            string database = Environment.GetEnvironmentVariable("DB_NAME");

            connectionString = $"server={server};user={user};password={password};database={database}";
        }


        public static MySqlConnection GetConnection()
        {
            var conn = new MySqlConnection(connectionString);
            conn.Open();
            return conn;
        }
    }
}
