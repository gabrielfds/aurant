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
    public class ManufactorController : Controller
    {
        ManufactorService manufactorService = null;

        public ManufactorController()
        {
            this.manufactorService = new ManufactorService(ContextFactory.GetContext(System.Web.HttpContext.Current));
        }
        public ActionResult Index()
        {
            var model = new List<ManufactorModel>();
            this.manufactorService.GetAll().ForEach(m => model.Add(new ManufactorModel(m)));
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ManufactorModel model)
        {
            if (ModelState.IsValid)
            {
                this.manufactorService.Create(model.CreateManufactorFromModel());
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(ManufactorModel model)
        {
            if (ModelState.IsValid)
            {
                var manufactor = this.manufactorService.GetByID(model.ID);
                manufactor.Name = model.Name;
                this.manufactorService.Save();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
