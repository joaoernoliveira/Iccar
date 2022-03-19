using FluentValidation;
using Japuacu.Blog.Negocio.Modelos.Validacoes.Documento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Japuacu.Blog.Negocio.Modelos.Validacoes
{
    public class ComentarioValidacao : AbstractValidator<Comentario>
    {
        public ComentarioValidacao()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser preenchido")
                .Length(2, 50)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");


            RuleFor(c => c.Redacao)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser preenchido")
                .Length(20, 5000)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

        }
    }
}
