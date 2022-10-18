using Estagio.Domain.Entities;
using System.Collections.Generic;
using Template.Domain.Interfaces;

namespace Estagio.Domain.Interfaces
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        IEnumerable<Produto> GetAll();

        bool Delete(long id);
    }
}
