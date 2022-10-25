using System.Collections.Generic;

namespace Estagio.Application.ViewModels
{
    public class ProdutoViewModel
    {
        public long Id { get; set; }

        public string Marca { get; set; }

        public decimal Preco { get; set; }

        public string Nome { get; set; }

        public decimal Quantidade { get; set; }

        public decimal QuantidadeAFornecer { get; set; }

        public bool Ativo { get; set; }

        public List<CompraProdutoViewModel> CompraProdutos { get; set; }
    }
}
