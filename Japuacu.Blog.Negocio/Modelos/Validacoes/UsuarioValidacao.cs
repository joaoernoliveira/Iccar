using FluentValidation;
using Japuacu.Blog.Negocio.Modelos.Validacoes.Documento;

namespace Japuacu.Blog.Negocio.Modelos.Validacoes
{
    public class UsuarioValidacao : AbstractValidator<Usuario>
    {
        public UsuarioValidacao()
        {
            RuleFor(u => u.Login)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser preenchido")
                .Length(3, 15)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");


            RuleFor(u => u.Senha)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser preenchido")
                .Length(4, 10)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

        }
    }
}
