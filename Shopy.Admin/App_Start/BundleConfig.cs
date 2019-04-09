using System.Web.Optimization;

namespace Shopy.Admin
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            var styles = new StyleBundle("~/Content/bundle/css");
            styles.IncludeDirectory("~/Content/css", "*.css");

            bundles.Add(styles);

            var scirptBundle = new ScriptBundle("~/Content/bundle/js");
            scirptBundle.IncludeDirectory("~/Content/js", "*.css");

            bundles.Add(scirptBundle);

            var scripts = new ScriptBundle("~/Scripts");
            scripts.IncludeDirectory("~/Scripts", "*.js");
            scripts.IncludeDirectory("~/Scripts/ViewModels", "*.js");
            scripts.IncludeDirectory("~/Scripts/Bindings", "*.js");
            scripts.IncludeDirectory("~/Scripts/Validators", "*.js");

            bundles.Add(scripts);
        }
    }
}
