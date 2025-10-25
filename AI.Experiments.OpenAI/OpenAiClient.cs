using OpenAI.Chat;

namespace AI.Experiments.OpenAI;

public class OpenAiClient(string apiKey, string model = "gpt-4o")
{
    private readonly ChatClient _chatClient = new(model, apiKey);

    public async Task<string> SendChatMessage(string message)
    {
        var completion = await _chatClient.CompleteChatAsync(message);
        return completion.Value.Content[0].Text;
    }

    public async Task<string> SendChatConversation(List<ChatMessage> messages)
    {
        var completion = await _chatClient.CompleteChatAsync(messages);
        return completion.Value.Content[0].Text;
    }

    public async IAsyncEnumerable<string> StreamChatMessage(string message)
    {
        var updates = _chatClient.CompleteChatStreamingAsync(message);

        await foreach (var update in updates)
        {
            foreach (var contentPart in update.ContentUpdate)
            {
                yield return contentPart.Text;
            }
        }
    }
}