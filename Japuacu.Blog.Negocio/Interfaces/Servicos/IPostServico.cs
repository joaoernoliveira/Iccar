using Japuacu.Blog.Negocio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public  Task<IEnumerable<Post>> Buscar(Expression<Func<Post, bool>> predicado);
        
        Task<IEnumerable<Post>> Todos();
        Task<IEnumerable<Post>> TodosPublicados();
        Task<IEnumerable<Post>> TodosNaoPublicados();
        Task<List<Post>> TodosComAutorParagrafos();
        Task<List<Post>> TodosComAutorParagrafosComentarios();
        Task<List<string>> TodosResumoAnteriores();
        Task<IEnumerable<Post>> TodosDeUmMesAno(int ano, int mes);
    }
}
