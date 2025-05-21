using System;
using System.Threading.Tasks;


namespace software
{
    class Program
    {
        static async Task Main(string[] args)
        {

            string opcao;

            do
            {
                Console.WriteLine("\n---MENU PRINCIPAL---");
                Console.WriteLine("1 - CADASTRAR CLIENTE");
                Console.WriteLine("2 - CADASTRAR PACOTE");
                Console.WriteLine("3 - RECOMENDAR PACOTE (IA)");
                Console.WriteLine("4 - LISTAR CLIENTES");
                Console.WriteLine("5 - LISTAR PACOTES");
                Console.WriteLine("6 - BUSCAR CLIENTE");
                Console.WriteLine("7 - BUSCAR PACOTE PELA ORIGEM");
                Console.WriteLine("8 - BUSCAR PACOTE PELO DESTINO");
                Console.WriteLine("0 - SAIR");

                opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        dadosCliente.Executar();
                        break;

                    case "2":
                        dadosPacote.Executar();
                        break;

                    case "3":
                        Console.WriteLine("Digite o CPF do cliente: ");
                        string cpf = Console.ReadLine();

                        string Preferencias = BuscarPrefCpf.Executar(cpf);

                        Console.WriteLine($"\n---PREFERÊNCIAS DO CLIENTE---: {Preferencias}");

                        string recomendacao = await RecomendadorIA.Executar(Preferencias);
                        Console.WriteLine($"\n---RECOMENDAÇÃO DA IA---: {recomendacao}");
                        break;

                    case "4":
                        listarClientes.Executar();
                        break;

                    case "5":
                        listarPacotes.Executar();
                        break;

                    case "6":
                        Console.WriteLine("Digite o CPF do cliente: ");
                        string cpf2 = Console.ReadLine();
                        buscarCliente.Executar(cpf2);
                        break;

                    case "7":
                        Console.WriteLine("Digite a origem do pacote: ");
                        string origem = Console.ReadLine();
                        buscarPacoteOrigem.Executar(origem);
                        break;

                    case "8":
                        Console.WriteLine("Digite o destino do pacote: ");
                        string destino = Console.ReadLine();
                        buscarPacoteDestino.Executar(destino);
                        break;             

                    case "0":
                        Console.WriteLine("ENCERRANDO O PROGRAMA. . .");
                        break;

                    default:
                        Console.WriteLine("OPÇÃO INVÁLIDA. TENTE NOVAMENTE.");
                        break;

                }
            } while (opcao != "0");

            Console.WriteLine("PROGRAMA FINALIZADO.");

        }
    }
}
