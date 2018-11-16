using System.Web;
using System.Web.Optimization;
using System.Collections.Generic;

namespace hr_201_file
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.UseCdn = true;

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            // Import Pagination and Linea Font
            bundles.Add(new StyleBundle("~/Content/imported").Include(
                      "~/Content/PagedList.css",
                      "~/Content/styles.css"));

            // Import Bootstrap
            bundles.Add(new StyleBundle("~/Content/bootstrapCDN", "https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css"));
            bundles.Add(new ScriptBundle("~/bundles/jquery331CDN", "https://code.jquery.com/jquery-3.3.1.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/popperCDN", "https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/umd/popper.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrapCDN", "https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js"));

            // Import Font Awesome
            bundles.Add(new StyleBundle("~/Content/font-awesomeCDN", "https://use.fontawesome.com/releases/v5.5.0/css/all.css"));
            
            // Import Main Style
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));


            // Import Fine Uploader Script
            bundles.Add(new ScriptBundle("~/bundles/fineUploader").Include(
                        "~/Scripts/jquery.fineuploader-3.1.min.js"));

            // Import Custom Script
            bundles.Add(new ScriptBundle("~/bundles/custom")
                    .IncludeDirectory("~/Scripts/MyScript","*.js", true));

            BundleTable.EnableOptimizations = true;
        }
    }
}
