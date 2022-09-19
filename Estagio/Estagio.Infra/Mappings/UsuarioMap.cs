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
            builder.Property(x => x.Login).HasColumnName("Login");
            builder.Property(x => x.Senha).IsRequired().HasColumnName("Senha");
            builder.Property(x => x.Email).HasColumnName("Email");
            builder.Property(x => x.Telefone).HasColumnName("Telefone");
            builder.Property(x => x.Admin).HasColumnName("Admin");
            builder.Property(x => x.Ativo).HasColumnName("Ativo");
        }
    }
}
