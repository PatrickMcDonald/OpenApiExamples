using MartinCostello.OpenApi;

using Microsoft.AspNetCore.Mvc;

namespace OpenApi.Examples;

public class ProblemDetailsExampleProvider : IExampleProvider<ProblemDetails>
{
    public static ProblemDetails GenerateExample()
    {
        return new ProblemDetails
        {
            Type = "https://tools.ietf.org/html/rfc9110#section-15.6.1",
            Title = "An error occurred while processing your request.",
            Status = 500,
            Extensions = new Dictionary<string, object?>
            {
                ["traceId"] = "01234567-1234-0123-0123-0123456789AB"
            },
        };
    }
}
