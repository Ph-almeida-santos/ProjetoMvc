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
    }
}
