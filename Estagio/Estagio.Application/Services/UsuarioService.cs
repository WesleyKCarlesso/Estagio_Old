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

            //foreach (var item in usuarios)
            //{
            //    usuarioViewModel.Add(new UsuarioViewModel { 
            //        Id = item.Id, 
            //        Admin = item.Admin,
            //        Email = item.Email,
            //        Nome = item.Nome, 
            //        Telefone = item.Telefone,
            //        Senha = item.Senha,
            //        Login = item.Login
            //    });
            //}

            return usuarioViewModel;
        }

        public bool Post(UsuarioViewModel usuario)
        {
            //Usuario _usuario = new Usuario() { 
            //    Id = new long(), 
            //    DateCreated = DateTime.Now, 
            //    Email = usuario.Email,
            //    Login = usuario.Login, 
            //    Nome = usuario.Nome, 
            //    Senha = usuario.Senha, 
            //    Telefone = usuario.Telefone,
            //    DateUpdated = null, 
            //    IsDeleted = false, 
            //    Admin = false
            //};

            Usuario _usuario = mapper.Map<Usuario>(usuario);    // conversão de usuario view model para entidade com o auto mapper

            this.usuarioRepository.Create(_usuario);

            return true;
        }
    }
}
