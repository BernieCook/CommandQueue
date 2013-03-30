using System.Web.Http;

namespace CommandQueue.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "BlogPostApi",
                routeTemplate: "api/blog-post/{action}",
                defaults: new { controller = "BlogPost" }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}"
            );
        }
    }
}
