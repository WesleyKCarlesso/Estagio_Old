using Estagio.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
    }
}
