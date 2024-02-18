using Repository;
using Services;

var builder = WebApplication.CreateBuilder(args);

string jsonPath = $"{AppDomain.CurrentDomain.BaseDirectory}\\File.json";

if (!File.Exists(jsonPath))
{
    var file = File.Create(jsonPath);
    file.Close();
}

// Save services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IService, Service>();
builder.Services.AddScoped<IRepository, Repository.Repository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
