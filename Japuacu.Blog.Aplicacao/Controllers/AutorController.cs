using AutoMapper;
using Japuacu.Blog.Aplicacao.ViewModels;
using Japuacu.Blog.Negocio.Interfaces.Notificacoes;
using Japuacu.Blog.Negocio.Interfaces.Servicos;
using Japuacu.Blog.Negocio.Modelos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Japuacu.Blog.Aplicacao.Controllers
{
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


        // GET: Autor
        public async Task<IActionResult> Index()
        {
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
