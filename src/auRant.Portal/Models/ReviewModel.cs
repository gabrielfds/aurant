using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using auRant.Core;
using auRant.Core.Entities;
using System.ComponentModel;

namespace auRant.Visual.Models
{
    public class ReviewModel
    {

        public ReviewModel()
        {

        }

        public ReviewModel(Review review)
        {
            this.ID = review.ID;
            this.ProductModel = new ProductModel(review.Product);
            this.IdOriginal = review.ID;
            this.ProductId = this.ProductModel.ID;
            this.ReviewText = review.ReviewText;
        }

        public ReviewModel(DraftReview draft, bool isDraft)
        {
            this.ID = draft.ID;
            this.ProductModel = new ProductModel(draft.Product);
            this.IdOriginal = draft.OriginReview != null ? draft.OriginReview.ID : 0;
            this.ProductId = this.ProductModel.ID;
            this.ReviewText = draft.ReviewText;
            this.IsDraft = isDraft;
        }

        public DraftReview CreateDraftReviewFromModel(Product product, Review origin)
        {
            return new DraftReview()
            {
                ReviewText = this.ReviewText,
                Product = product,
                OriginReview = origin
            };
        }

        public DraftReview PopularDraftReviewFromModel(DraftReview draft, Product product)
        {
            draft.Product = product;
            draft.ReviewText = this.ReviewText;
            return draft;
        }

        public int ID { get; set; }

        /// <summary>
        /// Used just when creating a new record
        /// </summary>
        [Required(ErrorMessage = Constants.REQUIRED_FIELD)]
        public int ProductId { get; set; }

        
        public ProductModel ProductModel { get; set; }

        [Required(ErrorMessage = Constants.REQUIRED_FIELD)]
        [AllowHtml]
        public string ReviewText { get; set; }

        [DisplayName("Este é um draft")]
        public bool IsDraft { get; set; }

        public int IdOriginal { get; set; }


    }
}