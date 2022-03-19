using Japuacu.Blog.Negocio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Japuacu.Blog.Negocio.Interfaces.Servicos
{
    public interface IAutorServico : IDisposable
    {
        Task Incluir(Autor autor);
        Task Alterar(Autor autor);
        Task Excluir(Autor autor);
        Task<IEnumerable<Autor>> Todos();
        Task<Autor> PorId(int id);
        Task<IEnumerable<Autor>> PorDocumento(string cpf);
        Task<IEnumerable<Autor>> PorNome(string nome); 
        Task<IEnumerable<Post>> PostsPorAutor(Autor autor);
        Task<int> QtdePostsPorAutor(Autor autor);
    }
}
