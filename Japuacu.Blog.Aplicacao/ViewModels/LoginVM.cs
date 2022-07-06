using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Japuacu.Blog.Aplicacao.ViewModels
{
    public class LoginVM
    {

        [DisplayName("Login")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Login { get; set; }

        [DisplayName("Senha")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Senha { get; set; }

    }
}
