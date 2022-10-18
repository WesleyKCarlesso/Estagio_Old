using Estagio.Data.Context;
using Estagio.Domain.Entities;
using Estagio.Domain.Interfaces;
using System;
using System.Collections.Generic;
using Template.Data.Repositories;
using Template.Domain.Interfaces;

namespace Estagio.Data.Repositories
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(EstagioContext context)
            : base(context) { }

        public IEnumerable<Produto> GetAll()
        {
            return Query(x => x.Ativo);
        }

        public bool Delete(long id)
        {
            Produto produto = this.Find(x => x.Id == id && x.Ativo);

            if (produto == null)
            {
                throw new Exception("Produto não encontrado");
            }

            return this.Delete(produto);
        }
    }
}
