using Estagio.Application.Interfaces;
using Estagio.Application.ViewModels;
using Estagio.Domain.Entities;
using System.Collections.Generic;
using Template.Domain.Interfaces;

namespace Estagio.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;
        }

        public List<UsuarioViewModel> Get()
        {
            List<UsuarioViewModel> usuarioViewModel = new List<UsuarioViewModel>();

            IEnumerable<Usuario> usuarios = this.usuarioRepository.GetAll();

            foreach (var item in usuarios)
            {
                usuarioViewModel.Add(new UsuarioViewModel { Id = item.Id, Admin = item.Admin, Email = item.Email, Nome = item.Nome, Telefone = item.Telefone });
            }

            return usuarioViewModel;
        }
    }
}
