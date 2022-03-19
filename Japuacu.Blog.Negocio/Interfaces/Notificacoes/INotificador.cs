using Japuacu.Blog.Negocio.Notificacoes;
using System.Collections.Generic;

namespace Japuacu.Blog.Negocio.Interfaces.Notificacoes
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}