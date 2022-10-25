using Estagio.Application.Interfaces;
using Estagio.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Estagio.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class CompraController : ControllerBase
    {
        public ICompraService compraService;

        public CompraController(ICompraService compraService)
        {
            this.compraService = compraService;
        }

        [HttpPost, AllowAnonymous]
        public IActionResult RealizarCompra(List<ProdutoViewModel> produtos)
        {
            return Ok(compraService.RealizarCompra(produtos));
        }

        [HttpGet("GetHistoricoComprasUsuario/{id:int}"), AllowAnonymous]
        public IActionResult GetHistoricoComprasUsuario(int id)
        {
            return null;
        }
    }
}
