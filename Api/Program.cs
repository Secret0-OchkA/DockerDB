using DockerTestBD.Api.Models.EF;
using DockerTestBD.Api.Models.EF.Factories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApiContext>(options =>
{
    ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
    configurationBuilder.SetBasePath(Directory.GetCurrentDirectory());
    configurationBuilder.AddJsonFile("appsettings.json");
    IConfigurationRoot config = configurationBuilder.Build();

    string connectionStr = config.GetConnectionString("Postgres");

    options.UseNpgsql(connectionStr);
});

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
