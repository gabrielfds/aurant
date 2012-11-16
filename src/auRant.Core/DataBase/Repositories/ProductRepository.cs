using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using auRant.Core.Entities;
using auRant.Core.DataBase.Base;
using auRant.Core.Entities.Base;

namespace auRant.Core.DataBase.Repositories
{
    public class ProductRepository:BaseRepository<Product>, IPublishingRepository<Product>
    {
        PublicationStatusRepository publicationStatusRepository = null;
        PublicationStatus draftStatus = null;

        /// <summary>
        /// Receives and set the context for the repository
        /// </summary>
        /// <param name="context">The context</param>
        public ProductRepository(DatabaseContext context)
            :base(context)
        {
            this.publicationStatusRepository = new PublicationStatusRepository(context);
            this.draftStatus = this.publicationStatusRepository.GetByName(Constants.PublicationStatusName.DRAFT);
        }

        public List<Product> GetAll()
        {
            return this.context.Products.ToList();
        }

        public IQueryable<Product> GetAllPublishedWidhoutDraft()
        {
            IQueryable<int> publishedIds = (from d in this.context.DraftProducts.Where(d => d.OriginalProduct != null && d.PublicationStatus.Name == draftStatus.Name.ToUpper()) select d.OriginalProduct.ID);
            return this.context.Products.Where(r => !publishedIds.Contains(r.ID));
        }
    }
}
