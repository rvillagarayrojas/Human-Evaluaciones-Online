using System.Web;
using System.Web.Optimization;

namespace Sln23Core
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {

            /*open>>> Bundles: Scripst para el sitio del área de sistemas */
                bundles.Add(new ScriptBundle("~/bundles/SitioSistemas").Include(
                            "~/Scripts/Sistemas/jQuery-2.1.4.js",                        
                            "~/Scripts/Sistemas/jquery-ui.js",                        
                            "~/Scripts/Sistemas/bootstrap.js",
                            "~/Scripts/Sistemas/raphael.js",
                            "~/Scripts/Sistemas/morris.js",
                            "~/Scripts/Sistemas/jquery.sparkline.js",
                            "~/Scripts/Sistemas/jquery-jvectormap-1.2.2.js",
                            "~/Scripts/Sistemas/jquery-jvectormap-world-mill-en.js",
                            "~/Scripts/Sistemas/jquery.knob.js",
                            "~/Scripts/Sistemas/moment.js",
                            "~/Scripts/Sistemas/daterangepicker.js",
                            "~/Scripts/Sistemas/bootstrap-datepicker.js",
                            "~/Scripts/Sistemas/bootstrap3-wysihtml5.all.js",
                            "~/Scripts/Sistemas/jquery.slimscroll.js",
                            "~/Scripts/Sistemas/fastclick.js",
                            "~/Scripts/Sistemas/app.js",
                            "~/Scripts/Sistemas/dashboard.js",
                            "~/Scripts/Sistemas/demo.js"                            
               ));
            /*close>> Bundles */

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/Sistemas/jquery.1.11.1.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/getmdls").Include(
                        "~/Scripts/GetMdl.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/yui").Include(
                        "~/Scripts/Sistemas/yui.js",
                        "~/Scripts/Sistemas/textareaAutoheight-min.js"
                        

            ));

            bundles.Add(new ScriptBundle("~/bundles/confirm").Include(
                        "~/Scripts/Sistemas/jquery.confirm.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));
        }
    }
}