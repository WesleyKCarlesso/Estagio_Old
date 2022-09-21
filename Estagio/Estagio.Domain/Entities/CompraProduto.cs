using Estagio.Domain.Models;

namespace Estagio.Domain.Entities
{
    public class CompraProduto : Entity
    {
        public long? IdCompra { get; set; }

        public long? IdProduto { get; set; }

        public decimal Quantidade { get; set; }

        public decimal Valor { get; set; }
    }
}
