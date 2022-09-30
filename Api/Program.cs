using Domain.Models;
using Repository;
using Repository.RepositoryPattern;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContextFactory<ApplicationDbContext>();

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddScoped<IRepository<Company>,CompanyRepository>();
builder.Services.AddScoped<IRepository<Person>, PersonRepository>();

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
