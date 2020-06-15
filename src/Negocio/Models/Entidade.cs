using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Negocio.Models
{
    public class Entidade : Entity
    {
        public string Nome { get; set; }

        public List<Endereco> Endereco { get; set; }
        public List<Solicitacao> Solicitacao { get; set; }
    }
}
