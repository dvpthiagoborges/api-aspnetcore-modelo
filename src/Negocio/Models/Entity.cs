using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio.Models
{
    public abstract class Entity
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
    }
}
