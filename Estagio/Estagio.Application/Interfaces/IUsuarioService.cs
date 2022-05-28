using Estagio.Application.ViewModels;
using System.Collections.Generic;

namespace Estagio.Application.Interfaces
{
    public interface IUsuarioService
    {
        List<UsuarioViewModel> Get();
    }
}
