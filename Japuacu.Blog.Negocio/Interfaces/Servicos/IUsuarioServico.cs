using Japuacu.Blog.Negocio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Japuacu.Blog.Negocio.Interfaces.Servicos
{
    public interface IUsuarioServico : IDisposable
    {
        Task Incluir(Usuario usuario);
        Task Alterar(Usuario usuario);
        Task Excluir(Usuario usuario);
        Task<IEnumerable<Usuario>> Todos();
        Task<Usuario> PorId(int id);
        Task<Boolean> ValidarSenha(Usuario usuario);

    }
}
