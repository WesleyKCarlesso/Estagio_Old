using Estagio.Domain.Models;

namespace Estagio.Domain.Entities
{
    public class CompraProduto : Entity
    {
        public long? CompraId { get; set; }

        public long? ProdutoId { get; set; }

        public decimal Quantidade { get; set; }

        public decimal Valor { get; set; }
    }
}
