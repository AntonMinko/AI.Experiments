using AI.Experiments.Perplexity.Clients;
using AI.Experiments.Perplexity.Models;

namespace AI.Experiments.Perplexity;

public class PerplexityChatService(string model, string apiKey)
{
    private readonly PerplexityChatClient _client = new(model, apiKey);
    
    public async Task<string> Send(string message)
    {
        var request = new SendChatMessageRequest(
            Model: model,
            Messages: [new Message(PerplexityChatClient.DefaultRole, message)],
            Stream: false
        );

        var response = await _client.SendChatMessage(request);

        var usage = response.Usage;
        Console.WriteLine($"-- Tokens used. Input: {usage.PromptTokens}, Output: {usage.CompletionTokens}, Total: {usage.TotalTokens}");

        return response.Choices.First().Message.Content;
    }

    public async IAsyncEnumerable<string> StreamMessage(string message)
    {
        var request = new SendChatMessageRequest(
            Model: model,
            Messages: [new Message(PerplexityChatClient.DefaultRole, message)],
            Stream: true
        );

        await foreach (var chunk in _client.StreamChatMessage(request))
        {
            yield return chunk;
        }
    }
}