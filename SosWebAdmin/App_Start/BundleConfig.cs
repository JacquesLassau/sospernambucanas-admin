using System.Web;
using System.Web.Optimization;

namespace SosWebAdmin
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/Atendente").Include(
                        "~/Scripts/Atendente/BuscarAtendente.js",
                        "~/Scripts/Atendente/ListarAtendentes.js"));

            bundles.Add(new ScriptBundle("~/bundles/Genericos").Include(
                        "~/Scripts/Genericos/ChamadasExternasIframes.js",
                        "~/Scripts/Genericos/Utils.js"));

            bundles.Add(new ScriptBundle("~/bundles/Denunciante").Include(
                        "~/Scripts/Denunciante/BuscarDenunciante.js",
                        "~/Scripts/Denunciante/ListarDenunciantes.js"));

            bundles.Add(new ScriptBundle("~/bundles/Mapa").Include(                        
                        "~/Scripts/Mapa/CarregaMapa.js"));

            bundles.Add(new ScriptBundle("~/bundles/Monitor").Include(
                        "~/Scripts/Monitor/Central.js"));
        }
    }
}
