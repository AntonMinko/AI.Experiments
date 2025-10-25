using OpenAI;
using OpenAI.Chat;

namespace AI.Experiments.OpenAIProvider;

public class OpenAiClient(string apiKey)
{
    private readonly OpenAIClient _client = new(apiKey);

    public async Task<IReadOnlyList<string>> GetAvailableChatModels()
    {
        // var result = await _client.GetOpenAIModelClient().GetModelsAsync();
        // return result.Value.Select(model => model.Id).ToList();
        return ["gpt-5-nano", "gpt-5-mini", "gpt-5", "gpt-4.1", "pt-4o"];
    }

    public OpenAiChatClient GetChatClient(string model = "gpt-4o") => new(_client.GetChatClient(model));
}
public class OpenAiChatClient(ChatClient client)
{
    public async Task<string> SendChatMessage(string message)
    {
        var completion = await client.CompleteChatAsync(message);
        return completion.Value.Content[0].Text;
    }

    public async Task<string> SendChatConversation(List<ChatMessage> messages)
    {
        var completion = await client.CompleteChatAsync(messages);
        return completion.Value.Content[0].Text;
    }

    public async IAsyncEnumerable<string> StreamChatMessage(string message)
    {
        var updates = client.CompleteChatStreamingAsync(message);

        await foreach (var update in updates)
        {
            foreach (var contentPart in update.ContentUpdate)
            {
                yield return contentPart.Text;
            }
        }
    }
}