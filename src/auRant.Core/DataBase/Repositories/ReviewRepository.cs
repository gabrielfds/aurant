using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using auRant.Core.Entities;
using auRant.Core.DataBase.Base;
using auRant.Core.Entities.Base;

namespace auRant.Core.DataBase.Repositories
{
    public class ReviewRepository : BaseRepository<Review>, IPublishingRepository<Review>
    {
        PublicationStatusRepository publicationStatusRepository = null;
        PublicationStatus draftStatus = null;

        public ReviewRepository(DatabaseContext context)
            : base(context)
        {
            this.publicationStatusRepository = new PublicationStatusRepository(context);
            this.draftStatus = this.publicationStatusRepository.GetByName(Constants.PublicationStatusName.DRAFT);
        }

        public IQueryable<Review> GetAllPublishedWidhoutDraft()
        {
            PublicationStatusRepository productStatusRepository = new PublicationStatusRepository(this.context);
            IQueryable<int> publishedIds = (from d in this.context.DraftReviews.Where(d => d.OriginReview != null && d.PublicationStatus.Name == draftStatus.Name.ToUpper()) select d.OriginReview.ID);
            return this.context.Reviews.Where(r => !publishedIds.Contains(r.ID));
        }
    }
}
