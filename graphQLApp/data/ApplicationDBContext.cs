using graphQLApp.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace graphQLApp.data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions opt) : base(opt)
        {
                
        }
        
        
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>().HasKey(p => p.CodigoBarras);

        }
    }
}