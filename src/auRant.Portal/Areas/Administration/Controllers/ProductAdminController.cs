using System.Collections.Generic;
using System.Web;
using System.Linq;
using System.Web.Mvc;
using auRant.Services;
using auRant.Core.DataBase;
using auRant.Visual.Areas.Administration.Models;
using auRant.Visual.Models;
using auRant.Core.Entities;
using auRant.Core.DataBase.Repositories;

namespace auRant.Visual.Areas.Administration.Controllers
{
    public class ProductAdminController : Controller
    {
        PublishingService<auRant.Core.Entities.Product, DraftProduct, ProductRepository> publishingService = null;
        ProductCategoryService productCategoryService = null;
        ProductStatusService productStatusService = null;
        ManufactorService manufactorService = null;
        HelperService helperService = null;
        SelectList categories = null;
        SelectList productStatus = null;
        SelectList manufactor = null;

        public ProductAdminController()
        {
            this.publishingService = new PublishingService<auRant.Core.Entities.Product, DraftProduct, ProductRepository>(ContextFactory.GetContext(System.Web.HttpContext.Current));
            this.productCategoryService = new ProductCategoryService(ContextFactory.GetContext(System.Web.HttpContext.Current));
            this.productStatusService = new ProductStatusService(ContextFactory.GetContext(System.Web.HttpContext.Current));
            this.manufactorService = new ManufactorService(ContextFactory.GetContext(System.Web.HttpContext.Current));
            this.helperService = new HelperService();
        }

        public ActionResult Index()
        {
            var model = new List<ProductModel>();
            try
            {
                this.publishingService.GetAllPublishedWidhoutDraft().ToList().ForEach(r =>
                {
                    model.Add(new ProductModel(r));
                });

                this.publishingService.GetAllDrafts().ToList().ForEach(r =>
                {
                    model.Add(new ProductModel(r));
                });
              
            }
            catch (System.Exception e)
            {
            }
            return View(model);
            
        }

        public ActionResult Create()
        {
            SetarViewBags();
            return View();
        }

        private void SetarViewBags()
        {
            categories = new SelectList(this.productCategoryService.GetAll(), "ID", "Name");
            productStatus = new SelectList(this.productStatusService.GetAll(), "ID", "Name");
            manufactor = new SelectList(this.manufactorService.GetAll(), "ID", "Name");

            ViewBag.Categories = categories;
            ViewBag.ProductStatus = productStatus;
            ViewBag.Manufactor = manufactor;
        }

        [HttpPost]
        public ActionResult Create(ProductModel model, HttpPostedFileBase FileImage)
        {
            if (!model.isValid(FileImage))
            {
                ModelState.AddModelError("urlImage", model.RequiredImageMessage);
            }
            if (ModelState.IsValid)
            {
                this.helperService.SaveFile(FileImage, model.urlFolderImage);
                model.urlImage = FileImage.FileName;
                this.publishingService.CreateDraft(model.CreateDraftReviewFromModel(this.productCategoryService.GetByID(model.CategoryId),
                    this.manufactorService.GetByID(model.ManufactorId), null), null);

                return RedirectToAction("Index");
            }
            SetarViewBags();
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id, bool isDraft)
        {
            if (!isDraft)
            {
                ProductModel model = new ProductModel(this.publishingService.GetByID(id));
                SetarViewBags();
                return View(model);
            }
            else
            {
                ProductModel model = new ProductModel(this.publishingService.GetDraftById(id), isDraft);
                SetarViewBags();
                return View(model);
            }
        }

        [HttpPost]
        public ActionResult Edit(ProductModel model, HttpPostedFileBase ImageFile)
        {
            if (ModelState.IsValid)
            {
                ProductCategory category = this.productCategoryService.GetByID(model.CategoryId);
                Manufactor manufactor = this.manufactorService.GetByID(model.ManufactorId);
                var produto = this.publishingService.GetByID(model.ID);
                if (!model.IsDraft)
                {
                    if (ImageFile == null && produto != null)
                        model.urlImage = produto.urlImage;
                    else
                        model.urlImage = ImageFile.FileName;

                    DraftProduct d = model.CreateDraftReviewFromModel(category, manufactor, produto);
                    this.publishingService.CreateDraft(d, produto);
                }
                else
                {
                    if (ImageFile == null && produto != null)
                        model.urlImage = produto.urlImage;
                    else
                        model.urlImage = ImageFile.FileName;

                    var draft = this.publishingService.GetDraftById(model.ID);
                    this.publishingService.UpdateDraft(model.PopularDraftReviewFromModel(draft, category, manufactor, draft.OriginalProduct)); ;
                }
            }
            SetarViewBags();
            return RedirectToAction("Index");
        }

        public ActionResult Publish(int id)
        {
            DraftProduct d = this.publishingService.GetAllDrafts().Where(dr => dr.ID == id).FirstOrDefault();
            this.publishingService.Publish(d, d.Publish, d.OriginalProduct);
            return RedirectToAction("Index");
        }
    }
}
