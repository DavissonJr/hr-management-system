using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RH.API.Infra.Context;
using RH.API.Infra.Interfaces;
using RH.API.Infra.Repositories;
using RH.API.Services.Interface;
using RH.API.Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("RhConnection");

builder.Services.AddScoped<IDbConnection>(provider =>
{
    SqlConnection connection = new SqlConnection(connectionString);
    connection.Open();
    return connection;
});

builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(connectionString));
#region Servico
builder.Services.AddScoped<IEmpresaService, EmpresaService>();
builder.Services.AddScoped<IColaboradorService, ColaboradoresService>();
#endregion
#region Repositório
builder.Services.AddScoped<IEmpresaRepository, EmpresaRepository>();
builder.Services.AddScoped<IColaboradoresRepository, ColaboradoresRepository>();
#endregion
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
