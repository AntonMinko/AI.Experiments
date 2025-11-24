using AI.Experiments.Perplexity;
using AI.Experiments.Perplexity.Clients;

namespace AI.Experiments.Console;

public class PerplexityExperiments(PerplexitySettings settings)
{
    private readonly PerplexityClient _client = new(settings.Key);
    
    public async Task GetAvailableModels()
    {
        var models = await _client.GetAvailableChatModels();
        WriteLine($"Available Chat Models: {string.Join(Environment.NewLine, models)}");
    }

    public async Task FirstChat()
    {
        var chatClient = _client.GetChat();
        var response = await chatClient.Send($"What model are you?");
        WriteLine(response);
    }
    
    public async Task StreamMessages()
    {
        var question = "Suggest ten unusual ice cream flavors.";
        var chatClient = _client.GetChat();
        await foreach (var chunk in chatClient.StreamMessage(question))
        {
            Write(chunk);
        }
        WriteLine();
    }
    
    /*
     sonar
     
     What is the biggest city in the world by population? Answer with a single word without additional explanations.
        === Temperature: 0, TopP: 1 ===
       -- Tokens used. Input: 20, Output: 2, Total: 22
       -- Tokens used. Input: 20, Output: 2, Total: 22
       -- Tokens used. Input: 20, Output: 2, Total: 22
       -- Tokens used. Input: 20, Output: 2, Total: 22
       -- Tokens used. Input: 20, Output: 2, Total: 22
       -- Tokens used. Input: 20, Output: 2, Total: 22
       -- Tokens used. Input: 20, Output: 2, Total: 22
       -- Tokens used. Input: 20, Output: 2, Total: 22
       -- Tokens used. Input: 20, Output: 2, Total: 22
       -- Tokens used. Input: 20, Output: 2, Total: 22
       Tokyo, Tokyo, Tokyo, Tokyo, Tokyo, Tokyo, Tokyo, Tokyo, Tokyo, Tokyo
       
        === Temperature: 0.5, TopP: 1 ===
       -- Tokens used. Input: 20, Output: 2, Total: 22
       -- Tokens used. Input: 20, Output: 2, Total: 22
       -- Tokens used. Input: 20, Output: 2, Total: 22
       -- Tokens used. Input: 20, Output: 2, Total: 22
       -- Tokens used. Input: 20, Output: 2, Total: 22
       -- Tokens used. Input: 20, Output: 2, Total: 22
       -- Tokens used. Input: 20, Output: 2, Total: 22
       -- Tokens used. Input: 20, Output: 2, Total: 22
       -- Tokens used. Input: 20, Output: 2, Total: 22
       -- Tokens used. Input: 20, Output: 2, Total: 22
       Tokyo, Tokyo, Tokyo, Tokyo, Tokyo, Tokyo, Tokyo, Tokyo, Tokyo, Tokyo
       
        === Temperature: 1, TopP: 1 ===
       -- Tokens used. Input: 20, Output: 2, Total: 22
       -- Tokens used. Input: 20, Output: 2, Total: 22
       -- Tokens used. Input: 20, Output: 2, Total: 22
       -- Tokens used. Input: 20, Output: 2, Total: 22
       -- Tokens used. Input: 20, Output: 2, Total: 22
       -- Tokens used. Input: 20, Output: 2, Total: 22
       -- Tokens used. Input: 20, Output: 2, Total: 22
       -- Tokens used. Input: 20, Output: 2, Total: 22
       -- Tokens used. Input: 20, Output: 2, Total: 22
       -- Tokens used. Input: 20, Output: 2, Total: 22
       Tokyo, Jakarta, Tokyo, Tokyo, Tokyo, Tokyo, Tokyo, Tokyo, Tokyo, Tokyo
       
        === Temperature: 1.9, TopP: 1 ===
       -- Tokens used. Input: 20, Output: 3, Total: 23
       -- Tokens used. Input: 20, Output: 2, Total: 22
       -- Tokens used. Input: 20, Output: 2, Total: 22
       -- Tokens used. Input: 20, Output: 2, Total: 22
       -- Tokens used. Input: 20, Output: 2, Total: 22
       -- Tokens used. Input: 20, Output: 2, Total: 22
       -- Tokens used. Input: 20, Output: 2, Total: 22
       -- Tokens used. Input: 20, Output: 2, Total: 22
       -- Tokens used. Input: 20, Output: 2, Total: 22
       -- Tokens used. Input: 20, Output: 2, Total: 22
       Tokyo., Tokyo, Tokyo, Jakarta, Tokyo, Tokyo, Tokyo, Tokyo, Tokyo, Tokyo
       
        === Temperature: 1, TopP: 0.2 ===
       -- Tokens used. Input: 20, Output: 2, Total: 22
       -- Tokens used. Input: 20, Output: 2, Total: 22
       -- Tokens used. Input: 20, Output: 2, Total: 22
       -- Tokens used. Input: 20, Output: 2, Total: 22
       -- Tokens used. Input: 20, Output: 2, Total: 22
       -- Tokens used. Input: 20, Output: 2, Total: 22
       -- Tokens used. Input: 20, Output: 2, Total: 22
       -- Tokens used. Input: 20, Output: 2, Total: 22
       -- Tokens used. Input: 20, Output: 2, Total: 22
       -- Tokens used. Input: 20, Output: 2, Total: 22
       Tokyo, Tokyo, Tokyo, Tokyo, Tokyo, Tokyo, Tokyo, Tokyo, Tokyo, Tokyo
       
        === Temperature: 1, TopP: 0.5 ===
       -- Tokens used. Input: 20, Output: 2, Total: 22
       -- Tokens used. Input: 20, Output: 2, Total: 22
       -- Tokens used. Input: 20, Output: 2, Total: 22
       -- Tokens used. Input: 20, Output: 2, Total: 22
       -- Tokens used. Input: 20, Output: 2, Total: 22
       -- Tokens used. Input: 20, Output: 2, Total: 22
       -- Tokens used. Input: 20, Output: 2, Total: 22
       -- Tokens used. Input: 20, Output: 2, Total: 22
       -- Tokens used. Input: 20, Output: 2, Total: 22
       -- Tokens used. Input: 20, Output: 2, Total: 22
       Tokyo, Tokyo, Tokyo, Tokyo, Tokyo, Tokyo, Tokyo, Tokyo, Tokyo, Tokyo
       
        === Temperature: 1, TopP: 1 ===
       -- Tokens used. Input: 20, Output: 2, Total: 22
       -- Tokens used. Input: 20, Output: 2, Total: 22
       -- Tokens used. Input: 20, Output: 2, Total: 22
       -- Tokens used. Input: 20, Output: 2, Total: 22
       -- Tokens used. Input: 20, Output: 2, Total: 22
       -- Tokens used. Input: 20, Output: 2, Total: 22
       -- Tokens used. Input: 20, Output: 2, Total: 22
       -- Tokens used. Input: 20, Output: 2, Total: 22
       -- Tokens used. Input: 20, Output: 2, Total: 22
       -- Tokens used. Input: 20, Output: 2, Total: 22
       Tokyo, Tokyo, Tokyo, Tokyo, Tokyo, Tokyo, Tokyo, Tokyo, Tokyo, Tokyo
       
       Total execution time: 174.06 seconds (00:02:54.0583260)
       
       
     */
    public async Task TestTemperatureAndTopPWithExactQuestion()
    {
        var question = "What is the biggest city in the world by population? Answer with a single word without additional explanations.";
        WriteLine("------------------------------------------------");
        WriteLine(question);
        var model = "sonar";
        var stopwatch = System.Diagnostics.Stopwatch.StartNew();
        
        await SingleTestVariability(model, question, temperature: 0.0f, topP: 1.0f, attempts: 10);
        await SingleTestVariability(model, question, temperature: 0.5f, topP: 1.0f, attempts: 10);
        await SingleTestVariability(model, question, temperature: 1.0f, topP: 1.0f, attempts: 10);
        await SingleTestVariability(model, question, temperature: 1.9f, topP: 1.0f, attempts: 10);
        await SingleTestVariability(model, question, temperature: 1.0f, topP: 0.2f, attempts: 10);
        await SingleTestVariability(model, question, temperature: 1.0f, topP: 0.5f, attempts: 10);
        await SingleTestVariability(model, question, temperature: 1.0f, topP: 1.0f, attempts: 10);
        
        stopwatch.Stop();
        WriteLine($"Total execution time: {stopwatch.Elapsed.TotalSeconds:F2} seconds ({stopwatch.Elapsed})");
    }
    
    /*
     sonar
     
     What is the most beautiful city in the world? Despite it's an opinionated question, I want a single city name. Answer with a single word without additional explanations.
        === Temperature: 0, TopP: 1 ===
       -- Tokens used. Input: 34, Output: 1, Total: 35
       -- Tokens used. Input: 34, Output: 1, Total: 35
       -- Tokens used. Input: 34, Output: 1, Total: 35
       -- Tokens used. Input: 34, Output: 1, Total: 35
       -- Tokens used. Input: 34, Output: 1, Total: 35
       -- Tokens used. Input: 34, Output: 1, Total: 35
       -- Tokens used. Input: 34, Output: 1, Total: 35
       -- Tokens used. Input: 34, Output: 1, Total: 35
       -- Tokens used. Input: 34, Output: 1, Total: 35
       -- Tokens used. Input: 34, Output: 2, Total: 36
       Paris, Paris, Paris, Paris, Paris, Paris, Paris, Paris, Paris, Venice
       
        === Temperature: 0.5, TopP: 1 ===
       -- Tokens used. Input: 34, Output: 1, Total: 35
       -- Tokens used. Input: 34, Output: 1, Total: 35
       -- Tokens used. Input: 34, Output: 1, Total: 35
       -- Tokens used. Input: 34, Output: 1, Total: 35
       -- Tokens used. Input: 34, Output: 2, Total: 36
       -- Tokens used. Input: 34, Output: 1, Total: 35
       -- Tokens used. Input: 34, Output: 1, Total: 35
       -- Tokens used. Input: 34, Output: 1, Total: 35
       -- Tokens used. Input: 34, Output: 1, Total: 35
       -- Tokens used. Input: 34, Output: 1, Total: 35
       Paris, Chicago, Paris, Chicago, Prague, Chicago, Paris, Chicago, Chicago, Paris
       
        === Temperature: 1, TopP: 1 ===
       -- Tokens used. Input: 34, Output: 1, Total: 35
       -- Tokens used. Input: 34, Output: 1, Total: 35
       -- Tokens used. Input: 34, Output: 1, Total: 35
       -- Tokens used. Input: 34, Output: 1, Total: 35
       -- Tokens used. Input: 34, Output: 1, Total: 35
       -- Tokens used. Input: 34, Output: 1, Total: 35
       -- Tokens used. Input: 34, Output: 1, Total: 35
       -- Tokens used. Input: 34, Output: 1, Total: 35
       -- Tokens used. Input: 34, Output: 1, Total: 35
       -- Tokens used. Input: 34, Output: 1, Total: 35
       Paris, Paris, Paris, Paris, Chicago, Paris, Paris, Chicago, Chicago, Chicago
       
        === Temperature: 1.9, TopP: 1 ===
       -- Tokens used. Input: 34, Output: 1, Total: 35
       -- Tokens used. Input: 34, Output: 2, Total: 36
       -- Tokens used. Input: 34, Output: 1, Total: 35
       -- Tokens used. Input: 34, Output: 1, Total: 35
       -- Tokens used. Input: 34, Output: 1, Total: 35
       -- Tokens used. Input: 34, Output: 2, Total: 36
       -- Tokens used. Input: 34, Output: 1, Total: 35
       -- Tokens used. Input: 34, Output: 1, Total: 35
       -- Tokens used. Input: 34, Output: 1, Total: 35
       -- Tokens used. Input: 34, Output: 1, Total: 35
       Paris, Prague, Paris, Paris, Paris, Prague, Paris, Paris, Chicago, Chicago
       
        === Temperature: 1, TopP: 0.2 ===
       -- Tokens used. Input: 34, Output: 3, Total: 37
       -- Tokens used. Input: 34, Output: 1, Total: 35
       -- Tokens used. Input: 34, Output: 1, Total: 35
       -- Tokens used. Input: 34, Output: 1, Total: 35
       -- Tokens used. Input: 34, Output: 2, Total: 36
       -- Tokens used. Input: 34, Output: 2, Total: 36
       -- Tokens used. Input: 34, Output: 1, Total: 35
       -- Tokens used. Input: 34, Output: 1, Total: 35
       -- Tokens used. Input: 34, Output: 1, Total: 35
       -- Tokens used. Input: 34, Output: 1, Total: 35
       CapeTown, Chicago, Chicago, Paris, Venice, Prague, Chicago, Chicago, Paris, Paris
       
        === Temperature: 1, TopP: 0.5 ===
       -- Tokens used. Input: 34, Output: 1, Total: 35
       -- Tokens used. Input: 34, Output: 1, Total: 35
       -- Tokens used. Input: 34, Output: 1, Total: 35
       -- Tokens used. Input: 34, Output: 1, Total: 35
       -- Tokens used. Input: 34, Output: 1, Total: 35
       -- Tokens used. Input: 34, Output: 1, Total: 35
       -- Tokens used. Input: 34, Output: 1, Total: 35
       -- Tokens used. Input: 34, Output: 3, Total: 37
       -- Tokens used. Input: 34, Output: 1, Total: 35
       -- Tokens used. Input: 34, Output: 1, Total: 35
       Chicago, Paris, Paris, Paris, Chicago, Chicago, Chicago, CapeTown, Paris, Paris
       
       Total execution time: 189.49 seconds (00:03:09.4850486)
       
     */
    public async Task TestTemperatureAndTopPWithOpinionatedQuestion()
    {
        var question = "What is the most beautiful city in the world? Despite it's an opinionated question, I want a single city name. " +
                       "Answer with a single word without additional explanations.";
        WriteLine("------------------------------------------------");
        WriteLine(question);
        var model = "sonar";
        var stopwatch = System.Diagnostics.Stopwatch.StartNew();
        
        await SingleTestVariability(model, question, temperature: 0.0f, topP: 1.0f, attempts: 10);
        await SingleTestVariability(model, question, temperature: 0.5f, topP: 1.0f, attempts: 10);
        await SingleTestVariability(model, question, temperature: 1.0f, topP: 1.0f, attempts: 10);
        await SingleTestVariability(model, question, temperature: 1.9f, topP: 1.0f, attempts: 10);
        await SingleTestVariability(model, question, temperature: 1.0f, topP: 0.2f, attempts: 10);
        await SingleTestVariability(model, question, temperature: 1.0f, topP: 0.5f, attempts: 10);
        
        stopwatch.Stop();
        WriteLine($"Total execution time: {stopwatch.Elapsed.TotalSeconds:F2} seconds ({stopwatch.Elapsed})");
    }
    
    /*
     * sonar
     * 
       Explain what is photosynthesis in one sentence. Return strictly one sentence without formulas or sources.
        === Temperature: 0, TopP: 1 ===
       -- Tokens used. Input: 19, Output: 35, Total: 54
       -- Tokens used. Input: 19, Output: 29, Total: 48
       Photosynthesis is the process by which green plants, algae, and some bacteria convert light energy into chemical energy by using sunlight to transform carbon dioxide and water into glucose and oxygen.
       Photosynthesis is the process by which green plants, algae, and some microorganisms use sunlight to convert carbon dioxide and water into glucose and oxygen.
       
        === Temperature: 0.5, TopP: 1 ===
       -- Tokens used. Input: 19, Output: 26, Total: 45
       -- Tokens used. Input: 19, Output: 38, Total: 57
       Photosynthesis is the process by which green plants and certain other organisms use sunlight to convert carbon dioxide and water into glucose and oxygen.
       Photosynthesis is the process by which green plants, algae, and some microorganisms use sunlight to convert carbon dioxide and water into chemical energy stored in sugars, releasing oxygen as a byproduct.
       
        === Temperature: 1, TopP: 1 ===
       -- Tokens used. Input: 19, Output: 73, Total: 92
       -- Tokens used. Input: 19, Output: 26, Total: 45
       **Photosynthesis is the process by which plants, algae, and some microorganisms use sunlight to convert carbon dioxide and water into glucose and oxygen.** This process transforms light energy into chemical energy stored in sugars, supporting life by producing food and oxygen. Chlorophyll in chloroplasts captures sunlight to drive the chemical reactions involved, releasing oxygen as a byproduct.
       Photosynthesis is the process by which green plants and certain other organisms use sunlight to convert carbon dioxide and water into glucose and oxygen.
       
        === Temperature: 1.9, TopP: 1 ===
       -- Tokens used. Input: 19, Output: 37, Total: 56
       -- Tokens used. Input: 19, Output: 35, Total: 54
       **Photosynthesis is the process by which green plants and certain other organisms convert light energy into chemical energy to make glucose from carbon dioxide and water, releasing oxygen as a byproduct.**
       **Photosynthesis is the process by which plants, algae, and certain microorganisms use sunlight to convert carbon dioxide and water into glucose (energy-rich sugars) and oxygen.**
       
        === Temperature: 1, TopP: 0.2 ===
       -- Tokens used. Input: 19, Output: 26, Total: 45
       -- Tokens used. Input: 19, Output: 29, Total: 48
       Photosynthesis is the process by which green plants and certain other organisms use sunlight to convert carbon dioxide and water into glucose and oxygen.
       Photosynthesis is the process by which green plants, algae, and some microorganisms use sunlight to convert carbon dioxide and water into glucose and oxygen.
       
        === Temperature: 1, TopP: 0.5 ===
       -- Tokens used. Input: 19, Output: 29, Total: 48
       -- Tokens used. Input: 19, Output: 26, Total: 45
       Photosynthesis is the process by which green plants, algae, and some microorganisms use sunlight to convert carbon dioxide and water into glucose and oxygen.
       Photosynthesis is the process by which green plants and certain other organisms use sunlight to convert carbon dioxide and water into glucose and oxygen.
       
       Total execution time: 42.90 seconds (00:00:42.8984864)
       
     */
    public async Task TestTemperatureAndTopPWithOneSentenceExplanation()
    {
        var question = "Explain what is photosynthesis in one sentence. Return strictly one sentence without formulas or sources.";
        WriteLine("------------------------------------------------");
        WriteLine(question);
        var model = "sonar";
        var stopwatch = System.Diagnostics.Stopwatch.StartNew();

        await SingleTestVariability(model, question, temperature: 0.0f, topP: 1.0f, attempts: 2, separator: Environment.NewLine);
        await SingleTestVariability(model, question, temperature: 0.5f, topP: 1.0f, attempts: 2, separator: Environment.NewLine);
        await SingleTestVariability(model, question, temperature: 1.0f, topP: 1.0f, attempts: 2, separator: Environment.NewLine);
        await SingleTestVariability(model, question, temperature: 1.9f, topP: 1.0f, attempts: 2, separator: Environment.NewLine);
        await SingleTestVariability(model, question, temperature: 1.0f, topP: 0.2f, attempts: 2, separator: Environment.NewLine);
        await SingleTestVariability(model, question, temperature: 1.0f, topP: 0.5f, attempts: 2, separator: Environment.NewLine);
        
        stopwatch.Stop();
        WriteLine($"Total execution time: {stopwatch.Elapsed.TotalSeconds:F2} seconds ({stopwatch.Elapsed})");
    }
    /*
     * sonar-pro
     * 
       Explain what is photosynthesis in one sentence. Return strictly one sentence without formulas or sources.
        === Temperature: 0, TopP: 1 ===
       -- Tokens used. Input: 19, Output: 33, Total: 52
       -- Tokens used. Input: 19, Output: 32, Total: 51
       Photosynthesis is the process by which plants, algae, and some microorganisms use sunlight to convert carbon dioxide and water into food (sugars) and oxygen.
       Photosynthesis is the process by which plants, algae, and some microorganisms use sunlight to convert carbon dioxide and water into food (glucose) and oxygen.
       
        === Temperature: 0.5, TopP: 1 ===
       -- Tokens used. Input: 19, Output: 26, Total: 45
       -- Tokens used. Input: 19, Output: 26, Total: 45
       Photosynthesis is the process by which green plants and some other organisms use sunlight to convert carbon dioxide and water into sugars and oxygen.
       Photosynthesis is the process by which plants and certain other organisms use light energy to convert carbon dioxide and water into glucose and oxygen.
       
        === Temperature: 1, TopP: 1 ===
       -- Tokens used. Input: 19, Output: 34, Total: 53
       -- Tokens used. Input: 19, Output: 32, Total: 51
       Photosynthesis is the process by which plants, algae, and some microorganisms use sunlight to convert carbon dioxide and water into glucose (a type of sugar) and oxygen.
       Photosynthesis is the process by which plants, algae, and some bacteria use sunlight to convert carbon dioxide and water into food (sugars) and oxygen.
       
        === Temperature: 1.9, TopP: 1 ===
       -- Tokens used. Input: 19, Output: 39, Total: 58
       -- Tokens used. Input: 19, Output: 34, Total: 53
       Photosynthesis is the process by which plants, algae, and some microorganisms use sunlight to convert carbon dioxide and water into chemical energy in the form of sugars, releasing oxygen as a byproduct.
       Photosynthesis is the process by which green plants, algae, and some bacteria convert light energy into chemical energy, using water and carbon dioxide to produce sugars and release oxygen.
       
        === Temperature: 1, TopP: 0.2 ===
       -- Tokens used. Input: 19, Output: 32, Total: 51
       -- Tokens used. Input: 19, Output: 32, Total: 51
       Photosynthesis is the process by which green plants and some other organisms use sunlight to convert carbon dioxide and water into glucose (a type of sugar) and oxygen.
       Photosynthesis is the process by which plants, algae, and some bacteria use sunlight to convert carbon dioxide and water into food (sugars) and oxygen.
       
        === Temperature: 1, TopP: 0.5 ===
       -- Tokens used. Input: 19, Output: 33, Total: 52
       -- Tokens used. Input: 19, Output: 26, Total: 45
       Photosynthesis is the process by which plants, algae, and some microorganisms use sunlight to convert carbon dioxide and water into food (sugars) and oxygen.
       Photosynthesis is the process by which green plants and some other organisms use sunlight to convert carbon dioxide and water into sugars and oxygen.
       
       Total execution time: 33.41 seconds (00:00:33.4056130)
       
     */
    public async Task TestTemperatureAndTopPWithOneSentenceExplanation_Pro()
    {
        var question = "Explain what is photosynthesis in one sentence. Return strictly one sentence without formulas or sources.";
        WriteLine("------------------------------------------------");
        WriteLine(question);
        var model = "sonar-pro";
        var stopwatch = System.Diagnostics.Stopwatch.StartNew();

        await SingleTestVariability(model, question, temperature: 0.0f, topP: 1.0f, attempts: 2, separator: Environment.NewLine);
        await SingleTestVariability(model, question, temperature: 0.5f, topP: 1.0f, attempts: 2, separator: Environment.NewLine);
        await SingleTestVariability(model, question, temperature: 1.0f, topP: 1.0f, attempts: 2, separator: Environment.NewLine);
        await SingleTestVariability(model, question, temperature: 1.9f, topP: 1.0f, attempts: 2, separator: Environment.NewLine);
        await SingleTestVariability(model, question, temperature: 1.0f, topP: 0.2f, attempts: 2, separator: Environment.NewLine);
        await SingleTestVariability(model, question, temperature: 1.0f, topP: 0.5f, attempts: 2, separator: Environment.NewLine);
        
        stopwatch.Stop();
        WriteLine($"Total execution time: {stopwatch.Elapsed.TotalSeconds:F2} seconds ({stopwatch.Elapsed})");
    }
    
    private async Task SingleTestVariability(
        string model,
        string question, 
        float temperature = 1.0f,
        float topP = 1.0f,
        int attempts = 10,
        string separator = ", ")
    {
        var chatClient = _client.GetChat(model);
        chatClient.Temperature = temperature;
        chatClient.TopP = topP;
        
        WriteLine($" === Temperature: {temperature}, TopP: {topP} ===");
        var responses = new string[attempts];
        for (var i = 0; i < attempts; i++)
        {
            responses[i] = await chatClient.Send(question);
        }
        WriteLine($"{string.Join(separator, responses)}");
        WriteLine();
    }
}