using Japuacu.Blog.Negocio.Modelos;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Japuacu.Blog.Aplicacao.Models
{
    public interface IAutenticacao
    {
        public Task<bool> RegistrarUsuario(Usuario usuario);

        public Task<bool> ValidarLogin(Usuario usuario);

    }
}