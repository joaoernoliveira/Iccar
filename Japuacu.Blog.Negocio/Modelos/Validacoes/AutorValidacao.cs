using FluentValidation;
using Japuacu.Blog.Negocio.Modelos.Validacoes.Documento;

namespace Japuacu.Blog.Negocio.Modelos.Validacoes
{
    public class AutorValidacao : AbstractValidator<Autor>
    {
        public AutorValidacao()
        {
            RuleFor(a => a.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser preenchido")
                .Length(10, 150)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(a => a.Cpf.Length).Equal(CpfValidacao.TamanhoCpf)
                     .WithMessage("O campo CPF precisa ter {ComparisonValue} caracteres e foi preenchido {PropertyValue}.");
            RuleFor(a => CpfValidacao.Validar(a.Cpf)).Equal(true)
                .WithMessage("O CPF preenchido é inválido.");

            RuleFor(a => a.Credenciais)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser preenchido")
                .Length(10, 500)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

        }
    }
}
