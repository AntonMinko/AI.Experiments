using System.ClientModel;
using System.Text;
using OpenAI;
using OpenAI.Chat;
using Tiktoken;

namespace AI.Experiments.OpenAIProvider;

public class OpenAiClient(string apiKey)
{
    private readonly OpenAIClient _client = new(apiKey);

    public async Task<IReadOnlyList<string>> GetAvailableChatModels()
    {
        // var result = await _client.GetOpenAIModelClient().GetModelsAsync();
        // return result.Value.Select(model => model.Id).ToList();
        return ["gpt-5-nano", "gpt-5-mini", "gpt-5", "gpt-4.1", "gpt-4o"];
    }

    public OpenAiChatClient GetChatClient(string model = "gpt-4o") => new(model, _client.GetChatClient(model));
}
public class OpenAiChatClient(string model, ChatClient client)
{
    public async Task<string> SendChatMessage(string message, float temperature = 1.0f, float topP = 1.0f)
    {
        var options = new ChatCompletionOptions();
        if (model.StartsWith("gpt-4"))
        {
            options.Temperature = temperature;
            options.TopP = topP;
        }
        
        var chatMessage = new UserChatMessage(message);
        var completion = await client.CompleteChatAsync([chatMessage], options);
        
        WriteTokensUsed(completion);
        return completion.Value.Content[0].Text;
    }

    private static void WriteTokensUsed(ClientResult<ChatCompletion> completion)
    {
        var tokenUsage = completion.Value.Usage;
        Console.WriteLine($"-- Tokens used. Input: {tokenUsage.InputTokenCount}, Output: {tokenUsage.OutputTokenCount}, Total: {tokenUsage.TotalTokenCount}");
    }

    public async Task<string> SendChatConversation(List<ChatMessage> messages)
    {
        var completion = await client.CompleteChatAsync(messages);
        
        WriteTokensUsed(completion);
        return completion.Value.Content[0].Text;
    }

    public async IAsyncEnumerable<string> StreamChatMessage(string message, float temperature = 0.5f, float topP = 0.9f)
    {
        var options = new ChatCompletionOptions
        {
            Temperature = temperature,
            TopP = topP
        };

        var encoder = ModelToEncoder.For(model);
        var inputTokens = encoder.CountTokens(message);
        
        var updates = client.CompleteChatStreamingAsync([message], options);

        var output = new StringBuilder();
        await foreach (var update in updates)
        {
            foreach (var contentPart in update.ContentUpdate)
            {
                output.Append(contentPart);
                yield return contentPart.Text;
            }
        }
        
        var outputTokens = encoder.CountTokens(output.ToString());
        Console.WriteLine();
        Console.WriteLine($"-- Tokens used. Input: {inputTokens}, Output: {outputTokens}, Total: {inputTokens + outputTokens}");
    }
}