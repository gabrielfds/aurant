using System.Web.Mvc;

namespace auRant.Visual.Areas.Product
{
    public class ProductAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Product";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                 "Default_product_inside", // Route name
                 "Product/Details/{id}", // URL with parameters
                 new { controller = "Product", action = "Details", id = UrlParameter.Optional },
                 new[] { "auRant.Visual.Areas.Product.Controllers" } // Parameter defaults
             );

            context.MapRoute(
                "Product_default",
                "Product/{controller}/{action}/{id}",
                new {controller="Product", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
