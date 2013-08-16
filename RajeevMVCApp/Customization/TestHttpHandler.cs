using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RajeevMVCApp.Customization
{
    public class TestHttpHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            context.Response.Write("Testing Http Handlers from MVC");
        }
    }
}