using System;
using MySql.Data.MySqlClient;

namespace software
{
    public class buscarPacoteOrigem
    {
        public static void Executar(string origem)
        {
            using var conn = DataBase.GetConnection();
            var cmd = conn.CreateCommand();

            cmd.CommandText = "SELECT * FROM pacote WHERE origem = @origem";
            cmd.Parameters.AddWithValue("@origem", origem);

            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                Console.WriteLine("\n---PACOTES ENCONTRADOS---");
                Console.WriteLine($"ID: TUR{reader["id"]}");
                Console.WriteLine($"Origem: {reader["origem"]}");
                Console.WriteLine($"Destino: {reader["destino"]}");
            }
            else
            {
                Console.WriteLine("Pacote não encontrado");
            }

        }
    }
}
