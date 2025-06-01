using System.Collections;
using System.Security.Authentication;
using cadastro;
using ia;
using pesquisa;
using System.Text.RegularExpressions;
using edit;



namespace software
{
    class Program
    {   
        //CRIAÇÃO DO MENU
        static async Task Main(string[] args)
        {   
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔════════════════════════════════════╗");
            Console.WriteLine("║   SISTEMA DE RECOMENDAÇÃO POR IA   ║");
            Console.WriteLine("╚════════════════════════════════════╝");
            Console.ResetColor();

            string opcao;

            do
            {   
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n----MENU PRINCIPAL----");
                Console.WriteLine("1 - CADASTRAR CLIENTE");
                Console.WriteLine("2 - CADASTRAR PACOTE");
                Console.WriteLine("3 - RECOMENDAR PACOTE (IA)");
                Console.WriteLine("4 - LISTAR CLIENTES");
                Console.WriteLine("5 - LISTAR PACOTES");
                Console.WriteLine("6 - BUSCAR POR CLIENTE");
                // Console.WriteLine("7 - BUSCAR PACOTE PELA ORIGEM");
                Console.WriteLine("7 - BUSCAR POR PACOTE");
                Console.WriteLine("8 - EDITAR CLIENTE");
                Console.WriteLine("0 - SAIR");
                Console.ResetColor();
                //editar pacote
                //editar cliente

                Console.WriteLine("Escolha uma opção: ");
                opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        cadastroCliente.Executar();
                        break;

                    case "2":
                        cadastroPacote.Executar();
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
                        string cpfBuscaCliente;

                        Regex regexCpf = new Regex(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$");

                        while (true)
                        {
                            Console.WriteLine("\nDigite o CPF do cliente ou pressione 0 para voltar ao menu principal: ");
                            cpfBuscaCliente = Console.ReadLine();

                            if (cpfBuscaCliente == "0")
                            {
                                Console.WriteLine("\nVOLTANDO AO MENU. . .");
                                break;
                            }

                            if (string.IsNullOrWhiteSpace(cpfBuscaCliente) || cpfBuscaCliente.Length != 14 || !regexCpf.IsMatch(cpfBuscaCliente))
                            {
                                Console.WriteLine("\nCPF INVÁLIDO ");
                                continue;
                            }

                            Console.WriteLine($"\nPESQUISANDO POR: {cpfBuscaCliente}");
                            buscarCliente.Executar(cpfBuscaCliente);
                            break;

                        }
                    break;

                    // case "7":
                    //     Console.WriteLine("Digite a origem do pacote: ");
                    //     string origem = Console.ReadLine();
                    //     buscarPacoteOrigem.Executar(origem);
                    //     break;

                    case "7":
                        string cidade;

                        while (true)
                        {
                            Console.WriteLine("Digite a cidade do pacote ou pressione 0 para voltar para o menu principal: ");
                            cidade = Console.ReadLine().ToUpper();

                            if (cidade == "0")
                            {
                                Console.WriteLine("\nVOLTANDO AO MENU. . .");
                                break;
                            }

                            if (string.IsNullOrWhiteSpace(cidade))
                            {
                                Console.WriteLine("\nCIDADE INVÁLIDA");
                                continue;
                            }
                            
                            Console.WriteLine($"\nPESQUISANDO POR: {cidade}");
                            buscarPacotesViagem.Executar(cidade);
                            break;


                        }
                        break;

                    case "8":

                        while (true)
                        {
                            Console.WriteLine("\nDigite o CPF do cliente que deseja editar ou pressione 0 para voltar para o menu principal: ");
                            cpfBuscaCliente = Console.ReadLine();

                            if (cpfBuscaCliente == "0")
                            {
                                Console.WriteLine("\nVOLTANDO AO MENU. . .");
                                break;
                            }

                            if (string.IsNullOrWhiteSpace(cpfBuscaCliente))
                            {
                                Console.WriteLine("\n CPF INVÁLIDO");
                                continue;
                            }

                            Console.WriteLine($"\nPESQUISANDO POR: {cpfBuscaCliente}");
                            buscarCliente.Executar(cpfBuscaCliente);
                            Console.WriteLine("\nNOVA PREFERÊNCIA: ");
                            string pref = Console.ReadLine().ToUpper();
                            Console.WriteLine($"\nATUALIZANDO PARA: {pref}");
                            editarCliente.Executar(cpfBuscaCliente, pref);
                            break;
                        }
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
