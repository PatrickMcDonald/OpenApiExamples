using System.ComponentModel;

using MartinCostello.OpenApi;

namespace OpenApi.Models;

[OpenApiExample<Customer>]
public record Customer : IExampleProvider<Customer>
{
    [Description("The unique identifier for the customer.")]
    public int Id { get; init; }

    [Description("The name of the customer.")]
    public required string Name { get; init; }

    public static Customer GenerateExample()
    {
        return new Customer
        {
            Id = 1,
            Name = "John Doe",
        };
    }
}
