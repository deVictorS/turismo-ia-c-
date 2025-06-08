using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using DotNetEnv;
using bancoDados;

namespace ia
{
    public class RecomendadorIA
    {
        public static async Task<string> Executar(string nomeCliente, string preferencias, string cidadeCliente)
        {
            if (string.IsNullOrWhiteSpace(preferencias))
            {
                Console.WriteLine("Preferências inválidas.");
                return "Preferências do cliente não foram informadas corretamente.";
            }

            Env.TraversePath().Load();
            string? apiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY");
            if (string.IsNullOrWhiteSpace(apiKey))
            {
                Console.WriteLine("Chave de API OpenAI não encontrada.");
                return "Erro: Chave de API OpenAI não configurada.";
            }

            // Buscar os pacotes do banco
            var pacotes = PacoteDAO.BuscarDescricoesPacotes();
            if (pacotes.Count == 0)
            {
                return "Nenhum pacote disponível para recomendação.";
            }

            string todasDescricoes = string.Join("\n", pacotes);

            using var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", apiKey);

            var prompt = $"Com base nas preferências de viagem: '{preferencias}', recomende o pacote ideal para '{nomeCliente}' habitante de '{cidadeCliente}' entre as seguintes opções:\n{todasDescricoes}";

            var requestBody = new
            {
                model = "gpt-4o",
                messages = new[]
                {
                    new { role = "system", content = "Você é uma assistente de viagens inteligente da Valoures Turismo, uma empresa especializada em criar experiências personalizadas e inesquecíveis. Com base nas preferências do cliente, analise os dados recebidos e recomende o pacote de viagem ideal, destacando os pontos mais atrativos da oferta, como destino, clima, atrações, custo-benefício e diferenciais exclusivos. Sua linguagem deve ser profissional, empática, entusiasmada e voltada à conversão, como se estivesse fazendo uma apresentação de vendas personalizada. Use um tom leve e envolvente, mostre que entende os desejos do cliente e que a Valoures está pronta para transformar sua próxima viagem em algo memorável. Ao final, incentive o cliente a entrar em contato para reservar ou tirar dúvidas, mantendo o padrão de excelência da marca Valoures. Engaje o cliente e escreva os textos todos formatados. É muit importante considerar a localização do cliente (cidade) para recomendar com prioridade o pacote com origem na sua cidade ou próxima a sua localização"},
                    new { role = "user", content = prompt }
                }
            };

            var jsonRequest = JsonSerializer.Serialize(requestBody);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            try
            {
                var response = await client.PostAsync("https://api.openai.com/v1/chat/completions", content);
                response.EnsureSuccessStatusCode();

                var responseString = await response.Content.ReadAsStringAsync();
                using var doc = JsonDocument.Parse(responseString);

                string? resultado = doc.RootElement
                    .GetProperty("choices")[0]
                    .GetProperty("message")
                    .GetProperty("content")
                    .GetString();

                return string.IsNullOrWhiteSpace(resultado) ? "\nNão foi possível obter recomendação" : resultado.Trim();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao consultar a IA: " + ex.Message);
                return "Erro ao gerar recomendação.";
            }
        }
    }
}
