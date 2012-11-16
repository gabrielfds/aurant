using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using auRant.Core.Entities.Base;

namespace auRant.Core.Entities
{

    [Table("DRAFT_REVIEW")]
    public class DraftReview : BasePublishableEntity, IPublishable
    {
        public DraftReview()
        {

        }
        [Column("PROD_SQ_PRODUCT")]
        public virtual Product Product { get; set; }

        [Column("DRAF_TX_REVIEW")]
        public string ReviewText { get; set; }

        [Column("REVI_SQ_REVIEW")]
        public virtual Review OriginReview { get; set; }




        public void Publish(BasePublishableEntity draft, PublicationStatus status, BaseEntity originalEntity = null)
        {
            if (((DraftReview)draft).OriginReview == null)
            {
                ((DraftReview)draft).OriginReview = new Review()
                {
                    Product = this.Product,
                    PublicationStatus = status,
                    ReviewText = this.ReviewText
                };
            }
            else
            {
                Review original = (Review)originalEntity;
                original.PublicationStatus = new Entities.PublicationStatus();
                original.PublicationStatus = status;
                original.Product = this.Product;
                original.ReviewText = this.ReviewText;
            }
        }

        public void CreateOriginal(BaseEntity original)
        {
            if (original != null)
            {
                this.OriginReview = (Review)original;
            }
        }
    }
}
