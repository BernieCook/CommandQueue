using System.Web.Optimization;

namespace CommandQueue.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(
                new StyleBundle("~/css")
                .Include("~/Assets/Bootstrap/css/bootstrap.css")
                .Include("~/Assets/Bootstrap/css/bootstrap-responsive.css")
                .Include("~/Assets/Styles/html.css"));

            bundles.Add(
                new ScriptBundle("~/js")
                .Include("~/Assets/Scripts/jquery-1.9.1.js"));
        }
    }
}