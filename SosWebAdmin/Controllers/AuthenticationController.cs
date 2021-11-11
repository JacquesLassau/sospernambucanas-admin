using DLLsSosPernambucanas.BLL;
using DLLsSosPernambucanas.DML;
using DLLsSosPernambucanas.Infrastructure;
using System;
using System.Web.Mvc;

namespace SosWebAdmin.Controllers
{
    public class AuthenticationController : Controller
    {
        #region Construtor        
        private BoUsuario _boUsuario;
        
        public AuthenticationController()
        {
            _boUsuario = new BoUsuario();            
        }
        #endregion

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Usuario usuario)
        {
            try
            {
                usuario.Tipo = Convert.ToInt32(Constantes.TipoUsuario.ATENDENTE);
                Usuario usuarioAutenticado = _boUsuario.AcessoUsuario(usuario);

                if (usuarioAutenticado != null)
                {
                    if (usuarioAutenticado.Tipo != Convert.ToInt32(Constantes.TipoUsuario.ATENDENTE))
                    {
                        TempData[Constantes.MENSAGEM_TEMP_DATA_TITULO] = Constantes.NAO_VALIDO;
                        TempData[Constantes.MENSAGEM_TEMP_DATA_DESCRICAO] = Constantes.FALHA_LOGIN;
                        return RedirectToAction("Login");
                    }

                    Session["sessaoId"] = usuarioAutenticado.IdUsuario;
                    Session["sessaoEmail"] = usuarioAutenticado.Email;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData[Constantes.MENSAGEM_TEMP_DATA_TITULO] = Constantes.NAO_VALIDO;
                    TempData[Constantes.MENSAGEM_TEMP_DATA_DESCRICAO] = Constantes.FALHA_LOGIN;
                    return RedirectToAction("Login");
                }
            }
            catch
            {
                // A mensagem de erro verdadeira não é exibida propositadamente,
                // para não fornecer informações de possíveis falhas do sistema.

                TempData[Constantes.MENSAGEM_TEMP_DATA_TITULO] = Constantes.NAO_VALIDO;
                TempData[Constantes.MENSAGEM_TEMP_DATA_DESCRICAO] = Constantes.FALHA_LOGIN;
                return RedirectToAction("Login");
            }            
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login");
        }
    }
}
