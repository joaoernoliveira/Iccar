using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Japuacu.Blog.Aplicacao.ViewModels
{
    public class PostVM
    {
        [Key]
        [DisplayName("Código")]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Data Criação")]
        public DateTime DataPost { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Autor")]
        public int AutorId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(50, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        [DisplayName("Título")]
        public string TituloPost { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(1000, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 10)]
        [DisplayName("Resumo")]
        public string ResumoPost { get; set; }
        public string ImagemPost { get; set; }

        public bool Terminado { get; set; }

        public virtual AutorVM Autor { get; set; }
        public virtual ICollection<ComentarioVM> Comentario { get; set; }
        public virtual ICollection<ParagrafoVM> Paragrafo { get; set; }
        public List<string> anteriores { get; set; }

    }
}
