using MartinCostello.OpenApi;

using Microsoft.AspNetCore.Mvc;

using OpenApi.Examples;

using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.
builder.Services
    .AddControllers(options =>
        {
            options.Filters.Add(new ProducesAttribute("application/json"));
        })
    .ConfigureApiBehaviorOptions(options =>
        {
            options.SuppressMapClientErrors = true;
        });

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddOpenApiExtensions(options =>
{
    // Always return the server URLs in the OpenAPI document
    // Only enable this option in production if you are sure
    // you wish to explicitly expose your server URLs.
    options.AddServerUrls = true;

    options.DefaultServerUrl = "https://dev.mcdonaldconsulting.net";

    // Add examples for OpenAPI operations and components
    options.AddExamples = true;

    options.SerializationContexts.Add(AppJsonSerializerContext.Default);

    options.AddExample<ProblemDetails, ProblemDetailsExampleProvider>();

    options.AddXmlComments<Program>();
});

// Required if AddServerUrls=true
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler("/error");

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("openapi/v1.json", "Open API V1");
    });
}

app.UseAuthorization();

app.MapGet("/", () => "Welcome to the OpenAPI Example API!")
    .ExcludeFromDescription();

app.MapDefaultEndpoints();

app.MapControllers();

await app.RunAsync();
