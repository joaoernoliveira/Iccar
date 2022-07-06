using AutoMapper;
using Japuacu.Blog.Aplicacao.ViewModels;
using Japuacu.Blog.Negocio.Interfaces.Notificacoes;
using Japuacu.Blog.Negocio.Interfaces.Servicos;
using Japuacu.Blog.Negocio.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Japuacu.Blog.Aplicacao.Controllers
{
    [Authorize]
    public class AutorController : BaseController
    {
        private readonly IAutorServico _autorServico;
        private readonly IMapper _mapper;

        public AutorController(IMapper mapper,
                                IAutorServico autorServico,
                                INotificador notificador) : base(notificador)
        {
            _autorServico = autorServico;
            _mapper = mapper;
        }


        public async Task<IActionResult> RelatorioDeAutores()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("https://localhost:44381/Autor/ListagemAutor");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    HttpContent content = response.Content;
                    var contentStream = await content.ReadAsStreamAsync();

                    return File(contentStream, "application/pdf", "ListagemAutor.pdf");
                }

                return RedirectToAction(nameof(Index));
            }

        }


        // GET: Autor
        public async Task<IActionResult> Index()
        {
            var usuarioRequest = HttpContext.User.Identity.Name;
            var usuarioController = this.User.Identity.Name;

            var caminhoController = this.Url.ActionContext.RouteData.Values["Controller"];
            var caminhoAction = this.Url.ActionContext.RouteData.Values["Action"];


            return View(_mapper.Map<IEnumerable<AutorVM>>(await _autorServico.Todos()));

        }

        // GET: Autor/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var autorVM = await ObterAutor(id);

            if (autorVM == null)
            {
                return NotFound();
            }

            return View(autorVM);
        }

        // GET: Autor/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Autor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AutorVM autorVM)
        {
            if (!ModelState.IsValid) return View(autorVM);

            var autor = _mapper.Map<Autor>(autorVM);
            await _autorServico.Incluir(autor);

            if (!OperacaoValida()) return View(autorVM);

            return RedirectToAction("Index");
        }

        // GET: Autor/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var autorVM = _mapper.Map<AutorVM>(await _autorServico.PorId(id));

            if (autorVM == null)
            {
                return NotFound();
            }

            return View(autorVM);

        }

        // POST: Autor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AutorVM autorVM)
        {
            if (id != autorVM.Id) return NotFound();

            if (!ModelState.IsValid) return View(autorVM);

            var autor = _mapper.Map<Autor>(autorVM);
            await _autorServico.Alterar(autor);

            if (!OperacaoValida()) return View(autorVM);

            return RedirectToAction("Index");
        }

        // GET: Autor/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var autorVM =_mapper.Map<AutorVM>(await _autorServico.PorId(id));

            if (autorVM == null)
            {
                return NotFound();
            }

            return View(autorVM);
        }

        // POST: Autor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var autor = await  _autorServico.PorId(id);
            await _autorServico.Excluir(autor);

            if (!OperacaoValida())
            {
                var autorVM =  _mapper.Map<AutorVM>(autor);
                return View(autorVM);
            }
            return RedirectToAction(nameof(Index));
        }

        //private bool AutorExists(int id)
        //{
        //    return _context.Autors.Any(e => e.Id == id);
        //}

        private async Task<AutorVM> ObterAutor(int id)
        {
            var autor = _mapper.Map<AutorVM>(await _autorServico.PorId(id));
            return autor;
        }


       
    }
}
