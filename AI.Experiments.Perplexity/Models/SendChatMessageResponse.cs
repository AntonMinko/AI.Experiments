using System.Text.Json.Serialization;

namespace AI.Experiments.Perplexity.Models;

public record SendChatMessageResponse(
    [property: JsonPropertyName("id")] string Id,
    [property: JsonPropertyName("model")] string Model,
    [property: JsonPropertyName("created")] long Created,
    [property: JsonPropertyName("usage")] Usage Usage,
    [property: JsonPropertyName("citations")] IEnumerable<string> Citations,
    [property: JsonPropertyName("search_results")] IEnumerable<SearchResult> SearchResults,
    [property: JsonPropertyName("object")] string Object,
    [property: JsonPropertyName("choices")] IEnumerable<Choice> Choices
);

public record Usage(
    [property: JsonPropertyName("prompt_tokens")] int PromptTokens,
    [property: JsonPropertyName("completion_tokens")] int CompletionTokens,
    [property: JsonPropertyName("total_tokens")] int TotalTokens,
    [property: JsonPropertyName("search_context_size")] string SearchContextSize,
    [property: JsonPropertyName("cost")] Cost Cost
);

public record Cost(
    [property: JsonPropertyName("input_tokens_cost")] double InputTokensCost,
    [property: JsonPropertyName("output_tokens_cost")] double OutputTokensCost,
    [property: JsonPropertyName("request_cost")] double RequestCost,
    [property: JsonPropertyName("total_cost")] double TotalCost
);

public record SearchResult(
    [property: JsonPropertyName("title")] string Title,
    [property: JsonPropertyName("url")] string Url,
    [property: JsonPropertyName("date")] string? Date,
    [property: JsonPropertyName("last_updated")] string? LastUpdated,
    [property: JsonPropertyName("snippet")] string Snippet,
    [property: JsonPropertyName("source")] string Source
);

public record Choice(
    [property: JsonPropertyName("index")] int Index,
    [property: JsonPropertyName("message")] ResponseMessage Message,
    [property: JsonPropertyName("delta")] Delta Delta,
    [property: JsonPropertyName("finish_reason")] string FinishReason
);

public record ResponseMessage(
    [property: JsonPropertyName("role")] string Role,
    [property: JsonPropertyName("content")] string Content
);

public record Delta(
    [property: JsonPropertyName("role")] string Role,
    [property: JsonPropertyName("content")] string Content
);