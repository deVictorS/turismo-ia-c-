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
            cmd.CommandText = "SELECT * FROM pacote";

            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var id = reader["id"].ToString();
                var origem = reader["origem"].ToString();
                var destino = reader["destino"].ToString();
                var dataIda = reader["dataIda"].ToString();
                var horaIda = reader["horaIda"].ToString();
                var dataVolta = reader["dataVolta"].ToString();
                var horaVolta = reader["horaVolta"].ToString();
                var valor = reader["valor"].ToString();
                var parcelamento = reader["parcelamento"].ToString(); // supondo que "duracao" indica número de parcelas
                var descricao = reader["descricao"].ToString();
                descricoes.Add($"ID: TUR{id} -> {origem} para {destino} | Ida: {dataIda} às {horaIda} | Volta: {dataVolta} às {horaVolta} | Valor: {valor} | Parcelamento: {parcelamento}x | Descrição: {descricao}");

            }

            return descricoes;
        }
    }
}
