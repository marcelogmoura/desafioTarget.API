using desafioTarget.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace desafioTarget.Infra.Mappings
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produtos");

            builder.HasKey(p => p.Id); 
                        
            builder.HasIndex(p => p.CodigoProduto).IsUnique();

            builder.Property(p => p.DescricaoProduto)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(p => p.Estoque)
                .IsRequired();
        }
    }
}