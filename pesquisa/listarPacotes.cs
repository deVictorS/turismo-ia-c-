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

            string server = Environment.GetEnvironmentVariable("DB_SERVER");
            string user = Environment.GetEnvironmentVariable("DB_USER");
            string password = Environment.GetEnvironmentVariable("DB_PASSWORD");
            string database = Environment.GetEnvironmentVariable("DB_NAME");

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