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
    public class AutorServico : Servico, IAutorServico
    {
        private readonly IAutorRepositorio _autorRepositorio;
        private readonly IPostRepositorio _postRepositorio;

        public AutorServico(IAutorRepositorio autorRepositorio,
                            IPostRepositorio postRepositorio,
                            INotificador notificador) : base(notificador)
        {
            _autorRepositorio = autorRepositorio;
            _postRepositorio = postRepositorio;
        }

        public async Task Incluir(Autor autor)
        {
            if (!ExecutarValidacao(new AutorValidacao(), autor)) return;

            if (_autorRepositorio.Buscar(a => a.Cpf== autor.Cpf).Result.Any())
            {
                Notificar("Já existe um autor com este documento infomado.");
                return;
            }

            await _autorRepositorio.Incluir(autor);
        }

        public async Task Alterar(Autor autor)
        {
            if (!ExecutarValidacao(new AutorValidacao(), autor)) return;

            if (_autorRepositorio.Buscar(a => a.Cpf == autor.Cpf && a.Id != autor.Id).Result.Any())
            {
                Notificar("Já existe um autor com o número de CPF infomado.");
                return;
            }

            await _autorRepositorio.Alterar(autor);
        }

        public async Task Excluir(Autor autor)
        {
            if ( (await QtdePostsPorAutor(autor)) > 0)
            {
                Notificar("O Autor tem Posts cadastrados!");
                return;
            }

            await _autorRepositorio.Excluir(autor);
        }

        public async Task<IEnumerable<Autor>> Todos()
        {
            return await _autorRepositorio.Todos();
        }


        public async Task<Autor> PorId(int id)
        {
            return await _autorRepositorio.PorId(id);
        }

        public async Task<int> QtdePostsPorAutor(Autor autor) 
        {
            return (await _postRepositorio.Buscar(a => a.AutorId == autor.Id)).Count();
        }



        public Task<IEnumerable<Autor>> PorDocumento(string cpf)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Autor>> PorNome(string nome)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Post>> PostsPorAutor(Autor autor)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _autorRepositorio?.Dispose();
            _postRepositorio?.Dispose();
        }
    }
}