using Estagio.Domain.Models;
using System.Collections.Generic;

namespace Estagio.Domain.Entities
{
    public class Produto : Entity
    {
        public Produto()
        {
            CompraProdutos = new List<CompraProduto>();
        }

        public string Marca { get; set; }

        public decimal Preco { get; set; }

        public string Nome { get; set; }

        public decimal Quantidade { get; set; }

        public List<CompraProduto> CompraProdutos { get; set; }
    }
}
