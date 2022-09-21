using Estagio.Domain.Models;
using System;
using System.Collections.Generic;

namespace Estagio.Domain.Entities
{
    public class Compra : Entity
    {
        public Compra()
        {
            CompraProdutos = new List<CompraProduto>();
        }

        public DateTime Data { get; set; }

        public long? IdUsuario { get; set; }

        public List<CompraProduto> CompraProdutos { get; set; }
    }
}
