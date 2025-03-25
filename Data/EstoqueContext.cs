using Microsoft.EntityFrameworkCore;
using ProjetoEstoque.Models;

namespace ProjetoEstoque.Data
{
    public class EstoqueContext : DbContext
    {
        public EstoqueContext(DbContextOptions<EstoqueContext> options) : base(options)
        {
        }

        public DbSet<Produto>? Produtos { get; set; }
        public DbSet<Categoria>? Categorias { get; set; }
      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Definir relação entre Produto e Categoria (1:N)
            modelBuilder.Entity<Produto>()
                .HasOne(p => p.Categoria)
                .WithMany(c => c.Produtos)
                .HasForeignKey(p => p.CategoriaId);

        }
    }
}
