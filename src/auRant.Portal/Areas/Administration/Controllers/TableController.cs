using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using auRant.Core.Entities;
using auRant.Services;
using auRant.Core.DataBase.Repositories;
using auRant.Core.DataBase;
using auRant.Visual.Areas.Administration.Models;
using auRant.Visual.Models;

namespace auRant.Visual.Areas.Administration.Controllers
{
    public class TableController : Controller
    {
        PublishingService<Table, DraftTable, TableRepository> publishingService = null;
        ProductStatusService productStatusService = null;
        HelperService helperService = null;

        public TableController()
        {
            this.publishingService = new PublishingService<Table, DraftTable, TableRepository>(ContextFactory.GetContext(System.Web.HttpContext.Current));
            this.productStatusService = new ProductStatusService(ContextFactory.GetContext(System.Web.HttpContext.Current));
            this.helperService = new HelperService();
        }
        public ActionResult Index()
        {
            var model = new List<TableModel>();
            this.publishingService.GetAllDrafts().ToList().ForEach(t => model.Add(new TableModel(t)));
            this.publishingService.GetAllPublishedWidhoutDraft().ToList().ForEach(t => model.Add(new TableModel(t)));
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(TableModel model)
        {
            if (ModelState.IsValid)
            {
                this.publishingService.CreateDraft(model.CreateDraftFromModel(model), null);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Edit(int id,bool isDraft)
        {
            if (isDraft)
            {
                return View(new TableModel(this.publishingService.GetDraftById(id)));
            }
            else
            {
                return View(new TableModel(this.publishingService.GetByID(id)));
            }

        }

        [HttpPost]
        public ActionResult Edit(TableModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.IsDraft)
                {
                    var draft = this.publishingService.GetDraftById(model.ID);
                    this.publishingService.UpdateDraft(model.UpdateDraftFromModel(draft));
                }
                else
                {
                    var table = this.publishingService.GetByID(model.ID);
                    this.publishingService.CreateDraft(model.UpdateDraftFromModel(new DraftTable()), table);
                }
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Publish(int id)
        {
            var d = this.publishingService.GetDraftById(id);
            this.publishingService.Publish(d, d.Publish, d.OriginalTable);
            return RedirectToAction("Index");
        }
    }
}
