using System;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Misc;
using Org.BouncyCastle.Cms;
using PhoneNumbers;
using bancoDados;

namespace cadastro
{
    public class cadastroCliente
    {
        public string Nome { get; set; }
        public string Genero { get; set; }
        public string Nacionalidade { get; set; }
        public string Telefone { get; set; }
        public string dataNasc { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string Passaporte { get; set; }
        public string CEP { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
        public string Preferencias { get; set; }


        public static void Executar()
        {
            cadastroCliente cliente = new cadastroCliente();

            Console.WriteLine("\n---DADOS DO CLIENTE---");

            Console.WriteLine($"Nome completo do cliente: ");
            cliente.Nome = Console.ReadLine().ToUpper();

            Console.WriteLine("Gênero (M/F/I): ");
            cliente.Genero = Console.ReadLine().ToUpper();

            Console.WriteLine("Nacionalidade: ");
            cliente.Nacionalidade = Console.ReadLine().ToUpper();

            Console.WriteLine("Telefone (+xx(xx)xxxxx-xxxx): ");
            cliente.Telefone = Console.ReadLine();

            Console.WriteLine("Data de nascimento (xx/xx/xxxx): ");
            cliente.dataNasc = Console.ReadLine();

            Console.WriteLine("CPF (xxx.xxx.xxx-xx): ");
            cliente.CPF = Console.ReadLine();

            Console.WriteLine("RG (xx-xx.xxx.xxx): ");
            cliente.RG = Console.ReadLine().ToUpper();

            Console.WriteLine("Passaporte (somente números): ");
            cliente.Passaporte = Console.ReadLine().ToUpper();

            Console.WriteLine("CEP (xxxxx-xxx): ");
            cliente.CEP = Console.ReadLine();

            Console.WriteLine("Rua: ");
            cliente.Rua = Console.ReadLine().ToUpper();

            Console.WriteLine("Bairro: ");
            cliente.Bairro = Console.ReadLine().ToUpper();

            Console.WriteLine("Complemento: ");
            cliente.Complemento = Console.ReadLine().ToUpper();

            Console.WriteLine("Cidade: ");
            cliente.Cidade = Console.ReadLine().ToUpper();

            Console.WriteLine("Estado (sem abreviações): ");
            cliente.Estado = Console.ReadLine().ToUpper();

            Console.WriteLine("País: ");
            cliente.Pais = Console.ReadLine().ToUpper();

            Console.WriteLine("Preferências de viagem (palavras-chave): ");
            cliente.Preferencias = Console.ReadLine().ToUpper();



            Console.WriteLine("\n---CLIENTE CADASTRADO COM SUCESSO---");

            Console.WriteLine($"Nome completo: {cliente.Nome}");

            Console.WriteLine($"Gênero: {cliente.Genero}");

            Console.WriteLine($"Nacionalidade: {cliente.Nacionalidade}");

            Console.WriteLine($"Telefone: {cliente.Telefone}");

            Console.WriteLine($"Data de nascimento: {cliente.dataNasc}");

            Console.WriteLine($"CPF: {cliente.CPF}");

            Console.WriteLine($"RG: {cliente.RG}");

            Console.WriteLine($"Passaporte: {cliente.Passaporte}");

            Console.WriteLine($"CEP: {cliente.CEP}");

            Console.WriteLine($"Rua: {cliente.Rua}");

            Console.WriteLine($"Bairro: {cliente.Bairro}");

            Console.WriteLine($"Complemento: {cliente.Complemento}");

            Console.WriteLine($"Cidade: {cliente.Cidade}");

            Console.WriteLine($"Estado: {cliente.Estado}");

            Console.WriteLine($"País: {cliente.Pais}");

            Console.WriteLine($"Preferências de viagem: {cliente.Preferencias}");

            cliente.SalvarNoBanco();


        }

        public void SalvarNoBanco()
        {
            using var conn = DataBase.GetConnection();
            var cmd = conn.CreateCommand();

            cmd.CommandText = @"INSERT INTO cliente
                (nome, genero, nacionalidade, telefone, dataNasc, cpf, rg, passaporte, cep, rua, bairro, complemento, cidade, estado, pais, preferencias)
                VALUES
                (@nome, @genero, @nacionalidade, @telefone, @dataNasc, @cpf, @rg, @passaporte, @cep, @rua, @bairro, @complemento, @cidade, @estado, @pais, @preferencias)";

            cmd.Parameters.AddWithValue("@nome", Nome);
            cmd.Parameters.AddWithValue("@genero", Genero);
            cmd.Parameters.AddWithValue("@Nacionalidade", Nacionalidade);
            cmd.Parameters.AddWithValue("@telefone", Telefone);
            cmd.Parameters.AddWithValue("@dataNasc", dataNasc);
            cmd.Parameters.AddWithValue("@cpf", CPF);
            cmd.Parameters.AddWithValue("@rg", RG);
            cmd.Parameters.AddWithValue("@passaporte", Passaporte);
            cmd.Parameters.AddWithValue("@cep", CEP);
            cmd.Parameters.AddWithValue("@rua", Rua);
            cmd.Parameters.AddWithValue("@bairro", Bairro);
            cmd.Parameters.AddWithValue("@complemento", Complemento);
            cmd.Parameters.AddWithValue("@cidade", Cidade);
            cmd.Parameters.AddWithValue("@estado", Estado);
            cmd.Parameters.AddWithValue("@pais", Pais);
            cmd.Parameters.AddWithValue("@preferencias", Preferencias);

            cmd.ExecuteNonQuery();

            Console.WriteLine($"ID do cliente: VAL{cmd.LastInsertedId}");

    
        }
    }
}
