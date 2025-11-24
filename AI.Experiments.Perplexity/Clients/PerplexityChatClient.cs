using System.Net.Http.Headers;
using System.Text.Json;
using AI.Experiments.Perplexity.Models;

namespace AI.Experiments.Perplexity.Clients;

public class PerplexityChatClient(string model, string apiKey, string baseUrl = PerplexityChatClient.PerplexityBaseUrl)
{
    private const string PerplexityBaseUrl = "https://api.perplexity.ai";
    private static readonly Uri ChatCompletionsUrl = new($"{PerplexityBaseUrl}/chat/completions");
    public const string DefaultRole = "user";
    
    private readonly HttpClient _httpClient = new()
    {
        BaseAddress = new Uri(baseUrl),
        DefaultRequestHeaders =
        {
            Accept = { new MediaTypeWithQualityHeaderValue("application/json") },
            Authorization = new AuthenticationHeaderValue("Bearer", apiKey)
        }
    };

    public async Task<SendChatMessageResponse> SendChatMessage(SendChatMessageRequest request)
    {
        var response = await _httpClient.PostAsync(ChatCompletionsUrl, request.ToJson());
        response.EnsureSuccessStatusCode();
        
        var responseJson = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<SendChatMessageResponse>(responseJson);

        return result ?? throw new InvalidOperationException("Failed to deserialize response");
    }

    public async IAsyncEnumerable<string> StreamChatMessage(SendChatMessageRequest request)
    {
        var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, ChatCompletionsUrl)
        {
            Content = request.ToJson()
        };

        using var response = await _httpClient.SendAsync(httpRequestMessage, HttpCompletionOption.ResponseHeadersRead);
        response.EnsureSuccessStatusCode();

        await using var stream = await response.Content.ReadAsStreamAsync();
        using var reader = new StreamReader(stream);

        while (!reader.EndOfStream)
        {
            var chunkString = await reader.ReadLineAsync();
            if (string.IsNullOrEmpty(chunkString)) continue;
            
            // json payload is prefixed with "data: " - cut it off before parsing
            chunkString = chunkString.Substring("data: ".Length);
            var chunk = JsonSerializer.Deserialize<SendChatMessageResponse>(chunkString);
            yield return chunk!.Choices.First().Delta.Content;
        }
    }
}
