using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using auRant.Services;
using auRant.Core.DataBase;
using auRant.Visual.Models;
using auRant.Core.Entities;
using auRant.Core.DataBase.Repositories;
using auRant.Core;

namespace auRant.Visual.Areas.Administration.Controllers
{
    public class ReviewController : Controller
    {
        PublishingService<Review, DraftReview, ReviewRepository> publishingService = null;
        ProductService productService = null;
        PublicationStatusRepository publicationStatusRepository = null;
        public ReviewController()
        {
            this.publishingService = new PublishingService<Review, DraftReview, ReviewRepository>(ContextFactory.GetContext(System.Web.HttpContext.Current));
            this.productService = new ProductService(ContextFactory.GetContext(System.Web.HttpContext.Current));
            this.publicationStatusRepository = new PublicationStatusRepository(ContextFactory.GetContext(System.Web.HttpContext.Current));
        }
        public ActionResult Index()
        {
            SetarViewBag();
            var model = new List<ReviewModel>();
            this.publishingService.GetAllPublishedWidhoutDraft().ToList().ForEach(r =>
            {
                model.Add(new ReviewModel()
                {
                    ID = r.ID,
                    ProductId = r.Product.ID,
                    ProductModel = new ProductModel(r.Product),
                    IdOriginal = r.ID,
                    ReviewText = r.ReviewText
                });
            });

            this.publishingService.GetAllDrafts().ToList().ForEach(d =>
            {
                model.Add(new ReviewModel()
                {
                    ID = d.ID,
                    ProductId = d.Product.ID,
                    ReviewText = d.ReviewText,
                    IsDraft = true,
                    ProductModel = new ProductModel(d.Product),
                    IdOriginal = d.OriginReview != null ? d.OriginReview.ID : 0
                });
            });
            return View(model);
        }

        private void SetarViewBag(int id = -1)
        {

            var productList = new SelectList(this.productService.GetAll(), "ID", "Name");
            var enumerator = productList.GetEnumerator();
            if (id > -1)
            {
                while (enumerator.MoveNext())
                {
                    if (int.Parse(enumerator.Current.Value) == id)
                    {
                        enumerator.Current.Selected = true;
                        break;
                    }
                }
            }
            ViewBag.ProductList = productList;
        }

        public ActionResult Create()
        {
            SetarViewBag();
            return View();
        }

        [HttpPost]
        public ActionResult Create(ReviewModel model)
        {
            if (ModelState.IsValid)
            {
                PublicationStatus statusRascunho = this.publicationStatusRepository.GetByName(Constants.PublicationStatusName.DRAFT);
                var draft = model.CreateDraftReviewFromModel(this.productService.GetByID(model.ProductId), null);
                this.publishingService.CreateDraft(draft,draft.OriginReview);
                return RedirectToAction("Index");
            }
            SetarViewBag();
            return View();
        }

        public ActionResult Edit(int id, bool isDraft)
        {
            if (!isDraft)
            {
                ReviewModel model = new ReviewModel(this.publishingService.GetByID(id));
                SetarViewBag(model.ProductId);
                return View(model);
            }
            else
            {
                ReviewModel model = new ReviewModel(this.publishingService.GetDraftById(id),isDraft);
                SetarViewBag(model.ProductId);
                return View(model);
            }
        }

        [HttpPost]
        public ActionResult Edit(ReviewModel model)
        {
            if (ModelState.IsValid)
            {
                if (!model.IsDraft)
                {
                    var produto = this.productService.GetByID(model.ProductId);
                    Review origin = this.publishingService.GetByID(model.ID);
                    DraftReview d = model.CreateDraftReviewFromModel(this.productService.GetByID(model.ProductId), origin);
                    this.publishingService.CreateDraft(d,origin);
                }
                else
                {
                    var produto = this.productService.GetByID(model.ID);
                    Review origin = this.publishingService.GetByID(model.IdOriginal);
                    this.publishingService.UpdateDraft(model.PopularDraftReviewFromModel(this.publishingService.GetDraftById(model.ID), this.productService.GetByID(model.ProductId)));
                }
            }
            SetarViewBag();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            this.publishingService.Delete(id);
            SetarViewBag();
            return View("Index");
        }

        public ActionResult Publish(int id)
        {
            DraftReview d = this.publishingService.GetAllDrafts().Where(dr => dr.ID == id).FirstOrDefault();
            this.publishingService.Publish(d, d.Publish,d.OriginReview);
            return RedirectToAction("Index");
        }


    }
}
