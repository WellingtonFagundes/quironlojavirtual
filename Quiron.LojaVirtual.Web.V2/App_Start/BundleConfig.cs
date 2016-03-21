using System.Web;
using System.Web.Optimization;

namespace Quiron.LojaVirtual.Web.V2
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            //bundles.Add(new StyleBundle("~/css").Include(
            //    "~/css/*.css"));

            bundles.Add(new StyleBundle("~/css").Include(
                "~/css/bootstrap.min.css",
                "~/css/animate.min.css",
                "~/css/jquery.countdown.css",
                "~/css/font-awesome.min.css",
                "~/css/style.css"
                ));

            bundles.Add(new ScriptBundle("~/js").Include(
                "~/js/jquery.js",
                "~/js/bootstrap.js",
                "~/js/bootstrap.min.js",
                "~/js/ddlevelsmenu.js",
                "~/js/jquery.plugin.min.js",
                "~/js/jquery.countdown.min.js",
                "~/js/filter.js",
                "~/js/respond.min.js",
                "~/js/jquery.navgoco.min.js",
                "~/js/html5shiv.js",
                "~/js/custom.js"

                ));

            // <!-- SmartMenu http://www.smartmenus.org -->
            bundles.Add(new StyleBundle("~/Content/startmenu").Include(
                "~/Content/sm-core-css.css",
                "~/Content/sm-simple/sm-simple.css"
                //"~/Content/sm-mint/sm-mint.css"
                ));
            
            bundles.Add(new ScriptBundle("~/Scripts/startmenu").Include(
                "~/Scripts/jquery.smartmenus.js"
                ));

            bundles.Add(new ScriptBundle("~/Scripts/jsprojetos").Include(
                "~/Scripts/menu.js"
                ));

            BundleTable.EnableOptimizations = false;

        }
    }
}
