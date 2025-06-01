using System;
using MySql.Data.MySqlClient;
using bancoDados;

namespace edit
{
    public class editarCliente
    {
        public static void Executar(string cpfBuscaCliente,string pref)
        {
            using var conn = DataBase.GetConnection();
            var cmd = conn.CreateCommand();

            cmd.CommandText = @"UPDATE cliente SET preferencias = @preferencias WHERE cpf = @cpf";

            cmd.Parameters.AddWithValue("@preferencias", pref);
            cmd.Parameters.AddWithValue("@cpf", cpfBuscaCliente);

            int resultado = cmd.ExecuteNonQuery();

            if (resultado > 0)
            {
                Console.WriteLine("\nCLIENTE ATUALIZADO COM SUCESSO!");
            }

            else
            {
                Console.WriteLine("\nERRO NA ATUALIZAÇÃO");
            }
        }
    }
}
