using Memberships.Api.Endpoints;
using Memberships.Application;
using Memberships.Infrastructure;
using Scalar.AspNetCore;


var builder = WebApplication.CreateBuilder(args);

// --------------------
// Services
// --------------------
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);


builder.Services.AddOpenApi();


builder.Services.AddHttpsRedirection(options =>
{
    options.HttpsPort = 443;
});

var app = builder.Build();

// --------------------
// Pipeline
// --------------------
if (app.Environment.IsDevelopment())
{

    app.MapOpenApi();
    app.MapScalarApiReference(options =>
    {
        options
            .WithTitle("Memberships API")
            .WithTheme(ScalarTheme.Default)
            .WithOpenApiRoutePattern("/openapi/v1.json");
    });
}

app.UseHttpsRedirection();

// --------------------
// Endpoints
// --------------------
app.MapGet("/", () => Results.Ok(new
{
    name = "Memberships API",
    status = "running"
}));

app.MapMembersEndpoints(); 

app.Run();
