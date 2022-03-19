using FluentValidation;
using Japuacu.Blog.Negocio.Modelos.Validacoes.Documento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Japuacu.Blog.Negocio.Modelos.Validacoes
{
    public class ParagrafoValidacao : AbstractValidator<Paragrafo>
    {
        public ParagrafoValidacao()
        {
            RuleFor(c => c.Redacao)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser preenchido")
                .Length(20, 8000)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

        }
    }
}
