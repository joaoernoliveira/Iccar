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
    public class ParagrafoServico : Servico, IParagrafoServico
    {
        private readonly IParagrafoRepositorio _paragrafoRepositorio;

        public ParagrafoServico(IParagrafoRepositorio paragrafoRepositorio,
                            INotificador notificador) : base(notificador)
        {
            _paragrafoRepositorio = paragrafoRepositorio;
        }

        public async Task Incluir(Paragrafo paragrafo)
        {
            if (!ExecutarValidacao(new ParagrafoValidacao(), paragrafo)) return;



            await _paragrafoRepositorio.Incluir(paragrafo);
        }

        public async Task Alterar(Paragrafo paragrafo)
        {
            if (!ExecutarValidacao(new ParagrafoValidacao(), paragrafo)) return;

            await _paragrafoRepositorio.Alterar(paragrafo);
        }

        public async Task Excluir(Paragrafo paragrafo)
        {

            await _paragrafoRepositorio.Excluir(paragrafo);
        }

        public async Task<Paragrafo> PorId(int id)
        {
            return await _paragrafoRepositorio.PorId(id);
        }

        public async Task<IEnumerable<Paragrafo>> ParagrafosPorPost(Post post)
        {
            return await _paragrafoRepositorio.Buscar(p=> p.PostId == post.Id);
        }
 
        public void Dispose()
        {
            _paragrafoRepositorio?.Dispose();
        }


    }
}