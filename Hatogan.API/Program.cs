using Carter;
using Hatogan.API.Middlewares;
using Hatogan.Application;
using Hatogan.Application.UseCases.Animals;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureApplicationLayer(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAnimalEndPoint();
//app.MapCarter();
app.UseMiddleware<ErrorHandlerMiddleware>();

app.Run();

