using AI.Experiments.AnthropicProvider;
using AI.Experiments.OpenAIProvider;

namespace AI.Experiments.Console;

public class AnthropicExperiments(AnthropicSettings settings)
{
    private readonly AnthropicChatClient _client = new(settings.Key);
    private readonly HttpClient _httpClient = new();

    /*
     * claude-haiku-4-5-20251001
       claude-sonnet-4-5-20250929
       claude-opus-4-1-20250805
       claude-opus-4-20250514
       claude-sonnet-4-20250514
       claude-3-7-sonnet-20250219
       claude-3-5-haiku-20241022
       claude-3-haiku-20240307
     */
    public async Task GetModels()
    {
        var models = await _client.GetModels();
        WriteLine(string.Join('\n', models));
    }
    
    public async Task FirstChat()
    {
        var response = await _client.SendChatMessage($"Who are you?");
        WriteLine(response);
    }
    
    // public async Task GetAvailableModels()
    // {
    //     var models = await _client.GetAvailableChatModels();
    //     WriteLine($"Available Chat Models: {string.Join(Environment.NewLine, models)}");
    // }
    //
    // public async Task StreamMessages()
    // {
    //     var question = "Suggest ten unusual ice cream flavors.";
    //     var chatClient = _client.GetChatClient();
    //     await foreach (var chunk in chatClient.StreamChatMessage(question))
    //     {
    //         Write(chunk);
    //     }
    //     WriteLine();
    // }
    //
    // public async Task StreamMessagesViaApi(string baseUrl = "http://localhost:5171")
    // {
    //  const int bufferSize = 16;
    //     var model = "gpt-4o";
    //     var temperature = 0.7f;
    //     var topP = 0.9f;
    //     var message = "Suggest ten unusual ice cream flavors.";
    //
    //     var url = $"{baseUrl}/api/OpenAIChat/chat/stream?model={Uri.EscapeDataString(model)}&temperature={temperature}&topP={topP}&message={Uri.EscapeDataString(message)}";
    //
    //     WriteLine($"Connecting to: {url}");
    //     WriteLine($"Streaming response:");
    //     WriteLine("---");
    //
    //     try
    //     {
    //         using var response = await _httpClient.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);
    //         response.EnsureSuccessStatusCode();
    //
    //         using var stream = await response.Content.ReadAsStreamAsync();
    //         using var reader = new StreamReader(stream);
    //
    //         var buffer = new char[bufferSize];
    //         int read;
    //         while ((read = await reader.ReadBlockAsync(buffer)) > 0)
    //         {
    //             Write(buffer[..read]);
    //         }
    //
    //         WriteLine();
    //         WriteLine("---");
    //         WriteLine("Stream completed.");
    //     }
    //     catch (Exception ex)
    //     {
    //         WriteLine($"Error: {ex.Message}");
    //     }
    // }
    //
    // /*
    //  GPT-4o
    //  
    //  What is the biggest city in the world by population? Answer with a single word without additional explanations.
    //     === Temperature: 0, TopP: 1 ===
    //    -- Tokens used. Input: 27, Output: 1, Total: 28
    //    -- Tokens used. Input: 27, Output: 1, Total: 28
    //    -- Tokens used. Input: 27, Output: 1, Total: 28
    //    -- Tokens used. Input: 27, Output: 1, Total: 28
    //    -- Tokens used. Input: 27, Output: 1, Total: 28
    //    -- Tokens used. Input: 27, Output: 1, Total: 28
    //    -- Tokens used. Input: 27, Output: 1, Total: 28
    //    -- Tokens used. Input: 27, Output: 1, Total: 28
    //    -- Tokens used. Input: 27, Output: 1, Total: 28
    //    -- Tokens used. Input: 27, Output: 1, Total: 28
    //    Tokyo, Tokyo, Tokyo, Tokyo, Tokyo, Tokyo, Tokyo, Tokyo, Tokyo, Tokyo
    //    
    //     === Temperature: 0.5, TopP: 1 ===
    //    -- Tokens used. Input: 27, Output: 1, Total: 28
    //    -- Tokens used. Input: 27, Output: 1, Total: 28
    //    -- Tokens used. Input: 27, Output: 1, Total: 28
    //    -- Tokens used. Input: 27, Output: 1, Total: 28
    //    -- Tokens used. Input: 27, Output: 1, Total: 28
    //    -- Tokens used. Input: 27, Output: 1, Total: 28
    //    -- Tokens used. Input: 27, Output: 1, Total: 28
    //    -- Tokens used. Input: 27, Output: 1, Total: 28
    //    -- Tokens used. Input: 27, Output: 1, Total: 28
    //    -- Tokens used. Input: 27, Output: 1, Total: 28
    //    Tokyo, Tokyo, Tokyo, Tokyo, Tokyo, Tokyo, Tokyo, Tokyo, Tokyo, Tokyo
    //    
    //     === Temperature: 1, TopP: 1 ===
    //    -- Tokens used. Input: 27, Output: 1, Total: 28
    //    -- Tokens used. Input: 27, Output: 1, Total: 28
    //    -- Tokens used. Input: 27, Output: 1, Total: 28
    //    -- Tokens used. Input: 27, Output: 1, Total: 28
    //    -- Tokens used. Input: 27, Output: 1, Total: 28
    //    -- Tokens used. Input: 27, Output: 1, Total: 28
    //    -- Tokens used. Input: 27, Output: 1, Total: 28
    //    -- Tokens used. Input: 27, Output: 1, Total: 28
    //    -- Tokens used. Input: 27, Output: 1, Total: 28
    //    -- Tokens used. Input: 27, Output: 1, Total: 28
    //    Tokyo, Tokyo, Tokyo, Tokyo, Tokyo, Tokyo, Tokyo, Tokyo, Tokyo, Tokyo
    //    
    //     === Temperature: 1, TopP: 0.2 ===
    //    -- Tokens used. Input: 27, Output: 1, Total: 28
    //    -- Tokens used. Input: 27, Output: 1, Total: 28
    //    -- Tokens used. Input: 27, Output: 1, Total: 28
    //    -- Tokens used. Input: 27, Output: 1, Total: 28
    //    -- Tokens used. Input: 27, Output: 1, Total: 28
    //    -- Tokens used. Input: 27, Output: 1, Total: 28
    //    -- Tokens used. Input: 27, Output: 1, Total: 28
    //    -- Tokens used. Input: 27, Output: 1, Total: 28
    //    -- Tokens used. Input: 27, Output: 1, Total: 28
    //    -- Tokens used. Input: 27, Output: 1, Total: 28
    //    Tokyo, Tokyo, Tokyo, Tokyo, Tokyo, Tokyo, Tokyo, Tokyo, Tokyo, Tokyo
    //    
    //     === Temperature: 1, TopP: 0.5 ===
    //    -- Tokens used. Input: 27, Output: 1, Total: 28
    //    -- Tokens used. Input: 27, Output: 1, Total: 28
    //    -- Tokens used. Input: 27, Output: 1, Total: 28
    //    -- Tokens used. Input: 27, Output: 1, Total: 28
    //    -- Tokens used. Input: 27, Output: 1, Total: 28
    //    -- Tokens used. Input: 27, Output: 1, Total: 28
    //    -- Tokens used. Input: 27, Output: 1, Total: 28
    //    -- Tokens used. Input: 27, Output: 1, Total: 28
    //    -- Tokens used. Input: 27, Output: 1, Total: 28
    //    -- Tokens used. Input: 27, Output: 1, Total: 28
    //    Tokyo, Tokyo, Tokyo, Tokyo, Tokyo, Tokyo, Tokyo, Tokyo, Tokyo, Tokyo
    //    
    //     === Temperature: 1.5, TopP: 1 ===
    //    -- Tokens used. Input: 27, Output: 1, Total: 28
    //    -- Tokens used. Input: 27, Output: 1, Total: 28
    //    -- Tokens used. Input: 27, Output: 1, Total: 28
    //    -- Tokens used. Input: 27, Output: 1, Total: 28
    //    -- Tokens used. Input: 27, Output: 1, Total: 28
    //    -- Tokens used. Input: 27, Output: 1, Total: 28
    //    -- Tokens used. Input: 27, Output: 1, Total: 28
    //    -- Tokens used. Input: 27, Output: 1, Total: 28
    //    -- Tokens used. Input: 27, Output: 1, Total: 28
    //    -- Tokens used. Input: 27, Output: 1, Total: 28
    //    Tokyo, Tokyo, Tokyo, Tokyo, Tokyo, Tokyo, Tokyo, Tokyo, Tokyo, Tokyo
    //    
    //    Total execution time: 31.37 seconds (00:00:31.3717392)
    //    
    //  */
    // public async Task TestTemperatureAndTopPWithExactQuestion()
    // {
    //     var question = "What is the biggest city in the world by population? Answer with a single word without additional explanations.";
    //     WriteLine("------------------------------------------------");
    //     WriteLine(question);
    //     var chatClient = _client.GetChatClient();
    //     var stopwatch = System.Diagnostics.Stopwatch.StartNew();
    //     
    //     await SingleTestVariability(chatClient, question,temperature: 0.0f, topP: 1.0f, attempts: 10);
    //     await SingleTestVariability(chatClient, question,temperature: 0.5f, topP: 1.0f, attempts: 10);
    //     await SingleTestVariability(chatClient, question,temperature: 1.0f, topP: 1.0f, attempts: 10);
    //     await SingleTestVariability(chatClient, question,temperature: 1.0f, topP: 0.2f, attempts: 10);
    //     await SingleTestVariability(chatClient, question,temperature: 1.0f, topP: 0.5f, attempts: 10);
    //     await SingleTestVariability(chatClient, question,temperature: 1.5f, topP: 1.0f, attempts: 10);
    //     
    //     stopwatch.Stop();
    //     WriteLine($"Total execution time: {stopwatch.Elapsed.TotalSeconds:F2} seconds ({stopwatch.Elapsed})");
    // }
    //
    // /*
    //  GPT-4o
    //  
    //  What is the most beautiful city in the world? Despite it's an opinionated question, I want a single city name. Answer with a single word without additional explanations.
    //     === Temperature: 0, TopP: 1 ===
    //    -- Tokens used. Input: 40, Output: 1, Total: 41
    //    -- Tokens used. Input: 40, Output: 1, Total: 41
    //    -- Tokens used. Input: 40, Output: 1, Total: 41
    //    -- Tokens used. Input: 40, Output: 1, Total: 41
    //    -- Tokens used. Input: 40, Output: 1, Total: 41
    //    -- Tokens used. Input: 40, Output: 1, Total: 41
    //    -- Tokens used. Input: 40, Output: 1, Total: 41
    //    -- Tokens used. Input: 40, Output: 1, Total: 41
    //    -- Tokens used. Input: 40, Output: 1, Total: 41
    //    -- Tokens used. Input: 40, Output: 1, Total: 41
    //    Paris, Paris, Paris, Paris, Paris, Paris, Paris, Paris, Paris, Paris
    //    
    //     === Temperature: 0.5, TopP: 1 ===
    //    -- Tokens used. Input: 40, Output: 1, Total: 41
    //    -- Tokens used. Input: 40, Output: 1, Total: 41
    //    -- Tokens used. Input: 40, Output: 1, Total: 41
    //    -- Tokens used. Input: 40, Output: 1, Total: 41
    //    -- Tokens used. Input: 40, Output: 1, Total: 41
    //    -- Tokens used. Input: 40, Output: 1, Total: 41
    //    -- Tokens used. Input: 40, Output: 1, Total: 41
    //    -- Tokens used. Input: 40, Output: 1, Total: 41
    //    -- Tokens used. Input: 40, Output: 1, Total: 41
    //    -- Tokens used. Input: 40, Output: 1, Total: 41
    //    Paris, Paris, Paris, Paris, Paris, Paris, Paris, Paris, Paris, Paris
    //    
    //     === Temperature: 1, TopP: 1 ===
    //    -- Tokens used. Input: 40, Output: 1, Total: 41
    //    -- Tokens used. Input: 40, Output: 1, Total: 41
    //    -- Tokens used. Input: 40, Output: 1, Total: 41
    //    -- Tokens used. Input: 40, Output: 1, Total: 41
    //    -- Tokens used. Input: 40, Output: 1, Total: 41
    //    -- Tokens used. Input: 40, Output: 1, Total: 41
    //    -- Tokens used. Input: 40, Output: 1, Total: 41
    //    -- Tokens used. Input: 40, Output: 1, Total: 41
    //    -- Tokens used. Input: 40, Output: 1, Total: 41
    //    -- Tokens used. Input: 40, Output: 1, Total: 41
    //    Paris, Paris, Paris, Paris, Paris, Paris, Paris, Paris, Paris, Paris
    //    
    //     === Temperature: 1, TopP: 0.2 ===
    //    -- Tokens used. Input: 40, Output: 1, Total: 41
    //    -- Tokens used. Input: 40, Output: 1, Total: 41
    //    -- Tokens used. Input: 40, Output: 1, Total: 41
    //    -- Tokens used. Input: 40, Output: 1, Total: 41
    //    -- Tokens used. Input: 40, Output: 1, Total: 41
    //    -- Tokens used. Input: 40, Output: 1, Total: 41
    //    -- Tokens used. Input: 40, Output: 1, Total: 41
    //    -- Tokens used. Input: 40, Output: 1, Total: 41
    //    -- Tokens used. Input: 40, Output: 1, Total: 41
    //    -- Tokens used. Input: 40, Output: 1, Total: 41
    //    Paris, Paris, Paris, Paris, Paris, Paris, Paris, Paris, Paris, Paris
    //    
    //     === Temperature: 1, TopP: 0.5 ===
    //    -- Tokens used. Input: 40, Output: 1, Total: 41
    //    -- Tokens used. Input: 40, Output: 1, Total: 41
    //    -- Tokens used. Input: 40, Output: 1, Total: 41
    //    -- Tokens used. Input: 40, Output: 1, Total: 41
    //    -- Tokens used. Input: 40, Output: 1, Total: 41
    //    -- Tokens used. Input: 40, Output: 1, Total: 41
    //    -- Tokens used. Input: 40, Output: 1, Total: 41
    //    -- Tokens used. Input: 40, Output: 1, Total: 41
    //    -- Tokens used. Input: 40, Output: 1, Total: 41
    //    -- Tokens used. Input: 40, Output: 1, Total: 41
    //    Paris, Paris, Paris, Paris, Paris, Paris, Paris, Paris, Paris, Paris
    //    
    //     === Temperature: 1.5, TopP: 1 ===
    //    -- Tokens used. Input: 40, Output: 2, Total: 42
    //    -- Tokens used. Input: 40, Output: 1, Total: 41
    //    -- Tokens used. Input: 40, Output: 1, Total: 41
    //    -- Tokens used. Input: 40, Output: 1, Total: 41
    //    -- Tokens used. Input: 40, Output: 1, Total: 41
    //    -- Tokens used. Input: 40, Output: 2, Total: 42
    //    -- Tokens used. Input: 40, Output: 1, Total: 41
    //    -- Tokens used. Input: 40, Output: 1, Total: 41
    //    -- Tokens used. Input: 40, Output: 1, Total: 41
    //    -- Tokens used. Input: 40, Output: 1, Total: 41
    //    Venice, Paris, Paris, Paris, Paris, Venice, Paris, Paris, Paris, Paris
    //    
    //    Total execution time: 59.38 seconds (00:00:59.3834129)
    //    
    //  */
    // public async Task TestTemperatureAndTopPWithOpinionatedQuestion()
    // {
    //     var question = "What is the most beautiful city in the world? Despite it's an opinionated question, I want a single city name. " +
    //                    "Answer with a single word without additional explanations.";
    //     WriteLine("------------------------------------------------");
    //     WriteLine(question);
    //     var chatClient = _client.GetChatClient();
    //     var stopwatch = System.Diagnostics.Stopwatch.StartNew();
    //     
    //     await SingleTestVariability(chatClient, question,temperature: 0.0f, topP: 1.0f, attempts: 10);
    //     await SingleTestVariability(chatClient, question,temperature: 0.5f, topP: 1.0f, attempts: 10);
    //     await SingleTestVariability(chatClient, question,temperature: 1.0f, topP: 1.0f, attempts: 10);
    //     await SingleTestVariability(chatClient, question,temperature: 1.0f, topP: 0.2f, attempts: 10);
    //     await SingleTestVariability(chatClient, question,temperature: 1.0f, topP: 0.5f, attempts: 10);
    //     await SingleTestVariability(chatClient, question,temperature: 1.5f, topP: 1.0f, attempts: 10);
    //     
    //     stopwatch.Stop();
    //     WriteLine($"Total execution time: {stopwatch.Elapsed.TotalSeconds:F2} seconds ({stopwatch.Elapsed})");
    // }
    //
    // /*
    //  * GPT-4o
    //  * 
    //    Explain what is photosynthesis in one sentence.
    //     === Temperature: 0, TopP: 0 ===
    //    -- Tokens used. Input: 16, Output: 39, Total: 55
    //    -- Tokens used. Input: 16, Output: 39, Total: 55
    //    Photosynthesis is the process by which green plants, algae, and some bacteria convert light energy, usually from the sun, into chemical energy in the form of glucose, using carbon dioxide and water.
    //    Photosynthesis is the process by which green plants, algae, and some bacteria convert light energy, usually from the sun, into chemical energy in the form of glucose, using carbon dioxide and water.
    //    
    //     === Temperature: 0, TopP: 1 ===
    //    -- Tokens used. Input: 16, Output: 39, Total: 55
    //    -- Tokens used. Input: 16, Output: 39, Total: 55
    //    Photosynthesis is the process by which green plants, algae, and some bacteria convert light energy, usually from the sun, into chemical energy in the form of glucose, using carbon dioxide and water.
    //    Photosynthesis is the process by which green plants, algae, and some bacteria convert light energy, usually from the sun, into chemical energy in the form of glucose, using carbon dioxide and water.
    //    
    //     === Temperature: 0.5, TopP: 1 ===
    //    -- Tokens used. Input: 16, Output: 46, Total: 62
    //    -- Tokens used. Input: 16, Output: 47, Total: 63
    //    Photosynthesis is the process by which green plants, algae, and some bacteria convert light energy, usually from the sun, into chemical energy in the form of glucose, using carbon dioxide and water and releasing oxygen as a byproduct.
    //    Photosynthesis is the process by which green plants, algae, and some bacteria convert light energy, usually from the sun, into chemical energy in the form of glucose, using carbon dioxide and water, and releasing oxygen as a byproduct.
    //    
    //     === Temperature: 1, TopP: 1 ===
    //    -- Tokens used. Input: 16, Output: 45, Total: 61
    //    -- Tokens used. Input: 16, Output: 46, Total: 62
    //    Photosynthesis is the process by which green plants, algae, and some bacteria convert light energy, usually from the sun, into chemical energy stored in glucose, using carbon dioxide and water, and releasing oxygen as a byproduct.
    //    Photosynthesis is the process by which green plants, algae, and some bacteria convert light energy, usually from the sun, into chemical energy in the form of glucose, using carbon dioxide and water and releasing oxygen as a byproduct.
    //    
    //     === Temperature: 1, TopP: 0.2 ===
    //    -- Tokens used. Input: 16, Output: 47, Total: 63
    //    -- Tokens used. Input: 16, Output: 47, Total: 63
    //    Photosynthesis is the process by which green plants, algae, and some bacteria convert light energy, usually from the sun, into chemical energy in the form of glucose, using carbon dioxide and water, and releasing oxygen as a byproduct.
    //    Photosynthesis is the process by which green plants, algae, and some bacteria convert light energy, usually from the sun, into chemical energy in the form of glucose, using carbon dioxide and water, and releasing oxygen as a byproduct.
    //    
    //     === Temperature: 1.5, TopP: 1 ===
    //    -- Tokens used. Input: 16, Output: 47, Total: 63
    //    -- Tokens used. Input: 16, Output: 46, Total: 62
    //    Photosynthesis is the biological process by which green plants, algae, and some bacteria convert light energy, usually from the sun, into chemical energy in the form of glucose, utilizing carbon dioxide and water and releasing oxygen as a byproduct.
    //    Photosynthesis is the process by which green plants, algae, and certain bacteria convert light energy, usually from the sun, into chemical energy in the form of glucose, using carbon dioxide and water while releasing oxygen as a byproduct.
    //    
    //    Total execution time: 9.49 seconds (00:00:09.4861322)
    //    
    //  */
    // public async Task TestTemperatureAndTopPWithOneSentenceExplanation_gpt4o()
    // {
    //     var question = "Explain what is photosynthesis in one sentence.";
    //     WriteLine("------------------------------------------------");
    //     WriteLine(question);
    //     var chatClient = _client.GetChatClient();
    //
    //     var stopwatch = System.Diagnostics.Stopwatch.StartNew();
    //
    //     await SingleTestVariability(chatClient, question,temperature: 0.0f, topP: 0.0f, attempts: 2, separator: Environment.NewLine);
    //     await SingleTestVariability(chatClient, question,temperature: 0.0f, topP: 1.0f, attempts: 2, separator: Environment.NewLine);
    //     await SingleTestVariability(chatClient, question,temperature: 0.5f, topP: 1.0f, attempts: 2, separator: Environment.NewLine);
    //     await SingleTestVariability(chatClient, question,temperature: 1.0f, topP: 1.0f, attempts: 2, separator: Environment.NewLine);
    //     await SingleTestVariability(chatClient, question,temperature: 1.0f, topP: 0.2f, attempts: 2, separator: Environment.NewLine);
    //     await SingleTestVariability(chatClient, question,temperature: 1.5f, topP: 1.0f, attempts: 2, separator: Environment.NewLine);
    //
    //     stopwatch.Stop();
    //     WriteLine($"Total execution time: {stopwatch.Elapsed.TotalSeconds:F2} seconds ({stopwatch.Elapsed})");
    // }
    //
    // /*
    //  * GPT-4.1
    //  * 
    //    Explain what is photosynthesis in one sentence.
    //     === Temperature: 0, TopP: 0 ===
    //    -- Tokens used. Input: 16, Output: 28, Total: 44
    //    -- Tokens used. Input: 16, Output: 28, Total: 44
    //    Photosynthesis is the process by which green plants, algae, and some bacteria use sunlight to convert carbon dioxide and water into glucose and oxygen.
    //    Photosynthesis is the process by which green plants, algae, and some bacteria use sunlight to convert carbon dioxide and water into glucose and oxygen.
    //    
    //     === Temperature: 0, TopP: 1 ===
    //    -- Tokens used. Input: 16, Output: 28, Total: 44
    //    -- Tokens used. Input: 16, Output: 28, Total: 44
    //    Photosynthesis is the process by which green plants, algae, and some bacteria use sunlight to convert carbon dioxide and water into glucose and oxygen.
    //    Photosynthesis is the process by which green plants, algae, and some bacteria use sunlight to convert carbon dioxide and water into glucose and oxygen.
    //    
    //     === Temperature: 0.5, TopP: 1 ===
    //    -- Tokens used. Input: 16, Output: 26, Total: 42
    //    -- Tokens used. Input: 16, Output: 34, Total: 50
    //    Photosynthesis is the process by which green plants and some other organisms use sunlight to convert carbon dioxide and water into glucose and oxygen.
    //    Photosynthesis is the process by which green plants, algae, and some bacteria use sunlight, carbon dioxide, and water to produce food (glucose) and release oxygen.
    //    
    //     === Temperature: 1, TopP: 1 ===
    //    -- Tokens used. Input: 16, Output: 26, Total: 42
    //    -- Tokens used. Input: 16, Output: 26, Total: 42
    //    Photosynthesis is the process by which green plants and some other organisms use sunlight to convert carbon dioxide and water into glucose and oxygen.
    //    Photosynthesis is the process by which green plants and some other organisms use sunlight to convert carbon dioxide and water into glucose and oxygen.
    //    
    //     === Temperature: 1, TopP: 0.2 ===
    //    -- Tokens used. Input: 16, Output: 28, Total: 44
    //    -- Tokens used. Input: 16, Output: 33, Total: 49
    //    Photosynthesis is the process by which green plants, algae, and some bacteria use sunlight to convert carbon dioxide and water into glucose and oxygen.
    //    Photosynthesis is the process by which green plants, algae, and some bacteria use sunlight, carbon dioxide, and water to produce food (glucose) and oxygen.
    //    
    //    
    //     === Temperature: 1.5, TopP: 1 ===
    //    -- Tokens used. Input: 16, Output: 28, Total: 44
    //    -- Tokens used. Input: 16, Output: 31, Total: 47
    //    Photosynthesis is the process by which green plants, algae, and some bacteria use sunlight to convert carbon dioxide and water into glucose and oxygen.
    //    Photosynthesis is the process by which green plants, algae, and some bacteria use sunlight to convert carbon dioxide and water into glucose (food) and oxygen.
    //    
    //    Total execution time: 10.27 seconds (00:00:10.2672611)
    //          
    //  */
    // public async Task TestTemperatureAndTopPWithOneSentenceExplanation_gpt41()
    // {
    //     var question = "Explain what is photosynthesis in one sentence.";
    //     WriteLine("------------------------------------------------");
    //     WriteLine(question);
    //     var chatClient = _client.GetChatClient("gpt-4.1");
    //
    //     var stopwatch = System.Diagnostics.Stopwatch.StartNew();
    //
    //     await SingleTestVariability(chatClient, question,temperature: 0.0f, topP: 0.0f, attempts: 2, separator: Environment.NewLine);
    //     await SingleTestVariability(chatClient, question,temperature: 0.0f, topP: 1.0f, attempts: 2, separator: Environment.NewLine);
    //     await SingleTestVariability(chatClient, question,temperature: 0.5f, topP: 1.0f, attempts: 2, separator: Environment.NewLine);
    //     await SingleTestVariability(chatClient, question,temperature: 1.0f, topP: 1.0f, attempts: 2, separator: Environment.NewLine);
    //     await SingleTestVariability(chatClient, question,temperature: 1.0f, topP: 0.2f, attempts: 2, separator: Environment.NewLine);
    //     await SingleTestVariability(chatClient, question,temperature: 1.5f, topP: 1.0f, attempts: 2, separator: Environment.NewLine);
    //
    //     stopwatch.Stop();
    //     WriteLine($"Total execution time: {stopwatch.Elapsed.TotalSeconds:F2} seconds ({stopwatch.Elapsed})");
    // }
    //
    // /*
    //  * GPT-5
    //  *
    //    Photosynthesis is the process by which plants, algae, and some bacteria use light energy to convert carbon dioxide and water into glucose (chemical energy) and oxygen.
    //    Photosynthesis is the process by which plants, algae, and some bacteria use light energy to convert carbon dioxide and water into glucose (chemical energy) and oxygen.
    //    Photosynthesis is the process by which plants, algae, and some bacteria use light energy to convert carbon dioxide and water into sugars (chemical energy) and release oxygen.
    //    Photosynthesis is the process by which plants, algae, and some bacteria use light energy to convert carbon dioxide and water into sugars (chemical energy) and oxygen.
    //    Photosynthesis is the process by which plants, algae, and some bacteria use sunlight to convert water and carbon dioxide into sugars for energy and growth, releasing oxygen as a byproduct.
    //    
    //    Total execution time: 25.44 seconds (00:00:25.4394287)
    //  */
    // public async Task TestTemperatureAndTopPWithOneSentenceExplanation_gpt5()
    // {
    //     var question = "Explain what is photosynthesis in one sentence.";
    //     WriteLine("------------------------------------------------");
    //     WriteLine(question);
    //     var chatClient = _client.GetChatClient("gpt-5");
    //
    //     var stopwatch = System.Diagnostics.Stopwatch.StartNew();
    //     
    //     await SingleTestVariability(chatClient, question, attempts: 5, separator: Environment.NewLine);
    //
    //     stopwatch.Stop();
    //     WriteLine($"Total execution time: {stopwatch.Elapsed.TotalSeconds:F2} seconds ({stopwatch.Elapsed})");
    // }
    //
    // /*
    //  * GPT-5-mini
    //  *
    //    Photosynthesis is the process by which green plants, algae, and certain bacteria use light energy (captured by chlorophyll) to convert carbon dioxide and water into glucose (organic chemical energy) and oxygen.
    //    Photosynthesis is the process by which plants, algae, and some bacteria use sunlight (captured by chlorophyll) to convert carbon dioxide and water into organic sugars (like glucose) and release oxygen.
    //    Photosynthesis is the process by which plants, algae, and certain bacteria use chlorophyll to capture light energy and convert carbon dioxide and water into chemical energy (glucose) and oxygen.
    //    Photosynthesis is the process by which green plants, algae, and some bacteria use chlorophyll to capture sunlight and convert carbon dioxide and water into organic sugars (chemical energy) and oxygen.
    //    Photosynthesis is the process by which green plants, algae, and some bacteria use chlorophyll to capture sunlight and convert carbon dioxide and water into glucose (chemical energy) and oxygen.
    //    
    //    Total execution time: 29.40 seconds (00:00:29.4015380)
    //    
    //  */
    // public async Task TestTemperatureAndTopPWithOneSentenceExplanation_gpt5mini()
    // {
    //  var question = "Explain what is photosynthesis in one sentence.";
    //  WriteLine("------------------------------------------------");
    //  WriteLine(question);
    //  var chatClient = _client.GetChatClient("gpt-5-mini");
    //
    //  var stopwatch = System.Diagnostics.Stopwatch.StartNew();
    //     
    //  await SingleTestVariability(chatClient, question, attempts: 5, separator: Environment.NewLine);
    //
    //  stopwatch.Stop();
    //  WriteLine($"Total execution time: {stopwatch.Elapsed.TotalSeconds:F2} seconds ({stopwatch.Elapsed})");
    // }
    //
    // /*
    //  * GPT-5-nano
    //  *
    //    Photosynthesis is the process by which green plants, algae, and some bacteria use light energy and chlorophyll to convert carbon dioxide and water into glucose and oxygen.
    //    Photosynthesis is the process by which green plants, algae, and some bacteria convert light energy into chemical energy by using chlorophyll to transform carbon dioxide and water into glucose and oxygen.
    //    Photosynthesis is the process by which plants use light energy to convert carbon dioxide and water into glucose and oxygen.
    //    Photosynthesis is the process by which green plants and some microorganisms use sunlight to convert carbon dioxide and water into glucose, releasing oxygen as a byproduct.
    //    Photosynthesis is the process by which green plants and some organisms convert light energy into chemical energy by turning carbon dioxide and water into glucose, with oxygen released as a byproduct.
    //    
    //    Total execution time: 22.84 seconds (00:00:22.8362463)
    //    
    //  */
    // public async Task TestTemperatureAndTopPWithOneSentenceExplanation_gpt5nano()
    // {
    //  var question = "Explain what is photosynthesis in one sentence.";
    //  WriteLine("------------------------------------------------");
    //  WriteLine(question);
    //  var chatClient = _client.GetChatClient("gpt-5-nano");
    //
    //  var stopwatch = System.Diagnostics.Stopwatch.StartNew();
    //     
    //  await SingleTestVariability(chatClient, question, attempts: 5, separator: Environment.NewLine);
    //
    //  stopwatch.Stop();
    //  WriteLine($"Total execution time: {stopwatch.Elapsed.TotalSeconds:F2} seconds ({stopwatch.Elapsed})");
    // }
    //
    // private static async Task SingleTestVariability(
    //     OpenAiChatClient chatClient, 
    //     string question, 
    //     float temperature = 1.0f,
    //     float topP = 1.0f,
    //     int attempts = 10,
    //     string separator = ", ")
    // {
    //     WriteLine($" === Temperature: {temperature}, TopP: {topP} ===");
    //     var responses = new string[attempts];
    //     for (var i = 0; i < attempts; i++)
    //     {
    //         responses[i] = await chatClient.SendChatMessage(question, temperature, topP);
    //     }
    //     WriteLine($"{string.Join(separator, responses)}");
    //     WriteLine();
    // }
}