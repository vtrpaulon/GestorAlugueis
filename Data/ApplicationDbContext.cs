using GestorAlugueis.Entities;
using Microsoft.EntityFrameworkCore;

namespace GestorAlugueis.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Imovel> Imoveis { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Imovel>()
                .Property(i => i.ValorAluguel)
                .HasPrecision(18, 2);
        }
    }
}