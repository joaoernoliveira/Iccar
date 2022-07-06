using Japuacu.Blog.Negocio.Interfaces.Notificacoes;
using Japuacu.Blog.Negocio.Interfaces.Repositorios;
using Japuacu.Blog.Negocio.Interfaces.Servicos;
using Japuacu.Blog.Negocio.Modelos;
using Japuacu.Blog.Negocio.Modelos.Validacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
            return await _postRepositorio.Buscar(p => ! p.Terminado && p.Autor.Nome=="GENIO");
        }

        public async Task<List<Post>> TodosComAutorParagrafos()
        {
            return await _postRepositorio.TodosComAutorParagrafos();
        }

        public async Task<List<Post>> TodosComAutorParagrafosComentarios()
        {
            return await _postRepositorio.TodosComAutorParagrafosComentarios();
        }

        public async Task<IEnumerable<Post>> Buscar(Expression<Func<Post, bool>> predicado)
        {
            return await _postRepositorio.Buscar(predicado);   
        }

        public async Task<List<string>> TodosResumoAnteriores()
        {
            var valores = new List<string>();

            var posts = await _postRepositorio.Todos();

            

            foreach (var item in posts.GroupBy(p => new { p.DataPost.Year, p.DataPost.Month })
                 .Select(group => new {
                     Ano = group.Key.Year,
                     Mes = group.Key.Month
                 }).OrderByDescending(p=>p.Ano).ThenByDescending(p=>p.Mes))
            {
                valores.Add((item.Mes > 9 ? item.Mes : ("0" + item.Mes)) + "/" +item.Ano.ToString());
            }
            return valores;
        }

        public async Task<IEnumerable<Post>> TodosDeUmMesAno(int ano, int mes)
        {
            if (ano == 0 && mes == 0)
            {
                DateTime ultimoPost = (await _postRepositorio.Todos()).OrderBy(p=>p.DataPost).Last().DataPost;
                ano = ultimoPost.Year;
                mes = ultimoPost.Month;
            }
            return (await _postRepositorio.TodosComAutor()).Where(p=>p.DataPost.Year == ano && p.DataPost.Month == mes).OrderByDescending(p=>p.DataPost);
        }


    }
}