using DesafioSiemens.Dominio.Relacao;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IWantApp.Infra.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Cliente> clientes { get; set; }
    public DbSet<Cidade> cidades { get; set; }
    public IEnumerable<object> Cidades { get; internal set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Cliente>()
            .Property(c => c.NomeCompleto).IsRequired();
        builder.Entity<Cliente>()
            .Property(c => c.Sexo).HasMaxLength(1);
        builder.Entity<Cliente>()
            .Property(c => c.DataNascimento).IsRequired();
        builder.Entity<Cliente>()
            .Property(c => c.Idade).HasMaxLength(2);
      /*  builder.Entity<Cliente>()
    .HasOne(c => c.Cidade)
    .WithMany()
    .HasForeignKey(c => c.Cidade)
    .OnDelete(DeleteBehavior.Restrict);*/



        builder.Entity<Cidade>()
            .Property(e => e.Nome).IsRequired();
        builder.Entity<Cidade>()
            .Property(e => e.Estado).IsRequired();
            }

    protected override void ConfigureConventions(ModelConfigurationBuilder configuration)
    {
        configuration.Properties<string>()
            .HaveMaxLength(100);
    }
}