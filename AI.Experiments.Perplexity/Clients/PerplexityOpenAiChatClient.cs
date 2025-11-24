using System.Text;
using tryAGI.OpenAI;

namespace AI.Experiments.Perplexity.Clients;

public class PerplexityClient(string apiKey)
{
    private readonly OpenAiClient _api = CustomProviders.Perplexity(apiKey);

    public async Task<IReadOnlyList<string>> GetAvailableChatModels()
    {
        
        return ["sonar", "sonar-pro", "sonar-reasoning"];
    }

    public PerplexityChatService GetChat(string model = "sonar") => new(model, apiKey);
    public PerplexityOpenAiChatClient GetOpenAiChatClient(string model = "sonar-pro") => new(model, _api.Chat);
}
public class PerplexityOpenAiChatClient(string model, ChatClient client)
{
    public async Task<string> SendChatMessage(string message, float temperature = 1.0f, float topP = 1.0f)
    {
        var request = new CreateChatCompletionRequest
        {
            Model = model,
            Messages = [message],
            Temperature = temperature,
            TopP = topP,
        };
        var completion = await client.CreateChatCompletionAsync(request);
        
        WriteTokensUsed(completion);
        return completion.Choices.First().Message.Content!;
    }
    
    private static void WriteTokensUsed(CreateChatCompletionResponse completion)
    {
        var tokenUsage = completion.Usage!;
        Console.WriteLine($"-- Tokens used. Input: {tokenUsage.PromptTokens}, Output: {tokenUsage.CompletionTokens}, Total: {tokenUsage.TotalTokens}");
    }

    public async IAsyncEnumerable<string> StreamChatMessage(string message, float temperature = 0.5f, float topP = 0.9f)
    {
        var request = new CreateChatCompletionRequest
        {
            Model = model,
            Messages = [message],
            Temperature = temperature,
            TopP = topP,
        };
        var updates = client.CreateChatCompletionAsStreamAsync(request);
    
        var output = new StringBuilder();
        await foreach (var update in updates)
        {
            var contentPart = update.Choices[0].Delta.Content!;
            output.Append(contentPart);
            yield return contentPart;
        }
    }
}