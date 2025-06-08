using bancoDados;

namespace pesquisa
{
    public class buscarCliente
    {
        public static void Executar(string cpfBuscaCliente)
        {
            using var conn = DataBase.GetConnection();
            var cmd = conn.CreateCommand();

            cmd.CommandText = "SELECT * FROM cliente WHERE cpf = @cpf";
            cmd.Parameters.AddWithValue("@cpf", cpfBuscaCliente);

            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                Console.WriteLine("\n---CLIENTE ENCONTRADO---");
                Console.WriteLine($"ID: VAL{reader["id"]}");
                Console.WriteLine($"NOME: {reader["nome"]}");
                Console.WriteLine($"GÊNERO: {reader["genero"]}");
                Console.WriteLine($"NACIONALIDADE: {reader["nacionalidade"]}");
                Console.WriteLine($"TELEFONE: {reader["telefone"]}");
                Console.WriteLine($"DATA DE NASCIMENTO: {reader["dataNasc"]}");
                Console.WriteLine($"CPF: {reader["cpf"]}");
                Console.WriteLine($"RG: {reader["rg"]}");
                Console.WriteLine($"PASSAPORTE: {reader["passaporte"]}");
                Console.WriteLine($"CEP: {reader["cep"]}");
                Console.WriteLine($"RUA: {reader["rua"]}");
                Console.WriteLine($"BAIRRO: {reader["bairro"]}");
                Console.WriteLine($"COMPLEMENTO: {reader["complemento"]}");
                Console.WriteLine($"CIDADE: {reader["cidade"]}");
                Console.WriteLine($"ESTADO: {reader["estado"]}");
                Console.WriteLine($"PAÍS: {reader["pais"]}");
                Console.WriteLine($"PREFERÊNCIAS: {reader["preferencias"]}");
            }
            else
            {
                Console.WriteLine("\nCLIENTE NÃO ENCONTRADO. TENTE NOVAMENTE");
            }
        } 
    }
}