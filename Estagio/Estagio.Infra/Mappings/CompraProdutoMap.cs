using Estagio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Estagio.Data.Mappings
{
    public class CompraProdutoMap : IEntityTypeConfiguration<CompraProduto>
    {
        public void Configure(EntityTypeBuilder<CompraProduto> builder)
        {
            builder.Property(x => x.Id).IsRequired();

            builder.Property(x => x.ProdutoId).HasColumnName("ProdutoId");
            builder.Property(x => x.CompraId).HasColumnName("CompraId");
            builder.Property(x => x.Ativo).HasColumnName("Ativo");
            builder.Property(x => x.Valor).HasColumnName("Valor");
            builder.Property(x => x.Quantidade).HasColumnName("Quantidade");
        }
    }
}
