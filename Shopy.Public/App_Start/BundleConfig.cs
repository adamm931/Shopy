using System.Web.Optimization;

namespace Shopy.Public
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            AddThemeCss(bundles);
            AddScriptLibs(bundles);
            AddMaterialJsKit(bundles);
        }

        private static void AddScriptLibs(BundleCollection bundles)
        {
            var scriptsLib = new ScriptBundle("~/Content/bundle/js-lib");
            scriptsLib.IncludeDirectory("~/Scripts/Common", "*.js");
            scriptsLib.IncludeDirectory("~/Scripts/ViewModels", "*.js");
            scriptsLib.IncludeDirectory("~/Scripts", "*.js");

            bundles.Add(scriptsLib);
        }

        private static void AddThemeCss(BundleCollection bundles)
        {
            var styles = new StyleBundle("~/Content/bundle/css");
            styles.IncludeDirectory("~/Content/css/", "*.css");
            bundles.Add(styles);
        }

        private static void AddMaterialJsKit(BundleCollection bundles)
        {
            var materialKitScripts = new ScriptBundle("~/Content/bundle/material-kit-js");
            materialKitScripts.Include(
                "~/Content/js/core/jquery.min.js",
                "~/Content/js/core/popper.min.js",
                "~/Content/js/core/bootstrap-material-design.min.js",
                "~/Content/js/plugins/moment.min.js",
                "~/Content/js/plugins/nouislider.min.js",
                "~/Content/js/material-kit.js");

            bundles.Add(materialKitScripts);
        }
    }
}
