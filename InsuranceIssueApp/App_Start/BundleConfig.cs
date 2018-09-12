using System.Web;
using System.Web.Optimization;

namespace InsuranceIssueApp
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

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js",
                      "~/vendor/jquery/jquery.min.js",
                      "~/vendor/bootstrap/js/bootstrap.bundle.min.js",
                      "~/vendor/jquery-easing/jquery.easing.min.js",
                      "~/js/sb-admin.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css"
                     ));
            bundles.Add(new StyleBundle("~/vendor/css").Include(                     
                     "~/vendor/bootstrap/css/bootstrap.min.css",
                     "~/vendor/fontawesome-free/css/all.min.css",
                     "~/vendor/datatables/dataTables.bootstrap4.css",
                     "~/css/sb-admin.css",
                     "~/css/style.css"));

            bundles.Add(new ScriptBundle("~/app").Include(
                       "~/js/app.js"));

            bundles.Add(new ScriptBundle("~/Dashboard").Include(
                      "~/js/Dashboard.js"));

        }
    }
}
