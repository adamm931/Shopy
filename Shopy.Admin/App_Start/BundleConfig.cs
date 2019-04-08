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

            var scripts = new ScriptBundle("~/Content/bundle/js");
            scripts.IncludeDirectory("~/Scripts", "*.js");
            scripts.IncludeDirectory("~/Scripts/ViewModels", "*.js");
            scripts.IncludeDirectory("~/Scripts/Bindings", "*.js");

            bundles.Add(scripts);
        }
    }
}
