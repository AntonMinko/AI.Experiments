using Anthropic.SDK;
using Anthropic.SDK.Messaging;
using Anthropic.SDK.Models;

namespace AI.Experiments.AnthropicProvider;

public class AnthropicChatClient(string apiKey)
{
    readonly AnthropicClient _client = new(apiKey);

    public async Task<List<string>> GetModels()
    {
        var models = await _client.Models.ListModelsAsync();
        return models.Models.Select(m => m.Id).ToList();
    }
    public async Task<List<string>> GetModelAliases()
    {
        return ["claude-haiku-4-5", "claude-sonnet-4-5", "claude-opus-4-1"];
    }
    
    public async Task<string> SendChatMessage(string message, decimal temperature = 1.0m, decimal topP = 1.0m)
    {
        var request = new MessageParameters
        {
            Model = "claude-haiku-4-5",
            MaxTokens = 1000,
            Messages =
            [
                new()
                {
                    Content = [new TextContent { Text = message }]
                }
            ],
            // Temperature = temperature,
            // TopP = topP
        };
        var response = await _client.Messages.GetClaudeMessageAsync(request);
        WriteTokensUsed(response);
        return response.Content.First().ToString()!;
    }

    private void WriteTokensUsed(MessageResponse response)
    {
        var usage = response.Usage;
        Console.WriteLine($"-- Tokens used. Input: {usage.InputTokens}, Output: {usage.OutputTokens}, Total: {usage.InputTokens + usage.OutputTokens}");
    }
}