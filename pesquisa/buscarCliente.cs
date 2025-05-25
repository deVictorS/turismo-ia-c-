using System;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crypto.Engines;
using bancoDados;

namespace pesquisa
{
    public class buscarCliente
    {
        public static void Executar(string cpf2)
        {
            using var conn = DataBase.GetConnection();
            var cmd = conn.CreateCommand();

            cmd.CommandText = "SELECT * FROM cliente WHERE cpf = @cpf";
            cmd.Parameters.AddWithValue("@cpf", cpf2);

            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                Console.WriteLine("\n---CLIENTE ENCONTRADO---");
                Console.WriteLine($"ID: VAL{reader["id"]}");
                Console.WriteLine($"Nome: {reader["nome"]}");
            }
            else
            {
                Console.WriteLine("Cliente não encontrado");
            }
        } 
    }
}