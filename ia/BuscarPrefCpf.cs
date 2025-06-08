using System;
using MySql.Data.MySqlClient;
using bancoDados;

namespace ia;

public class BuscarPrefCpf
{
    // Retorna uma tupla com nome, preferencias e telefone ou null se não encontrar
    public static (string? nome, string? preferencias, string? cidade)? Executar(string cpf)
    {
        using var conn = DataBase.GetConnection();
        var cmd = conn.CreateCommand();

        cmd.CommandText = "SELECT nome, preferencias, cidade FROM cliente WHERE cpf = @cpf";
        cmd.Parameters.AddWithValue("@cpf", cpf);

        using var reader = cmd.ExecuteReader();

        if (reader.Read())
        {
            string? nome = reader["nome"]?.ToString();
            string? preferencias = reader["preferencias"]?.ToString();
            string? cidade = reader["cidade"]?.ToString();

            return (nome, preferencias, cidade);
        }

        return null;
    }
}
