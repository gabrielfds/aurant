using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using auRant.Services;
using auRant.Visual.Models;
using auRant.Core.DataBase;
using auRant.Core.Entities;
using auRant.Core.DataBase.Repositories;

namespace auRant.Visual.Controllers
{
    public class CarrosselController : Controller
    {
        ProductService productService = null;
        PublishingService<Review,DraftReview,ReviewRepository> reviewService = null;

       
        public CarrosselController()
        {
            this.productService = new ProductService(ContextFactory.GetContext(System.Web.HttpContext.Current));
            this.reviewService = new PublishingService<Review, DraftReview, ReviewRepository>(ContextFactory.GetContext(System.Web.HttpContext.Current));
        }
        public ActionResult CarrosselTopo()
        {
            var model = new List<ProductModel>();
            this.productService.GetAll().ForEach(p => model.Add(new ProductModel(p)));
            return View(model);
        }


        public ActionResult CarrosselReviews()
        {
            var model = new List<ReviewModel>();
            var lista = this.reviewService.GetAllPublishedWidhoutDraft().ToList();
            
            lista.ForEach(r=>model.Add(new ReviewModel(r)));

            List<List<ReviewModel>> modelFinal = new List<List<ReviewModel>>();

            List<ReviewModel> listBag = new List<ReviewModel>();
            int qtdInList = 3;
            foreach (var item in model)
            {
                listBag.Add(item);
                if (listBag.Count == qtdInList)
                {
                    modelFinal.Add(listBag);
                    listBag = new List<ReviewModel>();
                }
                if (model.IndexOf(item) == model.Count - 1 && listBag.Count > 0)
                {
                    modelFinal.Add(listBag);
                }
            }
            return View(modelFinal);
        }

        public ActionResult CarrosselMiddle()
        {
            var model = new List<ProductModel>();
            this.productService.GetAll().Take(6).ToList().ForEach(r => model.Add(new ProductModel(r)));
            return View(model);
        }

        public ActionResult Index()
        {
            return View();
        }

    }
}
