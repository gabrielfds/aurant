using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using auRant.Core.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace auRant.Core.Entities
{
    [Table("DRAFT_PRODUCT")]
    public class DraftProduct : BasePublishableEntity, IPublishable
    {
        public DraftProduct()
        {

        }
        [Column("DPRO_NAME")]
        /// <summary>
        /// The product name
        /// </summary>
        public string Name { get; set; }

        [Column("PRCA_SQ_CATEGORY")]
        /// <summary>
        /// The product category
        /// </summary>
        public virtual ProductCategory Category { get; set; }

        [Column("PROD_SQ_PRODUCT")]
        public virtual Product OriginalProduct { get; set; }

        [Column("DPRO_PRICE")]
        public decimal Price { get; set; }

        [Column("DPRO_IMAGE_URL")]
        public string urlImage { get; set; }

        [Column("MANU_SQ_MANUFACTOR")]
        /// <summary>
        /// The artist's that owns this product
        /// </summary>
        public virtual Manufactor Manufactor { get; set; }

        public string ShortDescription { get; set; }

        public string FullDescription { get; set; }

        public void Publish(BasePublishableEntity draft, PublicationStatus status, Base.BaseEntity originalEntity = null)
        {
            if (((DraftProduct)draft).OriginalProduct == null)
            {
                ((DraftProduct)draft).OriginalProduct = new Product()
                {
                     Category = this.Category,
                      FullDescription = this.FullDescription,
                       Manufactor = this.Manufactor,
                        Name = this.Name, 
                         Price = this.Price,
                          ShortDescription = this.ShortDescription,
                           urlImage = this.urlImage,
                            PublicationStatus = status
                };
            }
            else
            {
                Product original = (Product)originalEntity;
                original.PublicationStatus = new Entities.PublicationStatus();
                original.Manufactor = this.Manufactor;
                original.FullDescription = this.FullDescription;
                original.Category = this.Category;
                original.Name = this.Name;
                original.Price = this.Price;
                original.ShortDescription = this.ShortDescription;
                original.urlImage = this.urlImage;
                original.PublicationStatus = status;
            }
        }

        public void CreateOriginal(Base.BaseEntity original)
        {
            if (original != null)
            {
                this.OriginalProduct = (Product)original;
            }
        }
    }
}
