using Microsoft.EntityFrameworkCore;
using Repositorio;
using Servicos;
using TizzaAula;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(option =>
    option.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Apresentacao"))
);

builder.Services.AddScoped<IServPizzaria, ServPizzaria>();
builder.Services.AddScoped<IRepoPizzaria, RepoPizzaria>();

builder.Services.AddScoped<IServPromover, ServPromover>();
builder.Services.AddScoped<IRepoPromover, RepoPromover>();

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
