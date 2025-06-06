using Swashbuckle.AspNetCore.Filters;

namespace Swashbuckle.Api.Examples;

public class CustomerExample : IExamplesProvider<Customer>
{
    public Customer GetExamples()
    {
        return new Customer
        {
            Id = 2,
            Name = "Mick Murphy"
        };
    }
}
