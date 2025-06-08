using System;
using MySql.Data.MySqlClient;
using bancoDados;

namespace pesquisa
{   
    public class buscarPacotesViagem
    {
        public static void Executar(string cidade)
        {
            using var conn = DataBase.GetConnection();
            var cmd = conn.CreateCommand();

            cmd.CommandText = "SELECT * FROM pacote WHERE destino = @destino OR origem = @destino OR id = @id";
            cmd.Parameters.AddWithValue("@destino", cidade);

            // tenta converter para inteiro se possível
            if (int.TryParse(cidade, out int idConvertido))
                cmd.Parameters.AddWithValue("@id", idConvertido);
            else
                cmd.Parameters.AddWithValue("@id", -1); // valor impossível para garantir que não quebre

            using var reader = cmd.ExecuteReader();

            bool encontrou = false;

            while (reader.Read())
            {
                encontrou = true;

                Console.WriteLine("\n---PACOTE ENCONTRADO---");
                Console.WriteLine($"ID: TUR{reader["id"]}");
                Console.WriteLine($"ORIGEM: {reader["origem"]}");
                Console.WriteLine($"DESTINO: {reader["destino"]}");
                Console.WriteLine($"DATA DE IDA: {reader["dataIda"]}");
                Console.WriteLine($"HORA DE IDA: {reader["horaIda"]}");
                Console.WriteLine($"DATA DE RETORNO: {reader["dataVolta"]}");
                Console.WriteLine($"HORA DE RETORNO: {reader["horaVolta"]}");
                Console.WriteLine($"VALOR: {reader["valor"]}");
                Console.WriteLine($"PARCELAMENTO: {reader["parcelamento"]}x");
                Console.WriteLine($"DESCRIÇÃO: {reader["descricao"]}");
                Console.WriteLine("----------------------------------------------------------------------------------");
            }

            if (!encontrou)
            {
                Console.WriteLine("\nSEM PACOTES DISPONÍVEIS OU NÃO ENCONTRADO. TENTE NOVAMENTE.");
            }
        }
    }
}
