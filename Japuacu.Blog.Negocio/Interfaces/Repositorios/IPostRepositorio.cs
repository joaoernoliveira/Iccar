using Japuacu.Blog.Negocio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Japuacu.Blog.Negocio.Interfaces.Repositorios
{
    public interface IPostRepositorio : IRepositorio<Post>
    {
        Task<List<Post>> TodosComAutor();

        public Task<List<Post>> TodosComAutorParagrafos();

        public  Task<List<Post>> TodosComAutorParagrafosComentarios();

        //Task<List<Post>> TodosAntigos();

    }
}
