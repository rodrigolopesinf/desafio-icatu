using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SolicitacaoCompraAgg = SistemaCompra.Domain.SolicitacaoCompraAggregate;

namespace SistemaCompra.Infra.Data.SolicitacaoCompra
{
    public class SolicitacaoCompraConfiguration : IEntityTypeConfiguration<SolicitacaoCompraAgg.SolicitacaoCompra>
    {
        public void Configure(EntityTypeBuilder<SolicitacaoCompraAgg.SolicitacaoCompra> builder)
        {
            builder.ToTable("Compra");

            builder.OwnsOne(x => x.NomeFornecedor)
            .Property(x => x.Nome)
            .HasColumnName("Fornecedor")
            .IsRequired(true);

            builder.OwnsOne(x => x.UsuarioSolicitante)
            .Property(x => x.Nome)
            .HasColumnName("Solicitante")
            .IsRequired(true);

            builder.OwnsOne(x => x.CondicaoPagamento)
            .Property(x => x.Valor)
            .HasColumnType("int")
            .HasColumnName("CondicaoPagamento")
            .IsRequired(true);

            builder.Property(x => x.Situacao)
            .HasColumnType("int")
            .HasColumnName("Situacao")
            .IsRequired(true);
        }
    }
}

