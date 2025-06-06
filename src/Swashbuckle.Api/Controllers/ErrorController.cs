namespace Swashbuckle.Api.Controllers;

[ApiExplorerSettings(IgnoreApi = true)]
[ApiController]
[Route("[controller]")]
public class ErrorController : ControllerBase
{
    public IActionResult HandleError() => Problem();
}
