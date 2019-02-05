using System.Web;
using System.Web.Optimization;

namespace LibDB
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                                         "~/Scripts/jquery-{version}.slim.js",
                                         "~/Scripts/jquery-{version}.js",
                                         "~/Scripts/umd/popper.js",
                                         "~/Scripts/bootstrap.js",
                                         "~/Scripts/modernizr-*",
                                         "~/Scripts/respond.js",
                                         "~/Scripts/jquery.unobtrusive-ajax.js",
                                         "~/Scripts/jquery.dataTables.js"
                                         ));

            bundles.Add(new StyleBundle("~/bundles/styles").Include(
                                "~/Content/css/jquery.dataTables.css",
                                 "~/Content/bootstrap.min.css",
                                 "~/Content/font-awesome.css",
                                 "~/Content/site.css"
                                 ));
        }
    }
}
