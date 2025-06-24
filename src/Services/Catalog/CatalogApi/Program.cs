var builder = WebApplication.CreateBuilder(args);


//Add Services to the container.

builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});
var app = builder.Build();

//http request pipeline configuration

app.MapCarter();

app.Run();
