using Japuacu.Blog.Negocio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Japuacu.Blog.Negocio.Interfaces.Servicos
{
    public interface IParagrafoServico : IDisposable
    {
        Task Incluir(Paragrafo Paragrafo);
        Task Alterar(Paragrafo Paragrafo);
        Task Excluir(Paragrafo Paragrafo);
        Task<Paragrafo> PorId(int id);

        Task<IEnumerable<Paragrafo>> ParagrafosPorPost(Post post);
    }
}
