using Estagio.Application.Interfaces;
using Estagio.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Estagio.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class ProdutoController : ControllerBase
    {
        public IProdutoService produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            this.produtoService = produtoService;
        }

        [HttpGet, AllowAnonymous]
        public IActionResult GetAll()
        {
            var produtos = this.produtoService.GetAll();
            return Ok(produtos);
        }

        [HttpGet("getProdutosParaCompra"), AllowAnonymous]
        public IActionResult GetProdutosParaCompra()
        {
            var produtos = this.produtoService.GetProdutosParaCompra();
            return Ok(produtos);
        }

        [HttpGet("getProdutosEstoque"), AllowAnonymous]
        public IActionResult GetProdutosEstoque()
        {
            var produtos = this.produtoService.GetProdutosEstoque();
            return Ok(produtos);
        }

        [HttpPut, AllowAnonymous]
        public IActionResult Put(ProdutoViewModel produtoViewModel)
        {
            var produto = this.produtoService.Put(produtoViewModel);
            return Ok(produto);
        }

        [HttpPost, AllowAnonymous]
        public IActionResult Post(ProdutoViewModel produtoViewModel)
        {
            var produto = this.produtoService.Post(produtoViewModel);
            return Ok(produto);
        }

        [HttpDelete("{id:int}"), AllowAnonymous]
        public IActionResult Delete(int id)
        {
            return Ok(this.produtoService.Delete(id));
        }

        [HttpPost("realizarCompraEstoque"), AllowAnonymous]
        public IActionResult RealizarCompra(List<ProdutoViewModel> produtos)
        {
            return Ok(produtoService.RealizarCompraEstoque(produtos));
        }
    }
}
