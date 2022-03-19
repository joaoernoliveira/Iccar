using Japuacu.Blog.Negocio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Japuacu.Blog.Negocio.Interfaces.Servicos
{
    public interface IPostServico : IDisposable
    {
        Task Incluir(Post Post);
        Task Alterar(Post Post);
        Task Excluir(Post Post);
        Task<Post> PorId(int id);
        Task<IEnumerable<Post>> Todos();
        Task<IEnumerable<Post>> TodosPublicados();
        Task<IEnumerable<Post>> TodosNaoPublicados();

        Task<List<Post>> TodosComAutorParagrafos();

        Task<List<Post>> TodosComAutorParagrafosComentarios();

    }
}
