using Estagio.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Estagio.Application.Interfaces
{
    public interface ICompraService
    {
        bool RealizarCompra(List<ProdutoViewModel> produtos);
    }
}
