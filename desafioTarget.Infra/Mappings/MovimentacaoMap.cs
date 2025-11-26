using desafioTarget.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace desafioTarget.Infra.Mappings
{
    public class MovimentacaoMap : IEntityTypeConfiguration<MovimentacaoEstoque>
    {
        public void Configure(EntityTypeBuilder<MovimentacaoEstoque> builder)
        {
            builder.ToTable("MovimentacoesEstoque");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.Descricao)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(m => m.Tipo)
                .HasConversion<string>(); // grava "Entrada"/"Saida" no banco para ficar mais legível

            builder.Property(m => m.DataMovimentacao)
                .HasDefaultValueSql("GETDATE()");
        }
    }
}