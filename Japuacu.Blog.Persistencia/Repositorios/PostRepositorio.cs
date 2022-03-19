using Japuacu.Blog.Negocio.Interfaces;
using Japuacu.Blog.Negocio.Interfaces.Repositorios;
using Japuacu.Blog.Negocio.Modelos;
using Japuacu.Blog.Persistencia.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Japuacu.Blog.Persistencia.Repositorios
{
    public class PostRepositorio : Repositorio<Post>, IPostRepositorio
    {
        public PostRepositorio(BlogContext contexto) : base(contexto) { }

        public override async Task<Post> PorId(int id)
        {
            return await DbSet.Include(p=>p.Autor).Include(p=>p.Paragrafo).Include(p=>p.Comentario).FirstOrDefaultAsync(p=>p.Id ==id);
        }

        public  async Task<List<Post>> TodosComAutor()
        {
            return await DbSet.Include(p=>p.Autor).ToListAsync();
        }

        public async Task<List<Post>> TodosComParagrafos()
        {
            return await DbSet.Include(p => p.Paragrafo).ToListAsync();
        }

        public async Task<List<Post>> TodosComAutorParagrafos()
        {
            return await DbSet.Include(p => p.Paragrafo).Include(p=>p.Paragrafo).ToListAsync();
        }

        public async Task<List<Post>> TodosComAutorParagrafosComentarios()
        {
            return await DbSet.Include(p => p.Autor).
                               Include(p => p.Paragrafo).
                               Include(p=>p.Comentario).ToListAsync();
        }

    }
}