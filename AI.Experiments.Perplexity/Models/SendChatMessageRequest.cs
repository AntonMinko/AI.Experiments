using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AI.Experiments.Perplexity.Models;

public record SendChatMessageRequest(
    [property: JsonPropertyName("model")] string Model,
    [property: JsonPropertyName("messages")] IEnumerable<Message> Messages,
    [property: JsonPropertyName("stream")] bool Stream,
    [property: JsonPropertyName("temperature")] float Temperature,
    [property: JsonPropertyName("top_p")] float TopP
)
{
    public StringContent ToJson()
    {
        var json = JsonSerializer.Serialize(this);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        return content;
    }
}

public record Message(
    [property: JsonPropertyName("role")] string Role,
    [property: JsonPropertyName("content")] string Text
);