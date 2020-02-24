using System.Web;
using System.Web.Optimization;

namespace LojaRazor
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            StyleBundle estilo = new StyleBundle("~/bundles/estilos");
            estilo.Include("~/Content/bootstrap/css/bootstrap.css");
            estilo.Include("~/Content/Style.css");
            bundles.Add(estilo);

            ScriptBundle scripts = new ScriptBundle("~/bundles/scripts");
            scripts.Include("~/Scripts/jquery-1.7.1.js");
            scripts.Include("~/Scripts/jquery.validade.js");
            scripts.Include("~/Scripts/jquery.validade.unobtrusive.js");
            bundles.Add(scripts);
        }
    }
}