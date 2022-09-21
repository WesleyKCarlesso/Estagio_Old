using Estagio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Estagio.Data.Mappings
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.Property(x => x.Id).IsRequired();

            builder.Property(x => x.Preco).HasColumnName("Preco");
            builder.Property(x => x.Ativo).HasColumnName("Ativo");
            builder.Property(x => x.Marca).HasColumnName("Marca");
            builder.Property(x => x.Nome).HasColumnName("Nome");
            builder.Property(x => x.Quantidade).HasColumnName("Quantidade");
        }
    }
}
