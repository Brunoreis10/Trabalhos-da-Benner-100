using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace MatrixMax.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundles/css")
                .Include(
                "~/Content/Css/normalize.css",
                "~/Content/Css/bootstrap.min.css",
                "~/Content/Css/font-awesome.min.css",
                "~/Content/Css/themify-icons.css",
                "~/Content/Css/flag-icon.min.css",
                "~/Content/scss/style.css",
                "~/Content/Css/lib/datatable/dataTables.bootstrap.min.css",
                "~/Content/Css/lib/datatable/select.bootstrap4.min.css",
                "~/Content/Css/select2.min.css",
                "~/Content/Css/select2-bootstrap.min.css",
                "~/Content/Css/rowGroup.dataTables.min.css",
                "~/Content/Css/hotfixes.css"));

            bundles.Add(new ScriptBundle("~/bundles/js")
                .Include(
                "~/Content/js/vendor/jquery-3.3.1.js",
                "~/Content/js/main.js",
                "~/Content/js/popper.min.js",
                "~/Content/js/plugins.js"));

            bundles.Add(new ScriptBundle("~/bundles/tables/js")
                .Include(
                "~/Content/js/lib/data-table/datatables.min.js",
                "~/Content/js/lib/data-table/dataTables.bootstrap.min.js",
                "~/Content/js/lib/data-table/dataTables.buttons.min.js",
                "~/Content/js/lib/data-table/buttons.bootstrap.min.js",
                "~/Content/js/lib/data-table/buttons.html5.min.js",
                "~/Content/js/lib/data-table/buttons.print.min.js",
                "~/Content/js/lib/data-table/buttons.colVis.min.js",
                "~/Content/js/lib/data-table/dataTables.select.min.js"));
        }
    }
}