using AI.Experiments.Console;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

// Build configuration
var environment = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT") ?? "Development";

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration(configuration => configuration
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true))
    .ConfigureServices(services =>
    {
        // services.AddTransient<IMessageService, MessageService>();
        // services.AddTransient<MessageProcessor>();
    })
    .Build();

var openAiSettings = new OpenAiSettings();
host.Services.GetRequiredService<IConfiguration>().GetSection("OpenAI").Bind(openAiSettings);

WriteLine($"Environment: {environment}");

var openAi = new OpenAiExperiments(openAiSettings);
//await openAi.GetAvailableModels();
await openAi.StreamMessages();
await openAi.FirstChat();