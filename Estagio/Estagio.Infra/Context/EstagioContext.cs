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
        public DbSet<Produto> Produto { get; set; }
        public DbSet<CompraProduto> CompraProduto { get; set; }
        public DbSet<Compra> Compra { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new CompraMap());
            modelBuilder.ApplyConfiguration(new ProdutoMap());
            modelBuilder.ApplyConfiguration(new CompraProdutoMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
