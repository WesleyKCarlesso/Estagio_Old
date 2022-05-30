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
    [ApiController, Authorize]
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
            string usuarioId = TokenService.GetValueFromClaim(HttpContext.User.Identity, ClaimTypes.NameIdentifier);

            return Ok(this.usuarioService.Delete(usuarioId));
        }

        [HttpPost("authenticate"), AllowAnonymous]
        public IActionResult Authenticate(UserAuthenticateRequestViewModel usuarioViewModel)
        {
            return Ok(this.usuarioService.Authenticate(usuarioViewModel));
        }
    }
}
