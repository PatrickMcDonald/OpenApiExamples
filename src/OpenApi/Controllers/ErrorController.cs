using Microsoft.AspNetCore.Mvc;

namespace OpenApi.Controllers;

[ApiExplorerSettings(IgnoreApi = true)]
[ApiController]
[Route("[controller]")]
public class ErrorController : ControllerBase
{
    public IActionResult HandleError() => Problem();
}
