using DLLsSosPernambucanas.BLL;
using DLLsSosPernambucanas.DML;
using System;
using System.Web.Mvc;

namespace SosWebAdmin.Controllers
{
    public class MonitorController : Controller
    {
        #region Construtor
        private Ocorrencia _ocorrencia;
        private BoOcorrencia _boOcorrencia;        
        private OcorrenciaViewModelDML _ocorrenciaViewModelDML;

        public MonitorController()
        {
            _ocorrencia = new Ocorrencia();
            _boOcorrencia = new BoOcorrencia();
            _ocorrenciaViewModelDML = new OcorrenciaViewModelDML();
        }
        #endregion

        [HttpGet]
        public ActionResult CentralUI()
        {
            if (Models.UsuarioValido.ValidUser())
                return View(_ocorrenciaViewModelDML.ConvertToListOcorrencias(_boOcorrencia.ListaLocaisApoio()));
            else
                return RedirectToAction("Login", "Authentication");            
        }

        [ChildActionOnly]
        public PartialViewResult _ModalSocorrerDenunciante()
        {
            return PartialView();
        }

        [ChildActionOnly]
        public PartialViewResult _ModalFinalizarAtendimento()
        {
            return PartialView();
        }

        [ChildActionOnly]
        public PartialViewResult _ModalConsultarOcorrencia()
        {
            return PartialView();
        }

        [HttpPost]
        public JsonResult LigarDenunciante(string idOcorrencia)
        {            
            return Json(_boOcorrencia.AlterarSituacaoLigacao(Convert.ToInt32(idOcorrencia)), JsonRequestBehavior.AllowGet);            
        }

        [HttpPost]
        public JsonResult OcorrenciaDenunciante(string idOcorrencia, string descricaoOcorrencia)
        {
            return Json(_boOcorrencia.CadastrarOcorrenciaDenunciante(Convert.ToInt32(idOcorrencia), descricaoOcorrencia), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult BuscarOcorrencia(string idOcorrencia)
        {
            _ocorrencia = _boOcorrencia.ConsultarOcorrencia(Convert.ToInt32(idOcorrencia));
            return Json(_ocorrencia, JsonRequestBehavior.AllowGet);
        }
    }
}