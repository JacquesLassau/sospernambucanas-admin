using System.Web.Mvc;

namespace SosWebAdmin.Controllers
{
    public class HomeController : Controller
    {        
        public ActionResult Index()
        {
            if (Models.UsuarioValido.ValidUser())
                return View();
            else
                return RedirectToAction("Login", "Authentication");
        }
    }
}