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

        /// <summary>
        /// The product price
        /// </summary>
        [Column("DPRO_PRICE")]
        public decimal Price { get; set; }


        /// <summary>
        /// The product image url
        /// </summary>
        [Column("DPRO_IMAGE_URL")]
        public string urlImage { get; set; }


      

        /// <summary>
        /// The product short description
        /// </summary>
        [Column("DPRO_DS_SHORT_DESCRIPTION")]
        public string ShortDescription { get; set; }

        /// <summary>
        /// The product full description
        /// </summary>
        [Column("DPRO_DS_FULL_DESCRIPTION")]
        public string FullDescription { get; set; }


        /// <summary>
        /// The product category
        /// </summary>
        [Column("PRCA_ID_CATEGORY")]
        public virtual ProductCategory Category { get; set; }

        /// <summary>
        /// The product this draft was made from
        /// </summary>
        [Column("PROD_ID_PRODUCT")]
        public virtual Product OriginalProduct { get; set; }

        [Column("SUPL_ID_SUPLIER")]
        /// <summary>
        /// The suplier's id that owns this product
        /// </summary>
        public virtual Supplier Supplier { get; set; }


        public void Publish(BasePublishableEntity draft, PublicationStatus status, Base.BaseEntity originalEntity = null)
        {
            if (((DraftProduct)draft).OriginalProduct == null)
            {
                ((DraftProduct)draft).OriginalProduct = new Product()
                {
                     Category = this.Category,
                      FullDescription = this.FullDescription,
                        Supplier = this.Supplier,
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
                original.Supplier = this.Supplier;
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
