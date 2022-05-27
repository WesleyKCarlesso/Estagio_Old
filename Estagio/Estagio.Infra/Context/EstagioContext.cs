using Estagio.Data.Mappings;
using Estagio.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Estagio.Data.Context
{
    public class EstagioContext : DbContext
    {
        public EstagioContext(DbContextOptions<EstagioContext> option)
            : base(option)
        {

        }

        #region DbSets

        public DbSet<Usuario> Usuario { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
