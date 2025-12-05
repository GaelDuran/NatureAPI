using OpenAI.Chat;
using OpenAI;

namespace NatureAPI.Services
{
    public class OpenAIService
    {
        private readonly string _apiKey;

        public OpenAIService(IConfiguration config)
        {
            _apiKey = config["OpenAI:ApiKey"] 
                      ?? throw new ArgumentNullException("OpenAI:ApiKey");
        }

        public async Task<string> SummarizePlace(string name, string description)
        {
            var client = new ChatClient(
                model: "gpt-5-mini",
                apiKey: _apiKey
            );

            var prompt = 
                $"Genera un resumen turístico breve y atractivo del lugar '{name}'. " +
                $"Descripción: {description}";

            var result = await client.CompleteChatAsync([
                new UserChatMessage(prompt)
            ]);

            return result.Value.Content[0].Text;
        }
    }
}