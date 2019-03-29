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
            scripts.IncludeDirectory("~/Content/js", "*.js");
            scripts.IncludeDirectory("~/Scripts/Common", "*.js");
            scripts.IncludeDirectory("~/Scripts/Products", "*.js");

            bundles.Add(scripts);
        }
    }
}
