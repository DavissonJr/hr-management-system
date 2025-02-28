using Microsoft.EntityFrameworkCore;
using RH.API.Domain;

namespace RH.API.Infra.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext>opts) : base(opts)
    {
        
    }
    public DbSet<Colaborador> ? Colaboradores { get; set; }
    public DbSet<Empresa> ? Empresas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
