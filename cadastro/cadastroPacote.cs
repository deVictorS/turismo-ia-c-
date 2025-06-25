using System;
using MySql.Data.MySqlClient;
using bancoDados;

namespace cadastro
{
    public class cadastroPacote
    {
        public string Origem { get; set; }
        public string Destino { get; set; }
        public string DataIda { get; set; }
        public string HoraIda { get; set; }
        public string DataVolta { get; set; }
        public string HoraVolta { get; set; }
        public string Valor { get; set; }
        public string Parcelamento { get; set; }
        public string Desc { get; set; }
        
        public static void Executar()
        {

            cadastroPacote pacote = new cadastroPacote();

            Console.WriteLine("\n---DADOS DO PACOTE---");

            Console.WriteLine("Origem: ");
            pacote.Origem = Console.ReadLine().ToUpper();

            Console.WriteLine("Destino: ");
            pacote.Destino = Console.ReadLine().ToUpper();

            Console.WriteLine("Data de ida (XX/XX/XX): ");
            pacote.DataIda = Console.ReadLine();

            Console.WriteLine("Hora de ida (xx:xx): ");
            pacote.HoraIda = Console.ReadLine();

            Console.WriteLine("Data de retorno (XX/XX/XX): ");
            pacote.DataVolta = Console.ReadLine();

            Console.WriteLine("Hora de retorno (xx:xx): ");
            pacote.HoraVolta = Console.ReadLine();

            Console.WriteLine("Valor do pacote (R$X,XX): ");
            pacote.Valor = Console.ReadLine();

            Console.WriteLine("Parcelamento (somente números): ");
            pacote.Parcelamento = Console.ReadLine();

            Console.WriteLine("Descrição do pacote (palavras-chave): ");
            pacote.Desc = Console.ReadLine().ToUpper();


            Console.WriteLine("\n---PACOTE CADASTRADO COM SUCESSO---");

            Console.WriteLine($"Origem: {pacote.Origem}");

            Console.WriteLine($"Destino: {pacote.Destino}");

            Console.WriteLine($"Data e hora de ida: {pacote.DataIda} - {pacote.HoraIda}");

            Console.WriteLine($"Data e hora de retorno: {pacote.DataVolta} - {pacote.HoraVolta}");

            Console.WriteLine($"Valor do pacote e parcelamento: {pacote.Valor} - {pacote.Parcelamento}");

            Console.WriteLine($"Descrição do pacote: {pacote.Desc}");

            pacote.SalvarNoBanco();




        }

        public void SalvarNoBanco()
        {
            using var conn = DataBase.GetConnection();
            var cmd = conn.CreateCommand();

            cmd.CommandText = @"INSERT INTO pacote
                (origem, destino, dataIda, horaIda, dataVolta, horaVolta, valor, parcelamento, descricao)
                VALUES
                (@origem, @destino, @dataIda, @horaIda, @dataVolta, @horaVolta, @valor, @parcelamento, @descricao)";

            cmd.Parameters.AddWithValue("@origem", Origem);
            cmd.Parameters.AddWithValue("@destino", Destino);
            cmd.Parameters.AddWithValue("@dataIda", DataIda);
            cmd.Parameters.AddWithValue("@horaIda", HoraIda);
            cmd.Parameters.AddWithValue("@dataVolta", DataVolta);
            cmd.Parameters.AddWithValue("@horaVolta", HoraVolta);
            cmd.Parameters.AddWithValue("@valor", Valor);
            cmd.Parameters.AddWithValue("@parcelamento", Parcelamento);
            cmd.Parameters.AddWithValue("@descricao", Desc);

            cmd.ExecuteNonQuery();

            Console.WriteLine($"ID do pacote: TUR{cmd.LastInsertedId}");
                

        }
    }
}