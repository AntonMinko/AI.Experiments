using AI.Experiments.Perplexity.Clients;
using AI.Experiments.Perplexity.Models;

namespace AI.Experiments.Perplexity;

public class PerplexityChatService(string model, string apiKey)
{
    private const float DefaultTemperature = 0.2f;
    private const float DefaultTopP = 0.9f;
    
    public static readonly HashSet<string> SupportedModels =
        ["sonar", "sonar-pro", "sonar-deep-research", "sonar-reasoning", "sonar-reasoning-pro"];
    private readonly PerplexityChatClient _client = new(model, apiKey);
    
    private float _temperature = DefaultTemperature;
    private float _topP = DefaultTopP;

    public float Temperature
    {
        get => _temperature;
        set => _temperature = 0.0 <= value && value < 2.0f ? value : _temperature;
    }

    public float TopP
    {
        get => _topP;
        set => _topP = 0.0 <= value && value <= 1.0f ? value : _topP;
    }

    public async Task<string> Send(string message)
    {
        var request = new SendChatMessageRequest(
            Model: model,
            Messages: [new Message(PerplexityChatClient.DefaultRole, message)],
            Stream: false,
            Temperature: _temperature,
            TopP: TopP
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
            Stream: true,
            Temperature: _temperature,
            TopP: TopP
        );

        await foreach (var chunk in _client.StreamChatMessage(request))
        {
            yield return chunk;
        }
    }
}