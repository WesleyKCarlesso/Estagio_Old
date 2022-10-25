using Estagio.Application.Interfaces;
using Estagio.Application.ViewModels;
using Estagio.Auth.Packages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;

namespace Estagio.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            this.usuarioService = usuarioService;
        }

        //[HttpGet]
        //public IActionResult GetAll()
        //{
        //    var users = this.usuarioService.GetAll();
        //    return Ok(users);
        //}

        [HttpGet]
        public IActionResult GetLogged()
        {
            string usuarioId = TokenService.GetValueFromClaim(HttpContext.User.Identity, ClaimTypes.NameIdentifier);

            var users = new List<UsuarioViewModel>();

            var user = this.usuarioService.GetById(usuarioId);

            users.Add(user);

            return Ok(users);
        }

        [HttpPost, AllowAnonymous]
        public IActionResult Post(UsuarioViewModel usuarioViewModel)
        {
            return Ok(this.usuarioService.Post(usuarioViewModel));
        }

        [HttpGet("{id}"), AllowAnonymous]
        public IActionResult GetById(string id)
        {
            var user = this.usuarioService.GetById(id);
            return Ok(user);
        }

        [HttpPut, AllowAnonymous]
        public IActionResult Put(UsuarioViewModel usuarioViewModel)
        {
            var user = this.usuarioService.Put(usuarioViewModel);
            return Ok(user);
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            string usuarioId = TokenService.GetValueFromClaim(HttpContext.User.Identity, ClaimTypes.NameIdentifier);

            return Ok(this.usuarioService.Delete(usuarioId));
        }

        [HttpPost("authenticate"), AllowAnonymous]
        public IActionResult Authenticate(UsuarioAuthenticateRequestViewModel usuarioViewModel)
        {
            return Ok(this.usuarioService.Authenticate(usuarioViewModel));
        }

        [HttpPost("authenticateAdmin"), AllowAnonymous]
        public IActionResult AuthenticateAdmin(UsuarioAuthenticateRequestViewModel usuarioViewModel)
        {
            return Ok(this.usuarioService.AuthenticateAdmin(usuarioViewModel));
        }
    }
}
