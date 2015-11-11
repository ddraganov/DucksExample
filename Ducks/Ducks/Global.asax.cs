using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.Http;
using System.Web.Security;
using System.Web.SessionState;

namespace Ducks
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var config = GlobalConfiguration.Configuration;

            config.Routes.MapHttpRoute(
                name: "DefaultRoute",
                routeTemplate: "api/{controller}/{id}",
                defaults: new {id = RouteParameter.Optional});

            config.MapHttpAttributeRoutes();

            config.Filters.Add(new BadRequestExceptionFilter());
            //config.Filters.Add(new AuthorizationFilter());

            config.EnsureInitialized();
        }
    }
}