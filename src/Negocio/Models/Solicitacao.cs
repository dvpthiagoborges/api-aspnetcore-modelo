using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio.Models
{
    public class Solicitacao : Entity
    {
        public string Descricao { get; set; }

        public Guid EntidadeId { get; set; }
        public Entidade Entidade { get; set; }
    }
}
