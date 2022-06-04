using AutoMapper;
using Estagio.Application.Interfaces;
using Estagio.Application.ViewModels;
using Estagio.Auth.Packages;
using Estagio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Template.Domain.Interfaces;
using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

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
            if (usuario.Id != 0)
                throw new Exception("UsuarioId precisa estar vazio");

            Validator.ValidateObject(usuario, new ValidationContext(usuario), true);

            Usuario _usuario = mapper.Map<Usuario>(usuario);    // conversão de usuario view model para entidade com o auto mapper

            this.usuarioRepository.Create(_usuario);

            return true;
        }

        public UsuarioViewModel GetById(string id)
        {
            if (!long.TryParse(id, out long userId)) // tenta converter para long, caso não consiga dispara a exceção
            {
                throw new Exception("UsuarioId não é válido");
            }

            Usuario usuario = this.usuarioRepository.Find(x => x.Id == userId && !x.IsDeleted);

            if (usuario == null)
            {
                throw new Exception("Usuario não encontrado");
            }

            return mapper.Map<UsuarioViewModel>(usuario);
        }

        public bool Put(UsuarioViewModel usuarioViewModel)
        {
            if (usuarioViewModel.Id == 0)
            {
                throw new Exception("ID não é válido");
            }

            Usuario usuario = this.usuarioRepository.Find(x => x.Id == usuarioViewModel.Id && !x.IsDeleted);

            if (usuario == null)
            {
                throw new Exception("Usuario não encontrado");
            }

            usuario = mapper.Map<Usuario>(usuarioViewModel);

            this.usuarioRepository.Update(usuario);

            return true;
        }

        public bool Delete(string id)
        {
            if (!long.TryParse(id, out long userId)) // tenta converter para long, caso não consiga dispara a exceção
            {
                throw new Exception("UsuarioId não é válido");
            }

            Usuario usuario = this.usuarioRepository.Find(x => x.Id == userId && !x.IsDeleted);

            if (usuario == null)
            {
                throw new Exception("Usuario não encontrado");
            }

            return this.usuarioRepository.Delete(usuario);
        }

        public UsuarioAuthenticateResponseViewModel Authenticate(UsuarioAuthenticateRequestViewModel user)
        {
            if (string.IsNullOrEmpty(user.Email))
            {
                throw new Exception("Email/Senha são obrigatórios");
            }

            Usuario usuario = this.usuarioRepository.Find(x => !x.IsDeleted && x.Email.ToLower() == user.Email.ToLower());
            if (usuario == null)
                throw new Exception("Usuario não encontrado");

            return new UsuarioAuthenticateResponseViewModel(mapper.Map<UsuarioViewModel>(usuario), TokenService.GenerateToken(usuario));
        }
    }
}
