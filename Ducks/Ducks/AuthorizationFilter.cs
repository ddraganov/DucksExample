using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Ducks
{
    public class AuthorizationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var token = actionContext.Request.Headers.FirstOrDefault(a => a.Key == "auth-token");
            if (token.Value == null || (token.Value.FirstOrDefault() != "securetoken"))
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
        }
    }
}