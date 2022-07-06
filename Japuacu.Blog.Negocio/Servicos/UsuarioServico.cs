using Japuacu.Blog.Negocio.Interfaces.Notificacoes;
using Japuacu.Blog.Negocio.Interfaces.Repositorios;
using Japuacu.Blog.Negocio.Interfaces.Servicos;
using Japuacu.Blog.Negocio.Modelos;
using Japuacu.Blog.Negocio.Modelos.Validacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Japuacu.Blog.Negocio.Servicos
{
    public class UsuarioServico : Servico, IUsuarioServico
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioServico(IUsuarioRepositorio usuarioRepositorio,

                            INotificador notificador) : base(notificador)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public async Task Incluir(Usuario usuario)
        {
            if (!ExecutarValidacao(new UsuarioValidacao(), usuario)) return;

            if (_usuarioRepositorio.Buscar(u => u.Login== usuario.Login).Result.Any())
            {
                Notificar("Já existe um usuario com este Login infomado.");
                return;
            }

            await _usuarioRepositorio.Incluir(usuario);
        }

        public async Task Alterar(Usuario usuario)
        {
            if (!ExecutarValidacao(new UsuarioValidacao(), usuario)) return;

            if (_usuarioRepositorio.Buscar(u => u.Login == usuario.Login && u.Id != usuario.Id).Result.Any())
            {
                Notificar("Já existe um autor com o número de CPF infomado.");
                return;
            }

            await _usuarioRepositorio.Alterar(usuario);
        }


        public async Task<IEnumerable<Usuario>> Todos()
        {
            return await _usuarioRepositorio.Todos();
        }


        public async Task<Usuario> PorId(int id)
        {
            return await _usuarioRepositorio.PorId(id);
        }



        public void Dispose()
        {
            _usuarioRepositorio?.Dispose();
        }

        public async Task Excluir(Usuario usuario)
        {
            var usuarioExluir = await PorId(usuario.Id);
            usuarioExluir.Ativo = false;
            await _usuarioRepositorio.Alterar(usuario);
        }

        public async Task<bool> ValidarSenha(Usuario usuario)
        {
            var usuarioBanco = (await _usuarioRepositorio.Buscar(u => u.Login == usuario.Login && 
                                                                      u.Senha == usuario.Senha &&
                                                                      u.Ativo)).FirstOrDefault();
            if (usuarioBanco == null)
            {
                return false;
            }

            return true;
        }
    }
}