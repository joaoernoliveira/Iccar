using Japuacu.Blog.Negocio.Interfaces.Repositorios;
using Japuacu.Blog.Negocio.Modelos;
using Japuacu.Blog.Persistencia.Contexto;

namespace Japuacu.Blog.Persistencia.Repositorios
{
    public class ParagrafoRepositorio : Repositorio<Paragrafo>, IParagrafoRepositorio
    {
        public ParagrafoRepositorio(BlogContext contexto) : base(contexto) { }

    }
}