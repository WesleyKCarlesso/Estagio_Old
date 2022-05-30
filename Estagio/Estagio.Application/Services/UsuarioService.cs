using AutoMapper;
using Estagio.Application.Interfaces;
using Estagio.Application.ViewModels;
using Estagio.Domain.Entities;
using System;
using System.Collections.Generic;
using Template.Domain.Interfaces;

namespace Estagio.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository usuarioRepository;
        private readonly IMapper mapper;

        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            this.usuarioRepository = usuarioRepository;
            this.mapper = mapper;
        }

        public List<UsuarioViewModel> Get()
        {
            List<UsuarioViewModel> usuarioViewModel = new List<UsuarioViewModel>();

            IEnumerable<Usuario> usuarios = this.usuarioRepository.GetAll();

            usuarioViewModel = mapper.Map<List<UsuarioViewModel>>(usuarios);    // transforma a lista de entidades em lista de view models

            return usuarioViewModel;
        }

        public bool Post(UsuarioViewModel usuario)
        {
            Usuario _usuario = mapper.Map<Usuario>(usuario);    // conversão de usuario view model para entidade com o auto mapper

            this.usuarioRepository.Create(_usuario);

            return true;
        }

        public UsuarioViewModel GetById(string id)
        {
            if (!long.TryParse(id, out long userId)) // tenta converter para long, caso não consiga dispara a exceção
            {
                throw new Exception("UserId is not valid");
            }

            Usuario usuario = this.usuarioRepository.Find(x => x.Id == userId && !x.IsDeleted);

            if (usuario == null)
            {
                throw new Exception("User not found");
            }

            return mapper.Map<UsuarioViewModel>(usuario);
        }

        public bool Put(UsuarioViewModel usuarioViewModel)
        {
            Usuario usuario = this.usuarioRepository.Find(x => x.Id == usuarioViewModel.Id && !x.IsDeleted);

            if (usuario == null)
            {
                throw new Exception("User not found");
            }

            usuario = mapper.Map<Usuario>(usuarioViewModel);

            this.usuarioRepository.Update(usuario);

            return true;
        }

        public bool Delete(string id)
        {
            if (!long.TryParse(id, out long userId)) // tenta converter para long, caso não consiga dispara a exceção
            {
                throw new Exception("UserId is not valid");
            }

            Usuario usuario = this.usuarioRepository.Find(x => x.Id == userId && !x.IsDeleted);

            if (usuario == null)
            {
                throw new Exception("User not found");
            }

            return this.usuarioRepository.Delete(usuario);
        }
    }
}
