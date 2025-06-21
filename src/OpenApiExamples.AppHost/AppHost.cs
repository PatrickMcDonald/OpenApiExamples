var builder = DistributedApplication.CreateBuilder(args);

var openApi = builder.AddProject<Projects.OpenApi>("openapi")
    .WithUrlForEndpoint("https", url => { url.Url = "/scalar"; url.DisplayText = "Scalar Docs"; })
    .WithUrlForEndpoint("https", _ => new() { Url = "/swagger", DisplayText = "Swagger UI" });

builder.AddProject<Projects.Swashbuckle_Api>("swashbuckle-api")
    .WithUrlForEndpoint("https", url => { url.Url = "/scalar"; url.DisplayText = "Scalar Docs"; })
    .WithUrlForEndpoint("https", _ => new() { Url = "/swagger", DisplayText = "Swagger UI" })
    .WithExplicitStart();

await builder.Build().RunAsync();
