using System;
using DotNetEnv;
using MySql.Data.MySqlClient;

namespace pesquisa
{
    public class listarPacotes
    {
        public static void Executar()
        {
            Env.TraversePath().Load();

            string server = Environment.GetEnvironmentVariable("DB_SERVER") ?? throw new InvalidOperationException("DB_SERVER environment variable is not set.");
            string user = Environment.GetEnvironmentVariable("DB_USER") ?? throw new InvalidOperationException("DB_USER environment variable is not set.");
            string password = Environment.GetEnvironmentVariable("DB_PASSWORD") ?? throw new InvalidOperationException("DB_PASSWORD environment variable is not set.");
            string database = Environment.GetEnvironmentVariable("DB_NAME") ?? throw new InvalidOperationException("DB_NAME environment variable is not set.");

            string connectionString = $"server={server};user={user};password={password};database={database}";

            string sql = "SELECT * FROM pacote";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine("\nTUR" + reader["id"] + " -> " + "Origem: " + reader["origem"] + " | " + "Destino: " + reader["destino"] + " | " + "Valor: " + reader["valor"] + " | " + "Descrição: " + reader["descricao"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
            }
        }
    }
}