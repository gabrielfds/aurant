using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using auRant.Core.Entities;
using auRant.Core.DataBase.Base;
using auRant.Core.Entities.Base;

namespace auRant.Core.DataBase.Repositories
{

    public class DraftRepository<T> : BaseRepository<T> where T:BasePublishableEntity
    {
        PublicationStatusRepository publicationStatusRepository = null;
        PublicationStatus draftStatus = null;
        
        public DraftRepository(DatabaseContext context)
            : base(context)
        {
            this.publicationStatusRepository = new PublicationStatusRepository(context);
            this.draftStatus = this.publicationStatusRepository.GetByName(Constants.PublicationStatusName.DRAFT);
        }

        public IQueryable<T> GetAll()
        {
            return this.context.Set<T>();
        }

        public IQueryable<T> GetDrafts()
        {
            return this.context.Set<T>().Where(dr =>  dr.PublicationStatus.Name.ToUpper() == draftStatus.Name.ToUpper());
        }
    }
}
