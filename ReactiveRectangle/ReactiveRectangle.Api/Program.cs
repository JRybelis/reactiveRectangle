using ReactiveRectangle.Infrastructure.Interfaces;
using ReactiveRectangle.Infrastructure.IO;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Infrastructure
var jsonPath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "rectangle.json");
builder.Services.AddSingleton<IJsonStorage>(new JsonStorage(jsonPath));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();



app.Run();