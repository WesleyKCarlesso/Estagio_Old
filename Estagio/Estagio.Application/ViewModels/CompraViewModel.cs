using System;
using System.Collections.Generic;

namespace Estagio.Application.ViewModels
{
    public class CompraViewModel
    {
        public long Id { get; set; }

        public DateTime Data { get; set; }

        public long? IdUsuario { get; set; }

        public decimal ValorTotal { get; set; }
    
        public List<CompraProdutoViewModel> CompraProdutos { get; set; }
    }
}
