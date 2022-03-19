using AutoMapper;
using Japuacu.Blog.Aplicacao.Models;
using Japuacu.Blog.Aplicacao.ViewModels;
using Japuacu.Blog.Negocio.Interfaces.Notificacoes;
using Japuacu.Blog.Negocio.Interfaces.Servicos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Japuacu.Blog.Aplicacao.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IPostServico _postServico;
        private readonly IMapper _mapper;

        public HomeController(IMapper mapper,
                             IPostServico postServico,
                             INotificador notificador) : base(notificador)
        {
            _postServico = postServico;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<PostVM>>(await _postServico.Todos()));
           
        }

        public async Task<IActionResult> Post(int id)
        {
            return View(_mapper.Map<PostVM>(await _postServico.PorId(id)));

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
