using Japuacu.Blog.Negocio.Interfaces.Repositorios;
using Japuacu.Blog.Negocio.Modelos;
using Japuacu.Blog.Persistencia.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Japuacu.Blog.Persistencia.Repositorios
{
    public abstract class Repositorio<T> : IRepositorio<T> where T : EntidadeModelo, new()
    {
        protected readonly BlogContext Db;
        protected readonly DbSet<T> DbSet;

        protected Repositorio(BlogContext db)
        {
            Db = db;
            DbSet = db.Set<T>();
        }

        public async Task<IEnumerable<T>> Buscar(Expression<Func<T, bool>> predicado)
        {
            return await DbSet.AsNoTracking().Where(predicado).ToListAsync();
        }

        public virtual async Task<T> PorId(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<List<T>> Todos()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task Incluir(T entidade)
        {
            DbSet.Add(entidade);
            await Salvar();
        }

        public virtual async Task Alterar(T entidade)
        {
            DbSet.Update(entidade);
            await Salvar();
        }

        public virtual async Task Excluir(T entidade)
        {
            DbSet.Remove(entidade);
            await Salvar();
        }

        public async Task<int> Salvar()
        {
            return await Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}