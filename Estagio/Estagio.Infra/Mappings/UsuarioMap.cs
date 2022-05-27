using Estagio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Estagio.Data.Mappings
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.Property(x => x.Id).IsRequired();

            builder.Property(x => x.Nome).HasMaxLength(80).IsRequired().HasColumnName("Nome"); // tamanho maximo 300, é obrigatório e tem nome no banco "Nome"
        }
    }
}
