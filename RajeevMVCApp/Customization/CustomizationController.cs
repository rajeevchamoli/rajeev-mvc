using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RajeevMVCApp.Customization
{
    public class CustomizationController : Controller
    {
        string ControllerNamePassedByUser { get; set; }
        //
        // GET: /Customization/

        public ActionResult Index()
        {
            return View();
        }

    }
}
