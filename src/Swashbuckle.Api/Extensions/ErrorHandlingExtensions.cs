namespace Swashbuckle.Api.Extensions;

public static class ErrorHandlingExtensions
{
    public static void AddExceptionHandling(this WebApplication app)
    {
        app.UseExceptionHandler(errorApp =>
        {
            errorApp.Run(async context =>
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "application/problem+json";
                var problemDetails = new ProblemDetails
                {
                    Type = "https://httpstatuses.org/500",
                    Title = "An unexpected error occurred.",
                    Status = context.Response.StatusCode,
                };
                await context.Response.WriteAsJsonAsync(problemDetails);
            });
        });
    }
}
