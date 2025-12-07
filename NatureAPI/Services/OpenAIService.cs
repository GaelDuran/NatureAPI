using OpenAI.Chat;
using OpenAI;

namespace NatureAPI.Services
{
    public class OpenAIService
    {
        private readonly IConfiguration _config;

        public OpenAIService(IConfiguration config)
        {
            _config = config;
        }

        public async Task<string> SummarizePlace(string name, string description)
        {
            var openAIKey = _config["OpenAIKey"];
            var client = new ChatClient(
                model: "gpt-5-mini",
                apiKey: openAIKey
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