using System.Web.Http;

namespace refactor_this
{
    /// <summary>
    /// Basic Config Class for Web API
    /// </summary>
    public class WebApiConfig
    {
        /// <summary>
        /// Register basic settings of web API
        /// </summary>
        /// <param name="config">httpconfiguration parameter</param>
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var formatters = GlobalConfiguration.Configuration.Formatters;
            formatters.Remove(formatters.XmlFormatter);
            formatters.JsonFormatter.Indent = true;

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new
                {
                    id = RouteParameter.Optional
                }
            );
        }
    }
}