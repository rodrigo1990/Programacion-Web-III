using System.Web;
using System.Web.Optimization;

namespace TpPwIII
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/unobstrusive").Include(
                        "~/Scripts/jquery.validate.unobtrusive.min.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/animacionesEnModal").Include(
                      "~/Scripts/manejoDeAnimacionesEnModal.js"));
            
            bundles.Add(new ScriptBundle("~/bundles/validar-captcha").Include(
                      "~/Scripts/validar-captcha.js"));

            bundles.Add(new ScriptBundle("~/bundles/validar-login-usuario").Include(
                      "~/Scripts/validar-login-de-usuario.js"));

            bundles.Add(new ScriptBundle("~/bundles/eventos-menu").Include(
                      "~/Scripts/eventos-menu.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/estilos.css"));
        }
    }
}
