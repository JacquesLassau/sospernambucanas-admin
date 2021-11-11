using System.Web.Mvc;
using DLLsSosPernambucanas.BLL;
using DLLsSosPernambucanas.DML;
using DLLsSosPernambucanas.Infrastructure;
using System;

namespace SosWebAdmin.Controllers
{
    public class DenuncianteController : Controller
    {
        #region Construtor
        private Denunciante _denunciante;
        private BoDenunciante _boDenunciante;
        private DenuncianteViewModelDML _denuncianteViewModelDML;

        public DenuncianteController()
        {
            _denunciante = new Denunciante();
            _boDenunciante = new BoDenunciante();
            _denuncianteViewModelDML = new DenuncianteViewModelDML();
        }
        #endregion

        #region Requisições
        [HttpGet]
        public ActionResult CadastrarDenuncianteUI()
        {
            if (Models.UsuarioValido.ValidUser())
                return View();
            else
                return RedirectToAction("Login", "Authentication");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CadastrarDenuncianteAR(Denunciante denunciante)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Denunciante cadastroDenunciante = _boDenunciante.IncluirDenunciante(denunciante);
                    if (cadastroDenunciante != null)
                    {
                        TempData[Constantes.MENSAGEM_TEMP_DATA_TITULO] = Constantes.CADASTRO_ATENDENTE_SUCESSO;
                        TempData[Constantes.MENSAGEM_TEMP_DATA_DESCRICAO] = Constantes.REDIRECT;                        
                    }                    
                }
                catch (Exception e)
                {
                    TempData[Constantes.MENSAGEM_TEMP_DATA_TITULO] = Constantes.ERRO_NAO_TRATADO;
                    TempData[Constantes.MENSAGEM_TEMP_DATA_DESCRICAO] = e.Message;                    
                }
            }

            return RedirectToAction("CadastrarDenuncianteUI", "Denunciante");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarDenuncianteAR(Denunciante denunciante)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    TempData[Constantes.MENSAGEM_TEMP_DATA_TITULO] = _boDenunciante.EditarDenunciante(denunciante);
                    TempData[Constantes.MENSAGEM_TEMP_DATA_DESCRICAO] = Constantes.REDIRECT;                    
                }
                catch (Exception ex)
                {
                    TempData[Constantes.MENSAGEM_TEMP_DATA_TITULO] = ex.Message;
                    TempData[Constantes.MENSAGEM_TEMP_DATA_DESCRICAO] = Constantes.ERRO_NAO_TRATADO;                    
                }

            }

            return RedirectToAction("BuscarDenuncianteUI", "Denunciante");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ExcluirDenuncianteAR(Denunciante denunciante)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    TempData[Constantes.MENSAGEM_TEMP_DATA_TITULO] = _boDenunciante.ExcluirDenunciante(denunciante);
                    TempData[Constantes.MENSAGEM_TEMP_DATA_DESCRICAO] = Constantes.REDIRECT;                    
                }
                catch (Exception ex)
                {
                    TempData[Constantes.MENSAGEM_TEMP_DATA_TITULO] = ex.Message;
                    TempData[Constantes.MENSAGEM_TEMP_DATA_DESCRICAO] = Constantes.ERRO_NAO_TRATADO;                    
                }

            }

            return RedirectToAction("BuscarDenuncianteUI", "Denunciante");
        }

        [HttpGet]
        public ActionResult IframeListaDenuncianteUI()
        {
            if (Models.UsuarioValido.ValidUser())
            {
                DenuncianteViewModelDML denunciantes = _denuncianteViewModelDML.ConvertToListDenunciantes(_boDenunciante.ListaDenunciantes());
                return View(denunciantes);
            }
            else
                return RedirectToAction("Login", "Authentication");            
        }

        [HttpGet]
        public ActionResult BuscarDenuncianteUI()
        {
            return View();
        }

        [ChildActionOnly]
        public PartialViewResult _ModalListaDenuncianteUI()
        {
            return PartialView();
        }

        [HttpGet]
        public JsonResult SelecionarDenunciante(int codigoDenunciante)
        {
            _denunciante = _boDenunciante.SelecionaDenunciante(codigoDenunciante);
            return Json(_denunciante, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult BuscarDenuncianteAR(string IdDenunciante)
        {
            try
            {
                string btnTipoAcao = Request["btnCodigoDenunciante"];

                if (string.IsNullOrWhiteSpace(btnTipoAcao))
                {
                    TempData[Constantes.MENSAGEM_TEMP_DATA_TITULO] = Constantes.CONSULTA_DENUNCIANTE_VAZIA;
                    TempData[Constantes.MENSAGEM_TEMP_DATA_DESCRICAO] = Constantes.CONSULTA_DENUNCIANTE_VAZIA_DESCRICAO;
                    return RedirectToAction("BuscarDenuncianteUI", "Denunciante");
                }

                if (string.IsNullOrWhiteSpace(IdDenunciante))
                {
                    TempData[Constantes.MENSAGEM_TEMP_DATA_TITULO] = Constantes.CONSULTA_DENUNCIANTE_VAZIA;
                    TempData[Constantes.MENSAGEM_TEMP_DATA_DESCRICAO] = Constantes.CONSULTA_DENUNCIANTE_VAZIA_DESCRICAO;
                    return RedirectToAction("BuscarDenuncianteUI", "Denunciante");
                }

                _denunciante = _boDenunciante.SelecionaDenunciante(Convert.ToInt32(IdDenunciante));

                if (_denunciante.IdDenunciante != 0)
                {
                    // Por algum motivo, o campo de senha e confirmação não estão sendo carregados.
                    // É possível que os tipos password divergentes estejam impedindo o carregamento.
                    // Criada sessão para preencher os valores nos campos.

                    Session["Senha"] = _denunciante.Senha;

                    switch (btnTipoAcao)
                    {
                        case "Detalhes":
                            return View("DetalhesDenuncianteUI", _denunciante);

                        case "Editar":
                            return View("EditarDenuncianteUI", _denunciante);

                        case "Excluir":
                            return View("ExcluirDenuncianteUI", _denunciante);

                        default:
                            TempData[Constantes.MENSAGEM_TEMP_DATA_TITULO] = Constantes.FALHA_REDIRECT;
                            TempData[Constantes.MENSAGEM_TEMP_DATA_DESCRICAO] = Constantes.CONSULTA_DENUNCIANTE_VAZIA_DESCRICAO;
                            return RedirectToAction("BuscarDenuncianteUI", "Denunciante");
                    }
                }
                else
                {
                    TempData[Constantes.MENSAGEM_TEMP_DATA_TITULO] = Constantes.CONSULTA_DENUNCIANTE_VAZIA;
                    TempData[Constantes.MENSAGEM_TEMP_DATA_DESCRICAO] = Constantes.CONSULTA_DENUNCIANTE_VAZIA_DESCRICAO;
                    return RedirectToAction("BuscarDenuncianteUI", "Denunciante");
                }
            }
            catch(Exception e)
            {
                TempData[Constantes.MENSAGEM_TEMP_DATA_TITULO] = Constantes.ERRO_NAO_TRATADO;
                TempData[Constantes.MENSAGEM_TEMP_DATA_DESCRICAO] = e.Message;
                return RedirectToAction("BuscarDenuncianteUI", "Denunciante");
            }            
        }

        [HttpGet]
        public ActionResult DetalhesDenuncianteUI()
        {
            if (Models.UsuarioValido.ValidUser())
                return View();
            else
                return RedirectToAction("Login", "Authentication");
        }

        [HttpGet]
        public ActionResult EditarDenuncianteUI()
        {
            if (Models.UsuarioValido.ValidUser())
                return View();
            else
                return RedirectToAction("Login", "Authentication");
        }

        [HttpGet]
        public ActionResult ExcluirDenuncianteUI()
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