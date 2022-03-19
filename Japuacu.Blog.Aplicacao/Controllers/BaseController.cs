using Japuacu.Blog.Negocio.Interfaces.Notificacoes;
using Microsoft.AspNetCore.Mvc;

namespace Japuacu.Blog.Aplicacao.Controllers
{
    public class BaseController :Controller
    {
        private readonly INotificador _notificador;

        protected BaseController(INotificador notificador)
        {
            _notificador = notificador;
        }

        protected bool OperacaoValida()
        {
            return !_notificador.TemNotificacao();
        }
    }
}

