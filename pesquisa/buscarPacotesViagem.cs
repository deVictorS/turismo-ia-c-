using System;
using MySql.Data.MySqlClient;
using bancoDados;

namespace pesquisa
{   
    //PESQUISA NO BANCO POR ORIGEM E DESTINOS
    public class buscarPacotesViagem
    {
        public static void Executar(string cidade)
        {
            using var conn = DataBase.GetConnection();
            var cmd = conn.CreateCommand();

            cmd.CommandText = "SELECT id, origem, destino FROM pacote WHERE destino = @destino OR origem = @destino";
            cmd.Parameters.AddWithValue("@destino", cidade);
            cmd.Parameters.AddWithValue("@origem", cidade);

            using var reader = cmd.ExecuteReader();

            bool encontrou = false;

            while (reader.Read())
            {

                if (!encontrou)
                {
                    Console.WriteLine("\n---PACOTE ENCONTRADO---");
                    Console.WriteLine($"ID: TUR{reader["id"]}");
                    Console.WriteLine($"ORIGEM: {reader["origem"]}");
                    Console.WriteLine($"DESTINO: {reader["destino"]}");
                    Console.WriteLine("-------------------------");
                }
                else
                {
                    Console.WriteLine("\nSEM PACOTES DISPONÍVEIS");
                }
            }
        }
    }
}