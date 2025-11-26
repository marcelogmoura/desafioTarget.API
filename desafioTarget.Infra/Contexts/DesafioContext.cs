using desafioTarget.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace desafioTarget.Infra.Contexts
{
    public class DesafioContext : DbContext
    {
        public DesafioContext(DbContextOptions<DesafioContext> options) : base(options) { }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<MovimentacaoEstoque> Movimentacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DesafioContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}