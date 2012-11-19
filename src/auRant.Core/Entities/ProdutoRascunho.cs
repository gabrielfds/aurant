using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using auRant.Core.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace auRant.Core.Entities
{
    [Table("PRODUTO")]
    public class ProdutoRascunho : BasePublishableEntity, IPublishable
    {
        public ProdutoRascunho()
        {

        }
        [Column("NM_PROD")]
        /// <summary>
        /// O nome do produto
        /// </summary>
        public string Name { get; set; }

        [Column("ID_CATE")]
        /// <summary>
        /// A categoria do produto
        /// </summary>
        public virtual ProductCategory CategoriaDoProduto { get; set; }

        /// <summary>
        /// O id do produto que originou este rascunho
        /// </summary>
        [Column("ID_PROD")]
        public virtual Produto ProdutoOriginal { get; set; }

        /// <summary>
        /// O preço do produto
        /// </summary>
        [Column("PRECO_PROD")]
        public decimal Price { get; set; }

        /// <summary>
        /// a imagem do produto
        /// </summary>
        [Column("IMAGE_PROD")]
        public string urlImage { get; set; }

        /// <summary>
        /// O id do fornecedor do produto
        /// </summary>
        [Column("ID_FORN")]
        /// <summary>
        /// The artist's that owns this product
        /// </summary>
        public virtual Fornecedor Fornecedor { get; set; }

        /// <summary>
        /// Uma breve descrição do produto
        /// </summary>
        [Column("DS_CURTA_PROD")]
        public string ShortDescription { get; set; }

        /// <summary>
        /// Uma descrição mais completa do produto
        /// </summary>
        [Column("DS_LONGA_PROD")]
        public string FullDescription { get; set; }

        public void Publish(BasePublishableEntity draft, PublicationStatus status, Base.BaseEntity originalEntity = null)
        {
            if (((ProdutoRascunho)draft).ProdutoOriginal == null)
            {
                ((ProdutoRascunho)draft).ProdutoOriginal = new Produto()
                {
                     Category = this.CategoriaDoProduto,
                      FullDescription = this.FullDescription,
                       Manufactor = this.Fornecedor,
                        Name = this.Name, 
                         Price = this.Price,
                          ShortDescription = this.ShortDescription,
                           urlImage = this.urlImage,
                            PublicationStatus = status
                };
            }
            else
            {
                Produto original = (Produto)originalEntity;
                original.PublicationStatus = new Entities.PublicationStatus();
                original.Manufactor = this.Fornecedor;
                original.FullDescription = this.FullDescription;
                original.Category = this.CategoriaDoProduto;
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
                this.ProdutoOriginal = (Produto)original;
            }
        }
    }
}
