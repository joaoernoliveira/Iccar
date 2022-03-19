using Japuacu.Blog.Negocio.Interfaces;
using Japuacu.Blog.Negocio.Interfaces.Repositorios;
using Japuacu.Blog.Negocio.Modelos;
using Japuacu.Blog.Persistencia.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Japuacu.Blog.Persistencia.Repositorios
{
    public class AutorRepositorio :Repositorio<Autor> , IAutorRepositorio
    {
        public AutorRepositorio(BlogContext contexto) : base(contexto) { }

    }
}
