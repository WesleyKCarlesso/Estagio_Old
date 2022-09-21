using Estagio.Domain.Models;
using System.Collections.Generic;

namespace Estagio.Domain.Entities
{
    public class Usuario : Entity
    {
        public Usuario()
        {
            Compras = new List<Compra>();
        }

        public string Nome { get; set; }

        public string Login { get; set; }

        public string Senha { get; set; }

        public string Email { get; set; }

        public string Telefone { get; set; }

        public bool Admin { get; set; }

        public List<Compra> Compras { get; set; }
    }
}
