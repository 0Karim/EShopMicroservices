using Carter;

var builder = WebApplication.CreateBuilder(args);

//Add services to the conatiner
builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

var app = builder.Build();

//Configure the http request pipline
app.MapCarter();

app.Run();
