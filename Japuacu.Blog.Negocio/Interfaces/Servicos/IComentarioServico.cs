using Japuacu.Blog.Negocio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Japuacu.Blog.Negocio.Interfaces.Servicos
{
    public interface IComentarioServico : IDisposable
    {
       Task Incluir(Comentario Comentario);
       Task<IEnumerable<Comentario>> ComentariosPorPost(Post Comentario);
    }
}
