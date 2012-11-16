using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using auRant.Core.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace auRant.Core.Entities
{
    [Table("PRODUCT")]
    /// <summary>
    /// The product class
    /// </summary>
    public class Product : BasePublishableEntity
    {
        public Product()
        {
        }

        /// <summary>
        /// The product name
        /// </summary>
        [Column("PROD_NAME")]     
        public string Name { get; set; }

        /// <summary>
        /// The product category
        /// </summary>
        [Column("PRCA_SQ_CATEGORY")]
        public virtual ProductCategory Category { get; set; }
       
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
        /// The artist's that owns this product
        /// </summary>
        [Column("MANU_SQ_MANUFACTOR")]
        public virtual Manufactor Manufactor { get; set; }

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

    }
}
