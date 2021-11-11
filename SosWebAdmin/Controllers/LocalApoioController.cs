using DLLsSosPernambucanas.BLL;
using DLLsSosPernambucanas.DML;
using DLLsSosPernambucanas.Infrastructure;
using System;
using System.Web.Mvc;

namespace SosWebAdmin.Controllers
{
    public class LocalApoioController : Controller
    {
        #region Construtor      
        private BoLocalApoio _boLocal;
        private LocalApoioViewModelDML _localApoioViewModelDML;

        public LocalApoioController()
        {
            _boLocal = new BoLocalApoio();
            _localApoioViewModelDML = new LocalApoioViewModelDML();
        }
        #endregion

        [HttpGet]
        public ActionResult MapaUI()
        {
            if (Models.UsuarioValido.ValidUser())
                return View();
            else
                return RedirectToAction("Login", "Authentication");
        }

        [HttpGet]
        public ActionResult CadastrarLocalApoioUI()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CadastrarLocalApoioAR(LocalApoio localApoio)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    TempData[Constantes.MENSAGEM_TEMP_DATA_TITULO] = _boLocal.IncluirLocalApoio(localApoio);
                    TempData[Constantes.MENSAGEM_TEMP_DATA_DESCRICAO] = Constantes.REDIRECT;
                }
                catch (Exception e)
                {
                    TempData[Constantes.MENSAGEM_TEMP_DATA_TITULO] = e.Message;
                    TempData[Constantes.MENSAGEM_TEMP_DATA_DESCRICAO] = Constantes.ERRO_NAO_TRATADO;
                }
            }

            return RedirectToAction("MapaUI", "LocalApoio");
        }

        [HttpGet]
        public ActionResult ExcluirLocalApoioAR()
        {            
            try
            {
                string id = Request["btnExcluirLocal"];
                TempData[Constantes.MENSAGEM_TEMP_DATA_TITULO] = _boLocal.ExcluirLocalApoio(Convert.ToInt32(id));
                TempData[Constantes.MENSAGEM_TEMP_DATA_DESCRICAO] = Constantes.REDIRECT;
            }
            catch (Exception ex)
            {
                TempData[Constantes.MENSAGEM_TEMP_DATA_TITULO] = ex.Message;
                TempData[Constantes.MENSAGEM_TEMP_DATA_DESCRICAO] = Constantes.ERRO_NAO_TRATADO;
            }

            return RedirectToAction("MapaUI", "LocalApoio");
        }

        public JsonResult CarregaMapa()
        {
            LocalApoioViewModelDML listaLocaisApoio = _localApoioViewModelDML.ConvertToListLocals(_boLocal.ListaLocaisApoio());
            return Json(listaLocaisApoio, JsonRequestBehavior.AllowGet);
        }
    }
}