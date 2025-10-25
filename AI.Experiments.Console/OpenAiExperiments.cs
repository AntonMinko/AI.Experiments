using AI.Experiments.OpenAIProvider;

namespace AI.Experiments.Console;

public class OpenAiExperiments(OpenAiSettings settings)
{
    private readonly OpenAiClient _client = new OpenAiClient(settings.Key);
    
    public async Task FirstChat()
    {
        var chatClient = _client.GetChatClient();
        var response = await chatClient.SendChatMessage($"Who are you?");
        WriteLine(response);
    }
    public async Task GetAvailableModels()
    {
        var models = await _client.GetAvailableChatModels();
        WriteLine($"Available Chat Models: {string.Join(Environment.NewLine, models)}");
    }
}