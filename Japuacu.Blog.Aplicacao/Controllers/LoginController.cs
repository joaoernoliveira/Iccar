using Japuacu.Blog.Aplicacao.Models;
using Japuacu.Blog.Negocio.Modelos;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Japuacu.Blog.Aplicacao.Controllers
{
    public class LoginController : Controller
    {
        private readonly IAutenticacao _autentica;

        public LoginController(IAutenticacao autentica)
        {
            _autentica = autentica;
        }

        [HttpGet]
        public IActionResult RegistrarUsuario()
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarUsuario([Bind] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                var RegistroStatus = await _autentica.RegistrarUsuario(usuario);
                if (RegistroStatus)
                {
                    ModelState.Clear();
                    TempData["Sucesso"] = "Registro realizado com sucesso!";
                    return View();
                }
                else
                {
                    TempData["Falhou"] = "O Registro do usuário falhou.";
                    return View();
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult LoginUsuario()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("LoginUsuario", "Login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginUsuario([Bind] Usuario usuario)
        {
            ModelState.Remove("Nome");
            ModelState.Remove("Email");

            if (ModelState.IsValid)
            {
                var LoginStatus = await _autentica.ValidarLogin(usuario);

                if (LoginStatus)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, usuario.Login)
                    };

                    ClaimsIdentity usuarioIdentificacao = new ClaimsIdentity(claims, "login");

                    var x = usuarioIdentificacao;

                    ClaimsPrincipal principal = new ClaimsPrincipal(usuarioIdentificacao);

                    
                    await HttpContext.SignInAsync(principal);


                    if (User.Identity.IsAuthenticated)
                        return RedirectToAction("Index", "Login");
                    else
                    {
                        TempData["LoginUsuarioFalhou"] = "O login Falhou. Informe as credenciais corretas " + User.Identity.Name;
                        return RedirectToAction("LoginUsuario", "Login");
                    }
                }
                else
                {
                    TempData["LoginUsuarioFalhou"] = "O login Falhou. Informe as credenciais corretas";
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
    }
}
