namespace OpenApi.Models;

public record Customer
{
    public int Id { get; init; }

    public required string Name { get; init; }
}
