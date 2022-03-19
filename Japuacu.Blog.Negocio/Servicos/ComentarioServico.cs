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
    public class ComentarioServico : Servico, IComentarioServico
    {
        private readonly IComentarioRepositorio _comentarioRepositorio;
        private readonly IPostRepositorio _postRepositorio;

        public ComentarioServico(IComentarioRepositorio comentarioRepositorio,
                            IPostRepositorio postRepositorio,
                            INotificador notificador) : base(notificador)
        {
            _comentarioRepositorio = comentarioRepositorio;
            _postRepositorio = postRepositorio;
        }

        public async Task Incluir(Comentario comentario)
        {
            if (!ExecutarValidacao(new ComentarioValidacao(), comentario)) return;

            await _comentarioRepositorio.Incluir(comentario);
        }


        public async Task<IEnumerable<Comentario>> ComentariosPorPost(Post post)
        {
           return await _comentarioRepositorio.Buscar(c => c.PostId == post.Id);
        }

        public void Dispose()
        {
            _comentarioRepositorio?.Dispose();
            _postRepositorio?.Dispose();
        }

    }
}