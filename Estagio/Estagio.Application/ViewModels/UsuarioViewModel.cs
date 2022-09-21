using Estagio.Domain.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Estagio.Application.ViewModels
{
    public class UsuarioViewModel
    {
        public long Id { get; set; }

        [Required]
        public string Nome { get; set; }

        public string Login { get; set; }

        [Required]
        public string Senha { get; set; }

        [Required]
        public string Email { get; set; }

        public string Telefone { get; set; }

        public bool Admin { get; set; }

        public bool Ativo { get; set; }

        public List<Compra> Compras { get; set; }
    }
}
