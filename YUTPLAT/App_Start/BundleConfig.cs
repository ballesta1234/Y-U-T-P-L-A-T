using System.Web;
using System.Web.Optimization;

namespace YUTPLAT
{
    public class BundleConfig
    {
        // Para obtener más información sobre Bundles, visite http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // preparado para la producción y podrá utilizar la herramienta de compilación disponible en http://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Scripts/moment-with-locales.js",
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/bootstrap-datetimepicker.js",
                        "~/Scripts/respond.js",
                        "~/Scripts/bootstrap-checkbox-radio-switch.js",
                        "~/Scripts/bootstrap-notify.js",
                        "~/Scripts/bootstrap-select.js",
                        "~/Scripts/chartist.min.js",
                        "~/Scripts/demo.js",
                        "~/Scripts/light-bootstrap-dashboard.js",
                        "~/Scripts/select2.full.min.js",
                        "~/Scripts/Graficos/d3.v3.js",
                        "~/Scripts/Graficos/d3.tip.v0.6.3.js"
                        ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/Content/bootstrap.css",
                        "~/Content/bootstrap-datetimepicker.min.css",
                        "~/Content/site.css",
                        "~/Content/demo.css",
                        "~/Content/light-bootstrap-dashboard.css",
                        "~/Content/pe-icon-7-stroke.css",
                        "~/Content/animate.min.css",
                        "~/Content/select2.min.css"
                        ));           
        }
    }
}
