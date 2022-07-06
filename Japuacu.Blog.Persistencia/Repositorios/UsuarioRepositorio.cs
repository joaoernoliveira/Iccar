using Japuacu.Blog.Negocio.Interfaces.Repositorios;
using Japuacu.Blog.Negocio.Modelos;
using Japuacu.Blog.Persistencia.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Japuacu.Blog.Persistencia.Repositorios
{
    public class UsuarioRepositorio : Repositorio<Usuario>, IUsuarioRepositorio
    {
        public UsuarioRepositorio(BlogContext contexto) : base(contexto) { }


    }
}

