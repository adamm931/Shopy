using System.Web.Optimization;

namespace Shopy.Public
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            var styles = new StyleBundle("~/Content/bundle/css");
            styles.IncludeDirectory("~/Content/css/", "*.css");
            bundles.Add(styles);

            var scripts = new ScriptBundle("~/Content/bundle/js");
            //scripts.IncludeDirectory("~/Content/js", "*.js");
            //scripts.IncludeDirectory("~/Content/js/core", "*.js");
            //scripts.IncludeDirectory("~/Content/js/plugins", "*.js");
            bundles.Add(scripts);

            var scriptsLib = new ScriptBundle("~/Content/bundle/js-lib");
            scripts.IncludeDirectory("~/Scripts/Common", "*.js");
            scripts.IncludeDirectory("~/Scripts/ViewModels", "*.js");

            bundles.Add(scriptsLib);
        }
    }
}
