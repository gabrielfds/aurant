using auRant.Core.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace auRant.Core.Entities
{
    /// <summary>
    /// The product class
    /// </summary>
    [Table("PRODUCT")]
    public class Product : BasePublishableEntity
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public Product()
        {
        }

        /// <summary>
        /// The product name
        /// </summary>
        [Column("PROD_NAME")]     
        public string Name { get; set; }       
       
        /// <summary>
        /// The product price
        /// </summary>
        [Column("PROD_PRICE")]
        public decimal Price { get; set; }

        /// <summary>
        /// The product image url
        /// </summary>
        [Column("PROD_IMAGE_URL")]
        public string urlImage { get; set; }

      

        /// <summary>
        /// The product short description
        /// </summary>
        [Column("PROD_DS_SHORT_DESCRIPTION")]
        public string ShortDescription { get; set; }

        /// <summary>
        /// The product full description
        /// </summary>
        [Column("PROD_DS_FULL_DESCRIPTION")]
        public string FullDescription { get; set; }

        /// <summary>
        /// The product category
        /// </summary>
        public virtual ProductCategory Category { get; set; }

        /// <summary>
        /// The artist's that owns this product
        /// </summary>
        public virtual Supplier Supplier { get; set; }

    }
}
