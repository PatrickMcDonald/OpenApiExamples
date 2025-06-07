using System.Text.Json.Serialization;

using Microsoft.AspNetCore.Mvc;

namespace OpenApi.Configuration;

[JsonSerializable(typeof(Customer))]
[JsonSerializable(typeof(ProblemDetails))]
[JsonSourceGenerationOptions(
    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
    PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase,
    WriteIndented = true
)]
public partial class AppJsonSerializerContext : JsonSerializerContext
{
}
