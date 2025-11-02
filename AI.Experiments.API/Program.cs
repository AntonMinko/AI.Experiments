using AI.Experiments.OpenAIProvider;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var openAiKey = builder.Configuration["OpenAi:Key"] ?? throw new InvalidOperationException("OpenAI API key not found");
builder.Services.AddSingleton(new OpenAiClient(openAiKey));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "AI Experiments API V1");
        c.RoutePrefix = "api/swagger";
    });
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
