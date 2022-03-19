using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Japuacu.Blog.Aplicacao.ViewModels
{
    public class ComentarioVM
    {
        [Key]
        [DisplayName("Código")]
        public int Id { get; set; }
        
        [DisplayName("Post")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int PostId { get; set; }

        [DisplayName("Data")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime DataComentario { get; set; }

        [DisplayName("Nome")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }

        [DisplayName("Redação")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(5000, ErrorMessage = "O campo {0} precisa ter  entre {2} e {1} caracteres", MinimumLength = 20)]
        public string Redacao { get; set; }

        [DisplayName("Imagem")]
        public string Imagem { get; set; }

        [DisplayName("Id Face")]
        public string IdFace { get; set; }

        public virtual PostVM Post { get; set; }
    }
}
