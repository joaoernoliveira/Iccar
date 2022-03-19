using FluentValidation;
using Japuacu.Blog.Negocio.Modelos.Validacoes.Documento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Japuacu.Blog.Negocio.Modelos.Validacoes
{
    public class PostValidacao : AbstractValidator<Post>
    {
        public PostValidacao()
        {
            RuleFor(c => c.TituloPost)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser preenchido")
                .Length(2, 50)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.ResumoPost)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser preenchido")
                .Length(20, 1000)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
        }
    }
}
