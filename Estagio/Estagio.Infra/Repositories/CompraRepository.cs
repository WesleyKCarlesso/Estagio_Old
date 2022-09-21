using Estagio.Data.Context;
using Estagio.Domain.Entities;
using Estagio.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Template.Data.Repositories;

namespace Estagio.Data.Repositories
{
    public class CompraRepository : Repository<Compra>, ICompraRepository
    {
        public CompraRepository(EstagioContext context)
            : base(context) { }
    }
}
