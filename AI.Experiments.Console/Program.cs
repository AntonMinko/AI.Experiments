using AI.Experiments.OpenAI;
using Microsoft.Extensions.Configuration;

// Build configuration
var environment = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT") ?? "Development";

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true)
    .Build();

Console.WriteLine($"Environment: {environment}");
Console.WriteLine($"Log Level: {configuration["Logging:LogLevel:Default"]}");

var openAiApiKey = configuration["OpenAi:Key"]!;
var openAiClient = new OpenAiClient(openAiApiKey);
var response = await openAiClient.SendChatMessage($"Who are you?");
Console.WriteLine(response);