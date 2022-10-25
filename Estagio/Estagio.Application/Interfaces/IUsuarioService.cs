using Estagio.Application.ViewModels;
using System.Collections.Generic;

namespace Estagio.Application.Interfaces
{
    public interface IUsuarioService
    {
        List<UsuarioViewModel> GetAll();

        bool Post(UsuarioViewModel usuarioViewModel);

        bool Put(UsuarioViewModel usuarioViewModel);

        UsuarioViewModel GetById(string id);

        bool Delete(string id);

        UsuarioAuthenticateResponseViewModel Authenticate(UsuarioAuthenticateRequestViewModel user);

        UsuarioAuthenticateResponseViewModel AuthenticateAdmin(UsuarioAuthenticateRequestViewModel user);
    }
}
