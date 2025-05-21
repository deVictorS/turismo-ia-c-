using System;
using MySql.Data.MySqlClient;

namespace software;

public class BuscarPrefCpf
{
    public static string Executar(string cpf)
    {
        using var conn = DataBase.GetConnection();
        var cmd = conn.CreateCommand();

        cmd.CommandText = "SELECT preferencias FROM cliente WHERE cpf = @cpf";
        cmd.Parameters.AddWithValue("@cpf", cpf);

        using var reader = cmd.ExecuteReader();

        return reader.Read()? reader["preferencias"].ToString() : null;
    }
    
}
