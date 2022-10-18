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

        public List<UsuarioViewModel> GetAll()
        {
            List<UsuarioViewModel> usuarioViewModel = new List<UsuarioViewModel>();

            IEnumerable<Usuario> usuarios = this.usuarioRepository.GetAll();

            usuarioViewModel = mapper.Map<List<UsuarioViewModel>>(usuarios);    // transforma a lista de entidades em lista de view models

            return usuarioViewModel;
        }

        public bool Post(UsuarioViewModel usuarioViewModel)
        {
            if (usuarioViewModel.Id != 0)
                throw new Exception("UsuarioId precisa estar vazio");

            usuarioViewModel.Ativo = true;

            Validator.ValidateObject(usuarioViewModel, new ValidationContext(usuarioViewModel), true);

            Usuario usuario = mapper.Map<Usuario>(usuarioViewModel);    // conversão de usuario view model para entidade com o auto mapper
            usuario.Senha = CriptografarSenha(usuario.Senha);

            this.usuarioRepository.Create(usuario);

            return true;
        }

        public UsuarioViewModel GetById(string id)
        {
            if (!long.TryParse(id, out long userId)) // tenta converter para long, caso não consiga dispara a exceção
            {
                throw new Exception("UsuarioId não é válido");
            }

            Usuario usuario = this.usuarioRepository.Find(x => x.Id == userId && x.Ativo);

            if (usuario == null)
            {
                throw new Exception("Usuario não encontrado");
            }

            usuario.Senha = this.DecodeFrom64(usuario.Senha);

            return mapper.Map<UsuarioViewModel>(usuario);
        }

        public bool Put(UsuarioViewModel usuarioViewModel)
        {
            if (usuarioViewModel.Id == 0)
            {
                throw new Exception("ID não é válido");
            }

            Usuario usuario = this.usuarioRepository.Find(x => x.Id == usuarioViewModel.Id && x.Ativo);

            if (usuario == null)
            {
                throw new Exception("Usuario não encontrado");
            }

            usuario = mapper.Map<Usuario>(usuarioViewModel);
            usuario.Senha = CriptografarSenha(usuario.Senha);

            this.usuarioRepository.Update(usuario);

            return true;
        }

        public bool Delete(string id)
        {
            if (!long.TryParse(id, out long userId)) // tenta converter para long, caso não consiga dispara a exceção
            {
                throw new Exception("UsuarioId não é válido");
            }

            Usuario usuario = this.usuarioRepository.Find(x => x.Id == userId && x.Ativo);

            if (usuario == null)
            {
                throw new Exception("Usuario não encontrado");
            }

            return this.usuarioRepository.Delete(usuario);
        }

        public UsuarioAuthenticateResponseViewModel Authenticate(UsuarioAuthenticateRequestViewModel _usuario)
        {
            if (string.IsNullOrEmpty(_usuario.Email) || string.IsNullOrEmpty(_usuario.Senha))
            {
                throw new Exception("Email/Senha são obrigatórios");
            }

            _usuario.Senha = CriptografarSenha(_usuario.Senha);

            Usuario usuario = this.usuarioRepository
                .Find(x => 
                    x.Ativo
                    && x.Email.ToLower() == _usuario.Email.ToLower()
                    && x.Senha.ToLower() == _usuario.Senha.ToLower());

            if (usuario == null)
                throw new Exception("Usuario não encontrado");

            return new UsuarioAuthenticateResponseViewModel(mapper.Map<UsuarioViewModel>(usuario), TokenService.GenerateToken(usuario));
        }

        private string CriptografarSenha(string senha)
        {
            try
            {
                byte[] encData_byte = new byte[senha.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(senha);
                string encodedData = Convert.ToBase64String(encData_byte);
                
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }

        }

        public string DecodeFrom64(string encodedData)
        {
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            System.Text.Decoder utf8Decode = encoder.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(encodedData);
            int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            string result = new String(decoded_char);
            return result;
        }
    }
}
