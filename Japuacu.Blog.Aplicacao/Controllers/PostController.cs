using AutoMapper;
using Japuacu.Blog.Aplicacao.ViewModels;
using Japuacu.Blog.Negocio.Interfaces.Notificacoes;
using Japuacu.Blog.Negocio.Interfaces.Servicos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Japuacu.Blog.Aplicacao.Controllers
{
    [Authorize]
    public class PostController : BaseController
    {
        private readonly  IPostServico _postServico;
        private readonly IMapper _mapper;

        public PostController(IPostServico postServico, 
                              IMapper mapper, 
                              INotificador notificador) : base(notificador)
        {
            _postServico = postServico;
            _mapper = mapper;
        }



        // GET: Post
        public async Task<IActionResult> Index()
        {            
            return View( _mapper.Map<IEnumerable<PostVM >>(await _postServico.Todos()));
        }

        public async Task<IActionResult> RelatorioDePostsPorAutores()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("https://localhost:44381/Post/PostsPorAutor");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    HttpContent content = response.Content;
                    var contentStream = await content.ReadAsStreamAsync();

                    return File(contentStream, "application/pdf", "PostsPorAutor.pdf");
                }

                return RedirectToAction(nameof(Index));
            }

        }


        // GET: Post/Details/5
        public async Task<IActionResult> Details(int id)
        {

            var post = await _postServico.PorId(id);
                
            if (post == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<PostVM>(post));
        }

        //// GET: Post/Create
        //public IActionResult Create()
        //{
        //    ViewData["AutorId"] = new SelectList(_context.Autors, "Id", "Cpf");
        //    return View();
        //}

        //// POST: Post/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,DataPost,AutorId,TituloPost,ResumoPost,ImagemPost,Terminado")] Post post)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(post);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["AutorId"] = new SelectList(_context.Autors, "Id", "Cpf", post.AutorId);
        //    return View(post);
        //}

        //// GET: Post/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var post = await _context.Posts.FindAsync(id);
        //    if (post == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["AutorId"] = new SelectList(_context.Autors, "Id", "Cpf", post.AutorId);
        //    return View(post);
        //}

        //// POST: Post/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,DataPost,AutorId,TituloPost,ResumoPost,ImagemPost,Terminado")] Post post)
        //{
        //    if (id != post.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(post);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!PostExists(post.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["AutorId"] = new SelectList(_context.Autors, "Id", "Cpf", post.AutorId);
        //    return View(post);
        //}

        //// GET: Post/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var post = await _context.Posts
        //        .Include(p => p.Autor)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (post == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(post);
        //}

        //// POST: Post/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var post = await _context.Posts.FindAsync(id);
        //    _context.Posts.Remove(post);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool PostExists(int id)
        //{
        //    return _context.Posts.Any(e => e.Id == id);
        //}
    }
}
