using AI.Experiments.OpenAIProvider;
using Microsoft.AspNetCore.Mvc;

namespace AI.Experiments.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OpenAIChatController : ControllerBase
{
    private readonly OpenAiClient _openAiClient;

    public OpenAIChatController(OpenAiClient openAiClient)
    {
        _openAiClient = openAiClient;
    }

    [HttpGet("chat")]
    public async Task<IActionResult> GetChat(
        [FromQuery] string model,
        [FromQuery] float temperature,
        [FromQuery] string message)
    {
        if (string.IsNullOrWhiteSpace(model))
        {
            return BadRequest("Model parameter is required");
        }

        if (string.IsNullOrWhiteSpace(message))
        {
            return BadRequest("Message parameter is required");
        }

        try
        {
            var chatClient = _openAiClient.GetChatClient(model);
            var response = await chatClient.SendChatMessage(message, temperature);

            return Ok(new { response });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { error = ex.Message });
        }
    }

    [HttpGet("chat/stream")]
    public async Task StreamChat(
        [FromQuery] string model,
        [FromQuery] float temperature = 0.5f,
        [FromQuery] float topP = 0.9f,
        [FromQuery] string message = "")
    {
        Response.Headers.Append("Content-Type", "text/plain; charset=utf-8");
        Response.Headers.Append("Cache-Control", "no-cache");
        Response.Headers.Append("Connection", "keep-alive");

        var chatClient = _openAiClient.GetChatClient(model);

        await foreach (var chunk in chatClient.StreamChatMessage(message, temperature, topP))
        {
            await Response.WriteAsync(chunk);
            await Response.Body.FlushAsync();
        }
    }
}