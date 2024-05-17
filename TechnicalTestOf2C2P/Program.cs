using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TechnicalTestOf2C2P.Contexts;
using TechnicalTestOf2C2P.Repositories;
using TechnicalTestOf2C2P.Repositories.IRepositories;
using TechnicalTestOf2C2P.Services;
using TechnicalTestOf2C2P.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    var fileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var filePath = Path.Combine(AppContext.BaseDirectory, fileName);
    c.IncludeXmlComments(filePath);
});

// Context
builder.Services.AddDbContext<DbContextApplication>();

// Repositories
builder.Services.AddScoped<ITransactionsRepository, TransactionsRepository>();

// Services
builder.Services.AddScoped<ITransactionsService, TransactionsService>();

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
