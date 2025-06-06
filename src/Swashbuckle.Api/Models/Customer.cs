namespace Swashbuckle.Api.Models;

public record Customer
{
    /// <summary>
    /// The unique identifier for the customer.
    /// </summary>
    public int Id { get; init; }

    /// <summary>
    /// The name of the customer.
    /// </summary>
    public required string Name { get; init; }
}
