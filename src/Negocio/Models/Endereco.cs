using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio.Models
{
    public class Endereco : Entity
    {
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }

        public Guid EntidadeId { get; set; }
        public Entidade Entidade { get; set; }
    }
}
