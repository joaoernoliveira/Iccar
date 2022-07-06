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
            var listaAnteriores = new List<Anteriores>();  

            foreach (var item in await _postServico.TodosResumoAnteriores())
            {
                listaAnteriores.Add(new Anteriores() {Chave = item, Valor = item }); 
            }

            ViewBag.aneriores = listaAnteriores;
             
            return View(_mapper.Map<IEnumerable<PostVM>>(await _postServico.TodosDeUmMesAno(0, 0)));           
        }
        [HttpPost]
        public async Task<IActionResult> Index(string periodo = "0")
        {
            int mes = 0;
            int ano = 0;


            if (periodo != null)
            {
                mes = int.Parse( periodo.Length == 6 ?  periodo.Substring(0,1): periodo.Substring(0, 2));
                ano = int.Parse(periodo.Length == 6 ? periodo.Substring(2, 4) : periodo.Substring(3, 4));
            }
            
            var listaAnteriores = new List<Anteriores>();

            foreach (var item in await _postServico.TodosResumoAnteriores())
            {
                listaAnteriores.Add(new Anteriores() { Chave = item, Valor = item });
            }

            ViewBag.aneriores = listaAnteriores;
            return View(_mapper.Map<IEnumerable<PostVM>>(await _postServico.TodosDeUmMesAno(ano, mes)));
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

    public class Anteriores
    {
        public string Chave { get; set; }
        public string Valor { get; set; }
    }
}
