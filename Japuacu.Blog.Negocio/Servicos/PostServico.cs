using Japuacu.Blog.Negocio.Interfaces.Notificacoes;
using Japuacu.Blog.Negocio.Interfaces.Repositorios;
using Japuacu.Blog.Negocio.Interfaces.Servicos;
using Japuacu.Blog.Negocio.Modelos;
using Japuacu.Blog.Negocio.Modelos.Validacoes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Japuacu.Blog.Negocio.Servicos
{
    public class PostServico : Servico, IPostServico
    {
        private readonly IPostRepositorio _postRepositorio;

        public PostServico(IPostRepositorio postRepositorio,
                            INotificador notificador) : base(notificador)
        {
            _postRepositorio = postRepositorio;
        }

        public async Task Incluir(Post post)
        {
            if (!ExecutarValidacao(new PostValidacao(), post)) return;

            await _postRepositorio.Incluir(post);
        }

        public async Task Alterar(Post post)
        {
            if (!ExecutarValidacao(new PostValidacao(), post)) return;

            await _postRepositorio.Alterar(post);
        }

        public async Task Excluir(Post post)
        {

            await _postRepositorio.Excluir(post);
        }

        public async Task<Post> PorId(int id)
        {
            return await _postRepositorio.PorId(id);
        }
 

        public void Dispose()
        {
            _postRepositorio?.Dispose();
            _postRepositorio?.Dispose();
        }

        public async Task<IEnumerable<Post>> Todos()
        {
            return await _postRepositorio.TodosComAutor();
        }

        public async Task<IEnumerable<Post>> TodosPublicados()
        {
            return await _postRepositorio.Buscar(p=>p.Terminado);
        }

        public async Task<IEnumerable<Post>> TodosNaoPublicados()
        {
            return await _postRepositorio.Buscar(p => ! p.Terminado);
        }

        public async Task<List<Post>> TodosComAutorParagrafos()
        {
            return await _postRepositorio.TodosComAutorParagrafos();
        }

        public async Task<List<Post>> TodosComAutorParagrafosComentarios()
        {
            return await _postRepositorio.TodosComAutorParagrafosComentarios();
        }
    }
}