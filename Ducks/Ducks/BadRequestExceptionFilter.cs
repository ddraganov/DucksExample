using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace Ducks
{
    public class BadRequestExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception is ArgumentException)
            {
                actionExecutedContext.Response = actionExecutedContext
                    .Request
                    .CreateResponse(HttpStatusCode.BadRequest, actionExecutedContext.Exception.Message);
            }
        }
    }
}