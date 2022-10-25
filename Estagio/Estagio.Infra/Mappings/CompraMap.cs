using Estagio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Estagio.Data.Mappings
{
    public class CompraMap : IEntityTypeConfiguration<Compra>
    {
        public void Configure(EntityTypeBuilder<Compra> builder)
        {
            builder.Property(x => x.Id).IsRequired();

            builder.Property(x => x.UsuarioId).HasColumnName("UsuarioId");
            builder.Property(x => x.Ativo).HasColumnName("Ativo");
        }
    }
}
