using Estagio.Application.Interfaces;
using Estagio.Application.ViewModels;
using Estagio.Auth.Packages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Estagio.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]  // Authorize faz os métodos por padrão serem privados para quem tem o token
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            this.usuarioService = usuarioService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var users = this.usuarioService.Get();
            return Ok(users);
        }

        [HttpPost, AllowAnonymous]
        public IActionResult Post(UsuarioViewModel usuarioViewModel)
        {
            return Ok(this.usuarioService.Post(usuarioViewModel));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            var user = this.usuarioService.GetById(id);
            return Ok(user);
        }

        [HttpPut]
        public IActionResult Put(UsuarioViewModel usuarioViewModel)
        {
            var user = this.usuarioService.Put(usuarioViewModel);
            return Ok(user);
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            string userId = TokenService.GetValueFromClaim(HttpContext.User.Identity, ClaimTypes.NameIdentifier);   // somente o próprio usuário pode deletar seu registro

            return Ok(this.usuarioService.Delete(userId));
        }

        [HttpPost("authenticate"), AllowAnonymous]  // qualquer um pode realizar esta operação
        public IActionResult Authenticate(UserAuthenticateRequestViewModel usuarioViewModel)
        {
            return Ok(this.usuarioService.Authenticate(usuarioViewModel));
        }
    }
}
