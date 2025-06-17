var builder = WebApplication.CreateBuilder(args);


//Add Services to the container.

var app = builder.Build();

//http request pipeline configuration

app.Run();
