using bancoDados;

namespace pesquisa
{
    public class buscarCliente
    {
        public static void Executar(string cpfBuscaCliente)
        {
            using var conn = DataBase.GetConnection();
            var cmd = conn.CreateCommand();

            cmd.CommandText = "SELECT id, nome, cpf, preferencias FROM cliente WHERE cpf = @cpf";
            cmd.Parameters.AddWithValue("@cpf", cpfBuscaCliente);

            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                Console.WriteLine("\n---CLIENTE ENCONTRADO---");
                Console.WriteLine($"ID: VAL{reader["id"]}");
                Console.WriteLine($"NOME: {reader["nome"]}");
                Console.WriteLine($"CPF: {reader["cpf"]}");
                Console.WriteLine($"PREFERÊNCIAS: {reader["preferencias"]}");
            }
            else
            {
                Console.WriteLine("\nCLIENTE NÃO ENCONTRADO");
            }
        } 
    }
}