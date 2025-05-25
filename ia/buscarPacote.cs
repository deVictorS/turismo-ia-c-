using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using bancoDados;

namespace ia
{
    public class PacoteDAO
    {
        public static List<string> BuscarDescricoesPacotes()
        {
            var descricoes = new List<string>();

            using var conn = DataBase.GetConnection();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT origem, destino, descricao FROM pacote";

            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var origem = reader["origem"].ToString();
                var destino = reader["destino"].ToString();
                var descricao = reader["descricao"].ToString();
                descricoes.Add($"{origem} para {destino}: {descricao}");
            }

            return descricoes;
        }
    }
}
