using Estagio.Application.ViewModels;
using System.Collections.Generic;

namespace Estagio.Application.Interfaces
{
    public interface IProdutoService
    {
        List<ProdutoViewModel> GetAll();

        List<ProdutoViewModel> GetProdutosParaCompra();

        bool Post(ProdutoViewModel produtoViewModel);

        bool Put(ProdutoViewModel produtoViewModel);

        bool Delete(long Id);
    }
}
