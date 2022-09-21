using Estagio.Data.Context;
using Estagio.Domain.Entities;
using Estagio.Domain.Interfaces;
using Template.Data.Repositories;
using Template.Domain.Interfaces;

namespace Estagio.Data.Repositories
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(EstagioContext context)
            : base(context) { }
    }
}
