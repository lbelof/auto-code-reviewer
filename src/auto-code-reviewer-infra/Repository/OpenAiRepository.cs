using auto_code_reviewer_infra.Interface;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;


namespace auto_code_reviewer_infra.Repository
{
    public class OpenAiRepository : IOpenAiRepository
    {
        
        private readonly string _apiKey;
        private readonly HttpClient _httpClient;

        public OpenAiRepository( IConfiguration configuration,HttpClient httpClient)
        {
            
            _apiKey = configuration["OpenAI:ApiKey"];
            _httpClient = httpClient;   
        }


        public async Task<string> AnalyzeCodeAsync(string prompt)
        {
            var requestBody = new
            {
                model = "gpt-3.5-turbo",
                messages = new[]
                       {
                new { role = "user", content = prompt }
            },
                temperature = 0.7
            };

            var content = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);

            var response = await _httpClient.PostAsync("https://api.openai.com/v1/chat/completions", content);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Erro ao chamar OpenAI: {response.StatusCode} - {errorContent}");
            }

            var responseString = await response.Content.ReadAsStringAsync();

            using var json = JsonDocument.Parse(responseString);
            var result = json.RootElement
                             .GetProperty("choices")[0]
                             .GetProperty("message")
                             .GetProperty("content")
                             .GetString();

            return result;
        }
    }
}
