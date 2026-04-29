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

        // Adicione esta propriedade
        public DbSet<Imovel> Imoveis { get; set; }
    }
}