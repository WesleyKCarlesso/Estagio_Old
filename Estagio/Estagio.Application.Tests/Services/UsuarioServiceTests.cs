using AutoMapper;
using Estagio.Application.AutoMapper;
using Estagio.Application.Services;
using Estagio.Application.ViewModels;
using Estagio.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Template.Domain.Interfaces;
using Xunit;

namespace Estagio.Application.Tests.Services
{
    public class UsuarioServiceTests
    {
        private UsuarioService usuarioService;

        public UsuarioServiceTests()
        {
            usuarioService = new UsuarioService(new Mock<IUsuarioRepository>().Object, new Mock<IMapper>().Object);
        }

        #region ValidatingSendingId

        [Fact]
        public void Post_SendingValidID()
        {
            var exception = Assert.Throws<Exception>(() => usuarioService.Post(new UsuarioViewModel { Id = 5 }));
            Assert.Equal("UsuarioId precisa estar vazio", exception.Message);
        }

        [Fact]
        public void GetById_SendingEmptyGuid()
        {
            var exception = Assert.Throws<Exception>(() => usuarioService.GetById(""));
            Assert.Equal("UsuarioId não é válido", exception.Message);
        }

        [Fact]
        public void Put_SendingEmptyGuid()
        {
            var exception = Assert.Throws<Exception>(() => usuarioService.Put(new UsuarioViewModel()));
            Assert.Equal("Usuario não encontrado", exception.Message);
        }

        [Fact]
        public void Delete_SendingEmptyGuid()
        {
            var exception = Assert.Throws<Exception>(() => usuarioService.Delete(""));
            Assert.Equal("UsuarioId não é válido", exception.Message);
        }

        [Fact]
        public void Authenticate_SendingEmptyValues()
        {
            var exception = Assert.Throws<Exception>(() => usuarioService.Authenticate(new UsuarioAuthenticateRequestViewModel()));
            Assert.Equal("Email/Senha são obrigatórios", exception.Message);
        }

        #endregion

        #region ValidatingCorrectObject

        [Fact]
        public void Post_SendingValidObject()
        {
            var result = usuarioService.Post(new UsuarioViewModel { Nome = "Wesley222", Email = "Wesleyy@email.com" });
            Assert.True(result);
        }

        [Fact]
        public void Get_ValidatingObject()
        {
            List<Usuario> usuarios = new List<Usuario>();
            usuarios.Add(new Usuario { Id = new long(), Nome = "TesteWesley", Email = "teste@wesley.com", DateCreated = DateTime.Now });

            var usuarioRepository = new Mock<IUsuarioRepository>();
            usuarioRepository.Setup(x => x.GetAll()).Returns(usuarios);

            var autoMapperProfile = new AutoMapperSetup();
            var configuration = new MapperConfiguration(x => x.AddProfile(autoMapperProfile));
            IMapper mapper = new Mapper(configuration);

            usuarioService = new UsuarioService(usuarioRepository.Object, mapper);
            var result = usuarioService.Get();
            Assert.True(result.Count > 0);
        }

        #endregion

        #region ValidatingRequiredFields

        [Fact]
        public void Post_SendingInvalidObject()
        {
            var exception = Assert.Throws<ValidationException>(() => usuarioService.Post(new UsuarioViewModel { Nome = "Wesleyyy" }));
            Assert.Equal("The Email field is required.", exception.Message);
        }

        #endregion
    }
}
