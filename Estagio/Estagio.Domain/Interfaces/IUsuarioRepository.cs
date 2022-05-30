using Estagio.Domain.Entities;
using System.Collections.Generic;

namespace Template.Domain.Interfaces
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        IEnumerable<Usuario> GetAll();
    }
}