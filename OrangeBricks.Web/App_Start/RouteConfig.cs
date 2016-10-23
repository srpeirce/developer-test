using System.Web.Mvc;
using System.Web.Routing;

namespace OrangeBricks.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name:"BookViewing", 
                url:"property/{propertyId}/viewings/book",
                defaults: new { controller = "Viewings", action="Book" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
