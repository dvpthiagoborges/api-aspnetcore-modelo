using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio.Models.Validations
{
    public class SolicitacaoValidation : AbstractValidator<Solicitacao>
    {
        public SolicitacaoValidation()
        {
            RuleFor(p => p.Descricao)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 80).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
        }
    }
}
