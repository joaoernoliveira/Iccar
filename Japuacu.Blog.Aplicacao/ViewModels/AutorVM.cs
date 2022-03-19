using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Japuacu.Blog.Aplicacao.ViewModels
{
    public class AutorVM
    {
        [Key]
        [DisplayName("Código")]

        public int Id { get; set; }

        [DisplayName("CPF")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(11, ErrorMessage = "O campo {0} precisa ter  {1} caracteres", MinimumLength = 11)]
        public string Cpf { get; set; }

        [DisplayName("Nome")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(150, ErrorMessage = "O campo {0} precisa ter  entre {2} e {1} caracteres", MinimumLength = 5)]
        public string Nome { get; set; }

        [DisplayName("Credenciais")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(500, ErrorMessage = "O campo {0} precisa ter  entre {2} e {1} caracteres", MinimumLength = 10)]
        public string Credenciais { get; set; }

        public virtual ICollection<PostVM> Post { get; set; }
    }
}
