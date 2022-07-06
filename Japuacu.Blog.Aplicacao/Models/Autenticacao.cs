using Japuacu.Blog.Negocio.Interfaces.Notificacoes;
using Japuacu.Blog.Negocio.Interfaces.Servicos;
using Japuacu.Blog.Negocio.Modelos;
using System.Threading.Tasks;

namespace Japuacu.Blog.Aplicacao.Models
{
    public class Autenticacao : IAutenticacao
    {
        private readonly IUsuarioServico _usuarioServico;
        private readonly INotificador _notificador;


        public Autenticacao(IUsuarioServico usuarioServico,
                            INotificador notificador)
        {
            _notificador = notificador;      
            _usuarioServico = usuarioServico;
        }

        public async Task<bool> RegistrarUsuario(Usuario usuario)
        {
            await  _usuarioServico.Incluir(usuario);
            if (_notificador.TemNotificacao()) return false;
            return true;
        }

        public async Task<bool> ValidarLogin(Usuario usuario)
        {
            return await _usuarioServico.ValidarSenha(usuario);
        }
    }
}