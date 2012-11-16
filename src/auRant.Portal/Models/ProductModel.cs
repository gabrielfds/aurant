﻿using System.Web;
using auRant.Core;
using auRant.Core.Entities;
using System.Web.Mvc;
namespace auRant.Visual.Models
{
    public class ProductModel
    {
        private DraftProduct r;
        private DraftProduct draftProduct;

        /// <summary>
        /// The product's ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// The product's name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The product category
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// The product category
        /// </summary>
        public string CategoryName { get; set; }

        /// <summary>
        /// The product's status
        /// </summary>
        public int StatusId { get; set; }


        /// <summary>
        /// The product's status description
        /// </summary>
        public string StatusName { get; set; }

        /// <summary>
        /// The product's price
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// The product's image
        /// </summary>
        public string urlImage { get; set; }

        /// <summary>
        /// The manufactor's Id for this product
        /// </summary>
        public int ManufactorId { get; set; }

        /// <summary>
        /// The manufactor's description for this product
        /// </summary>
        public string ManufactorName { get; set; }

        /// <summary>
        /// A short description for the product
        /// </summary>
        [AllowHtml]
        public string ShortDescription { get; set; }

        /// <summary>
        /// The full description for the product
        /// </summary>
        [AllowHtml]
        public string FullDescription { get; set; }


        public ProductCategory Category { get; set; }


        public Manufactor Manufactor { get; set; }


        public ProductModel()
        {

        }

        /// <summary>
        /// Receives a product and set each field in ProductAdministrationModel
        /// </summary>
        /// <param name="product"></param>
        public ProductModel(auRant.Core.Entities.Product product)
        {
            this.ID = product.ID;
            this.Name = product.Name;
            this.CategoryId = product.Category.ID;
            this.Price = product.Price;
            this.CategoryName = product.Category.Name;
            this.StatusId = product.PublicationStatus.ID;
            this.StatusName = product.PublicationStatus.Name;
            this.ManufactorId = product.Manufactor.ID;
            this.ManufactorName = product.Manufactor.Name;
            this.urlImage = string.Concat(urlFolderImage, product.urlImage);
            this.ShortDescription = product.ShortDescription;
            this.FullDescription = product.FullDescription;
        }

        public ProductModel(DraftProduct draft)
        {
            ID = draft.ID;
            CategoryId = draft.Category.ID;
            CategoryName = draft.Category.Name;
            FullDescription = draft.FullDescription;
            ManufactorName = draft.Manufactor.Name;
            ManufactorId = draft.Manufactor.ID;
            Name = draft.Name;
            Price = draft.Price;
            ShortDescription = draft.ShortDescription;
            StatusId = draft.PublicationStatus.ID;
            StatusName = draft.PublicationStatus.Name;
            urlImage = string.Concat(urlFolderImage, draft.urlImage);
            IsDraft = true;
            IdOriginal = draft.OriginalProduct != null ? draft.OriginalProduct.ID : 0;
        }

        public ProductModel(DraftProduct Draft, bool isDraft)
        {
            this.ID = Draft.ID;
            this.Name = Draft.Name;
            this.CategoryId = Draft.Category.ID;
            this.Price = Draft.Price;
            this.CategoryName = Draft.Category.Name;
            this.StatusId = Draft.PublicationStatus.ID;
            this.StatusName = Draft.PublicationStatus.Name;
            this.ManufactorId = Draft.Manufactor.ID;
            this.ManufactorName = Draft.Manufactor.Name;
            this.urlImage = string.Concat(urlFolderImage, Draft.urlImage);
            this.ShortDescription = Draft.ShortDescription;
            this.FullDescription = Draft.FullDescription;
            this.IsDraft = isDraft;
        }

        /// <summary>
        /// Transforms itself into a Product entity
        /// </summary>
        /// <returns></returns>
        public auRant.Core.Entities.Product CreateProduct(string urlImage, ProductCategory category, PublicationStatus productStatus, Manufactor manufactor)
        {
            return new auRant.Core.Entities.Product()
            {
                Name = this.Name,
                Category = category,
                PublicationStatus = productStatus,
                Price = this.Price,
                Manufactor = manufactor,
                urlImage = urlImage,
                ShortDescription = this.ShortDescription,
                FullDescription = this.FullDescription
            };
        }


        /// <summary>
        /// Update a product's fields with this fields values
        /// </summary>
        /// <returns></returns>
        public void UpdateProduct(auRant.Core.Entities.Product produtoEditavel, ProductCategory category, PublicationStatus productStatus, Manufactor manufactor)
        {
            produtoEditavel.Name = this.Name;
            produtoEditavel.Category = category;
            produtoEditavel.PublicationStatus = productStatus;
            produtoEditavel.Price = this.Price;
            produtoEditavel.Manufactor = manufactor;
            produtoEditavel.urlImage = this.urlImage;
            produtoEditavel.ShortDescription = this.ShortDescription;
            produtoEditavel.FullDescription = this.FullDescription;
        }

        /// <summary>
        /// Validates if this model is valid
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public bool isValid(HttpPostedFileBase image)
        {
            return image != null;
        }

        /// <summary>
        /// Returns the message when an image is not set for a product
        /// </summary>
        public string RequiredImageMessage { get { return "The image for the product is required"; } }


        public string urlFolderImage { get { return string.Concat(Constants.FILE_FOLDER_BASE, @"/Product/"); } }

        public bool IsDraft { get; set; }

        public int IdOriginal { get; set; }

        public DraftProduct CreateDraftReviewFromModel(ProductCategory category, Manufactor manufactor, Product origin)
        {
            return new DraftProduct()
            {
                Category = category,
                FullDescription  = this.FullDescription,
                Manufactor = manufactor,
                Name = this.Name,
                Price = this.Price,
                ShortDescription = this.ShortDescription,
                urlImage = this.urlImage,
                OriginalProduct = origin
            };
        }

        public DraftProduct PopularDraftReviewFromModel(DraftProduct draft, ProductCategory category, Manufactor manufactor, Product origin)
        {
            draft.OriginalProduct = origin;
            draft.Category = category;
            draft.Manufactor = manufactor;
            draft.Name = this.Name;
            draft.Price = this.Price;
            draft.ShortDescription = this.ShortDescription;
            draft.urlImage = this.urlImage;
            draft.FullDescription = this.FullDescription;
            return draft;
        }
    }
}