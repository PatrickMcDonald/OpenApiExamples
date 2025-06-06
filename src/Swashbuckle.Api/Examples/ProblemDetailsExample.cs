using Swashbuckle.AspNetCore.Filters;

namespace Swashbuckle.Api.Examples;

public class ProblemDetailsExample : IExamplesProvider<ProblemDetails>
{
    public ProblemDetails GetExamples()
    {
        return new()
        {
            Type = "https://tools.ietf.org/html/rfc9110#section-15.6.1",
            Title = "An error occurred while processing your request.",
            Status = 500,
            Extensions = new Dictionary<string, object?>
            {
                { "traceId", "00-a9bce74ac58bbb5d0319fe9af70b99fe-f87466ee9da71b4a-00" },
            },
        };
    }
}
