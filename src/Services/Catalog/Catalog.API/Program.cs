using BuildingBlocks.Behaviors;
using Carter;

var builder = WebApplication.CreateBuilder(args);


var assembly = typeof(Program).Assembly;

//Add Service to the container

builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(assembly);
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
});
builder.Services.AddValidatorsFromAssembly(assembly);
builder.Services.AddCarter();
builder.Services.AddMarten(otps =>
{
    otps.Connection(builder.Configuration.GetConnectionString("Database")!);
}).UseLightweightSessions();





var app = builder.Build();

//Configure the http request pipline
app.MapCarter();

app.Run();
