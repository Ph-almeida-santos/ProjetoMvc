using Microsoft.EntityFrameworkCore;
using WebEmMVC.Models;

namespace WebEmMVC.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<FormularioCliente> Formularios { get; set; }
         
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(AppConfig.GetConnectionString());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FormularioCliente>()
                .Property(n => n.Nome)
                .HasColumnType("nvarchar(100)");

            modelBuilder.Entity<FormularioCliente>()
                .Property(e => e.Empresa)
                .HasColumnType("nvarchar(100)");

            modelBuilder.Entity<FormularioCliente>()
                .Property(c => c.Email)
                .HasColumnType("nvarchar(100)");

            modelBuilder.Entity<FormularioCliente>()
                .Property(c => c.Telefone)
                .HasColumnType("nvarchar(15)");

            modelBuilder.Entity<FormularioCliente>()
                .Property(c => c.Categoria)
                .HasColumnType("nvarchar(1)");
            modelBuilder.Entity<FormularioCliente>()
                .Property(d => d.Descricao)
                .HasColumnType("TEXT");

            modelBuilder.Entity<FormularioCliente>()
                .Property(c => c.DataCriacao)
                .HasColumnType("date");
        }
    }
}
