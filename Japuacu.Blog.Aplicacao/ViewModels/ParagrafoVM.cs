using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Japuacu.Blog.Aplicacao.ViewModels
{
    public class ParagrafoVM
    {
        [Key]
        [DisplayName("Código")]
        public int Id { get; set; }
        
        [DisplayName("Post")]
        public int PostId { get; set; }
        
        [DisplayName("Ordem")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Ordem { get; set; }

        [DisplayName("Redação")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(8000, ErrorMessage = "O campo {0} precisa ter  entre {2} e {1} caracteres", MinimumLength = 20)]
        public string Redacao { get; set; }

        public virtual PostVM Post { get; set; }
    }
}
