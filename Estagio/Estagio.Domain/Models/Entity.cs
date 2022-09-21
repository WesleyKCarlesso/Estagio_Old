using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Estagio.Domain.Models
{
    public class Entity
    {
        public long Id { get; set; }

        public bool Ativo { get; set; }
    }
}
