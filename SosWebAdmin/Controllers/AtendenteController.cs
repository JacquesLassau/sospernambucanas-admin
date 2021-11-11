using System.Web.Mvc;
using DLLsSosPernambucanas.BLL;
using DLLsSosPernambucanas.DML;
using DLLsSosPernambucanas.Infrastructure;
using System;

namespace SosWebAdmin.Controllers
{
    public class AtendenteController : Controller
    {
        #region Construtor
        private Atendente _atendente;
        private BoAtendente _boAtendente;
        private AtendenteViewModelDML _atendenteViewModelDML;

        public AtendenteController()
        {
            _atendente = new Atendente();
            _boAtendente = new BoAtendente();
            _atendenteViewModelDML = new AtendenteViewModelDML();
        }
        #endregion

        #region Requisições
        [HttpGet]
        public ActionResult CadastrarAtendenteUI()
        {
            if (Models.UsuarioValido.ValidUser())
                return View();
            else
                return RedirectToAction("Login", "Authentication");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CadastrarAtendenteAR(Atendente atendente)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    TempData[Constantes.MENSAGEM_TEMP_DATA_TITULO] = _boAtendente.IncluirAtendente(atendente);
                    TempData[Constantes.MENSAGEM_TEMP_DATA_DESCRICAO] = Constantes.REDIRECT;                    
                }
                catch (Exception ex)
                {
                    TempData[Constantes.MENSAGEM_TEMP_DATA_TITULO] = ex.Message;
                    TempData[Constantes.MENSAGEM_TEMP_DATA_DESCRICAO] = Constantes.ERRO_NAO_TRATADO;                    
                }

            }

            return RedirectToAction("CadastrarAtendenteUI", "Atendente");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarAtendenteAR(Atendente atendente)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    TempData[Constantes.MENSAGEM_TEMP_DATA_TITULO] = _boAtendente.EditarAtendente(atendente);
                    TempData[Constantes.MENSAGEM_TEMP_DATA_DESCRICAO] = Constantes.REDIRECT;                    
                }
                catch (Exception ex)
                {
                    TempData[Constantes.MENSAGEM_TEMP_DATA_TITULO] = ex.Message;
                    TempData[Constantes.MENSAGEM_TEMP_DATA_DESCRICAO] = Constantes.ERRO_NAO_TRATADO;                    
                }

            }

            return RedirectToAction("BuscarAtendenteUI", "Atendente");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ExcluirAtendenteAR(Atendente atendente)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    TempData[Constantes.MENSAGEM_TEMP_DATA_TITULO] = _boAtendente.ExcluirAtendente(atendente);
                    TempData[Constantes.MENSAGEM_TEMP_DATA_DESCRICAO] = Constantes.REDIRECT;                    
                }
                catch (Exception ex)
                {
                    TempData[Constantes.MENSAGEM_TEMP_DATA_TITULO] = ex.Message;
                    TempData[Constantes.MENSAGEM_TEMP_DATA_DESCRICAO] = Constantes.ERRO_NAO_TRATADO;                    
                }

            }

            return RedirectToAction("BuscarAtendenteUI", "Atendente");
        }

        [HttpGet]
        public ActionResult IframeListaAtendenteUI()
        {
            if (Models.UsuarioValido.ValidUser())
            {
                AtendenteViewModelDML atendentes = _atendenteViewModelDML.ConvertToListAtendentes(_boAtendente.ListaAtendentes());
                return View(atendentes);
            }            
            else
                return RedirectToAction("Login", "Authentication");            
        }

        [HttpGet]
        public ActionResult BuscarAtendenteUI()
        {
            if (Models.UsuarioValido.ValidUser())
                return View();
            else
                return RedirectToAction("Login", "Authentication");
        }

        [ChildActionOnly]
        public PartialViewResult _ModalListaAtendenteUI()
        {
            return PartialView();
        }

        [HttpGet]
        public JsonResult SelecionarAtendente(int codigoAtendente)
        {
            _atendente = _boAtendente.SelecionaAtendente(codigoAtendente);
            return Json(_atendente, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult BuscarAtendenteAR(string IdAtendente)
        {
            try
            {
                string btnTipoAcao = Request["btnCodigoAtendente"];

                if (string.IsNullOrWhiteSpace(btnTipoAcao))
                {
                    TempData[Constantes.MENSAGEM_TEMP_DATA_TITULO] = Constantes.CONSULTA_ATENDENTE_VAZIA;
                    TempData[Constantes.MENSAGEM_TEMP_DATA_DESCRICAO] = Constantes.CONSULTA_ATENDENTE_VAZIA_DESCRICAO;
                    return RedirectToAction("BuscarAtendenteUI", "Atendente");
                }

                if (string.IsNullOrWhiteSpace(IdAtendente))
                {
                    TempData[Constantes.MENSAGEM_TEMP_DATA_TITULO] = Constantes.CONSULTA_ATENDENTE_VAZIA;
                    TempData[Constantes.MENSAGEM_TEMP_DATA_DESCRICAO] = Constantes.CONSULTA_ATENDENTE_VAZIA_DESCRICAO;
                    return RedirectToAction("BuscarAtendenteUI", "Atendente");
                }

                _atendente = _boAtendente.SelecionaAtendente(Convert.ToInt32(IdAtendente));

                if (_atendente.IdAtendente != 0)
                {
                    // Por algum motivo, o campo de senha e confirmação não estão sendo carregados.
                    // É possível que os tipos password divergentes estejam impedindo o carregamento.
                    // Criada sessão para preencher os valores nos campos:

                    Session["Senha"] = _atendente.Senha;

                    switch (btnTipoAcao)
                    {
                        case "Detalhes":
                            return View("DetalhesAtendenteUI", _atendente);

                        case "Editar":
                            return View("EditarAtendenteUI", _atendente);

                        case "Excluir":
                            return View("ExcluirAtendenteUI", _atendente);

                        default:
                            TempData[Constantes.MENSAGEM_TEMP_DATA_TITULO] = Constantes.FALHA_REDIRECT;
                            TempData[Constantes.MENSAGEM_TEMP_DATA_DESCRICAO] = Constantes.CONSULTA_ATENDENTE_VAZIA_DESCRICAO;
                            return RedirectToAction("BuscarAtendenteUI", "Atendente");
                    }
                }
                else
                {
                    TempData[Constantes.MENSAGEM_TEMP_DATA_TITULO] = Constantes.CONSULTA_ATENDENTE_VAZIA;
                    TempData[Constantes.MENSAGEM_TEMP_DATA_DESCRICAO] = Constantes.CONSULTA_ATENDENTE_VAZIA_DESCRICAO;
                    return RedirectToAction("BuscarAtendenteUI", "Atendente");
                }
            }
            catch(Exception e)
            {
                TempData[Constantes.MENSAGEM_TEMP_DATA_TITULO] = Constantes.ERRO_NAO_TRATADO;
                TempData[Constantes.MENSAGEM_TEMP_DATA_DESCRICAO] = e.Message;
                return RedirectToAction("BuscarAtendenteUI", "Atendente");
            }           
        }

        [HttpGet]
        public ActionResult DetalhesAtendenteUI()
        {
            if (Models.UsuarioValido.ValidUser())
                return View();
            else
                return RedirectToAction("Login", "Authentication");
        }

        [HttpGet]
        public ActionResult EditarAtendenteUI()
        {
            if (Models.UsuarioValido.ValidUser())
                return View();
            else
                return RedirectToAction("Login", "Authentication");
        }

        [HttpGet]
        public ActionResult ExcluirAtendenteUI()
        {
            if (Models.UsuarioValido.ValidUser())
                return View();
            else
                return RedirectToAction("Login", "Authentication");
        }

        [ChildActionOnly]
        public PartialViewResult _ConfirmarExclusao()
        {
            return PartialView("~/Views/Shared/_ConfirmaExclusao.cshtml");
        }
        #endregion
    }
}