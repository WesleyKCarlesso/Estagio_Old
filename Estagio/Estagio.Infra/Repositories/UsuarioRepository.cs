using Estagio.Data.Context;
using Estagio.Domain.Entities;
using System.Collections.Generic;
using Template.Domain.Interfaces;

namespace Template.Data.Repositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {

        public UsuarioRepository(EstagioContext context)
            : base(context) { }

        public IEnumerable<Usuario> GetAll()
        {
            return Query(x => !x.IsDeleted);
        }

    }
}