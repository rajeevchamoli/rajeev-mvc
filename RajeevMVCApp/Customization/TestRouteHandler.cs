﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace RajeevMVCApp.Customization
{
    public class TestRouteHandler : IRouteHandler
    {
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            TestHttpHandler httphandler = new TestHttpHandler();
            return httphandler;
        }
    }
}