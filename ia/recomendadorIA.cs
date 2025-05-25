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
        public static async Task<string> Executar(string Preferencias)
        {
            if (string.IsNullOrWhiteSpace(Preferencias))
            {
                Console.WriteLine("Preferências inválidas.");
                return "Preferências do cliente não foram informadas corretamente.";
            }

            Env.TraversePath().Load();
            string apiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY");

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

            var prompt = $"Com base nas preferências de viagem: '{Preferencias}', recomende o pacote ideal entre as seguintes opções:\n{todasDescricoes}";

            var requestBody = new
            {
                model = "gpt-4o",
                messages = new[]
                {
                    new { role = "system", content = "Você é um especialista em turismo que recomenda pacotes baseados em preferências de viagem." },
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

                string resultado = doc.RootElement
                    .GetProperty("choices")[0]
                    .GetProperty("message")
                    .GetProperty("content")
                    .GetString();

                return resultado.Trim();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao consultar a IA: " + ex.Message);
                return "Erro ao gerar recomendação.";
            }
        }
    }
}
