using Negocio.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.ViewModels
{
    public class SolicitacaoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [StringLength(80, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Descricao { get; set; }

        public Guid EntidadeId { get; set; }

        public virtual EntidadeViewModel Entidade { get; set; }
    }
}
