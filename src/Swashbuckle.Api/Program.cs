using System.Reflection;

using Scalar.AspNetCore;

using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.

builder.Services.AddControllers(options =>
    {
        options.Filters.Add(new ProducesAttribute("application/json"));
    })
    .ConfigureApiBehaviorOptions(options =>
    {
        options.SuppressMapClientErrors = true;
    });

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.ExampleFilters();
    options.EnableAnnotations();

    // using System.Reflection;
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

builder.Services.AddSwaggerExamplesFromAssemblyOf<Swashbuckle.Api.Examples.CustomerExample>();

var app = builder.Build();

// Configure the HTTP request pipeline.
//app.AddExceptionHandling();
app.UseExceptionHandler("/error");

if (app.Environment.IsDevelopment())
{
    app.MapSwagger();

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Swashbuckle API V1");
    });

    app.MapScalarApiReference(options =>
    {
        options.OpenApiRoutePattern = "swagger/{documentName}/swagger.json";
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapDefaultEndpoints();

app.MapControllers();

app.Run();
