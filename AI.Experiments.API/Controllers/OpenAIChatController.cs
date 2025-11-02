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
        [FromQuery] double temperature,
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
}