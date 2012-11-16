using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using auRant.Services;
using auRant.Core.DataBase;
using auRant.Visual.Models;

namespace auRant.Visual.Areas.Product.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult Index()
        {
            ProductService productService = new ProductService(ContextFactory.GetContext(System.Web.HttpContext.Current));
            var model = new List<ProductModel>();
            productService.GetAll().ForEach(p => model.Add(new ProductModel(p)));
            return View(model);
        }

        public ActionResult Details()
        {
            ProductService productService = new ProductService(ContextFactory.GetContext(System.Web.HttpContext.Current));
            var model = new List<ProductModel>();
            productService.GetAll().ForEach(p => model.Add(new ProductModel(p)));
            return View(model);
        }
    }
}
