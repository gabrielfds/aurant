using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using auRant.Services;
using auRant.Core.DataBase;
using auRant.Visual.Areas.Administration.Models;

namespace auRant.Visual.Areas.Administration.Controllers
{
    public class supplierController : Controller
    {
        SupplierService supplierService = null;

        public supplierController()
        {
            this.supplierService = new SupplierService(ContextFactory.GetContext(System.Web.HttpContext.Current));
        }
        public ActionResult Index()
        {
            var model = new List<SupplierModel>();
            this.supplierService.GetAll().ForEach(m => model.Add(new SupplierModel(m)));
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(SupplierModel model)
        {
            if (ModelState.IsValid)
            {
                this.supplierService.Create(model.CreatesupplierFromModel());
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(SupplierModel model)
        {
            if (ModelState.IsValid)
            {
                var supplier = this.supplierService.GetByID(model.ID);
                supplier.Name = model.Name;
                this.supplierService.Save();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
