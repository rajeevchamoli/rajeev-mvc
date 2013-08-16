using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using EF.DAL.Models;
using RajeevMVCApp.Customization;
using RajeevMVCApp.Models;

namespace RajeevMVCApp.Controllers
{
    public class CustomerController : Controller
    {
        private NorthwindContext db = new NorthwindContext();

        //
        // GET: /Customer/

        //[OutputCache(CacheProfile = "CustomerIndexListCache", VaryByHeader = "Accept-Language")]
        public ActionResult Index()
        {
            return View(db.Customers.ToList());
        }

        //
        // GET: /Customer/Details/5

        public ActionResult Details(string id = null)
        {
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        //
        // GET: /Customer/Create

        public ActionResult Create()
        {
            if (Request.IsAjaxRequest())
            {
                return PartialView("Create", new Customer());
            }

            return View();
        }

        //
        // POST: /Customer/Create

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        //
        // GET: /Customer/Edit/5

        public ActionResult Edit(string id = null)
        {
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        //
        // POST: /Customer/Edit/5

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        //
        // GET: /Customer/Delete/5

        public ActionResult Delete(string id = null)
        {
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        //
        // POST: /Customer/Delete/5

        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //[JsonpFilter]
        public JsonResult Fetch(string id)
        {
            Customer customer = db.Customers.Find(id);
            //return Content(new JavaScriptSerializer().Serialize(customer.ToCustomerModel()));

            return Json(customer.ToCustomerModel(), "text/javascript", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult FetchPaged(int pageNumber, int size)
        {
            pageNumber = pageNumber > 0 ? pageNumber : 1;
            size = size > 10 ? size : 10;
            var customers = new List<CustomerM>();
            foreach (var customer in db.Customers.Skip(pageNumber * size).Take(size))
            {
                customers.Add(customer.ToCustomerModel());
            }

            return Json(customers, JsonRequestBehavior.AllowGet);
        }

        [ActionName("FetchAll")]
        public JsonResult Fetch()
        {
            var customers = new List<CustomerM>();
            foreach (var customer in db.Customers)
            {
                customers.Add(customer.ToCustomerModel());
            }
            
            return Json(customers, JsonRequestBehavior.AllowGet);
        }


        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}