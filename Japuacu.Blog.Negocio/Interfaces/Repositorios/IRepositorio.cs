using Japuacu.Blog.Negocio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Japuacu.Blog.Negocio.Interfaces.Repositorios
{
    public interface IRepositorio<T> : IDisposable where T : EntidadeModelo
    {
        Task Incluir(T entidade);
        Task<T> PorId(int id);
        Task<List<T>> Todos();
        Task Alterar(T entidade);
        Task Excluir(T entidade);
        Task<IEnumerable<T>> Buscar(Expression<Func<T, bool>> predicado);
        Task<int> Salvar();
    }
}
