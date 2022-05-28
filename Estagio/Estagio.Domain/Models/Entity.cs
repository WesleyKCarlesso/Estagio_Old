using System;

namespace Estagio.Domain.Models
{
    public class Entity
    {
        public DateTime DateCreated { get; set; }

        public DateTime? DateUpdated { get; set; }

        public bool IsDeleted { get; set; }
    }
}
