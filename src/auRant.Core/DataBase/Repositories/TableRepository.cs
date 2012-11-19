using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using auRant.Core.Entities;
using auRant.Core.DataBase.Base;

namespace auRant.Core.DataBase.Repositories
{
    public class TableRepository:BaseRepository<Table>, IPublishingRepository<Table>
    {
        PublicationStatusRepository publicationStatusRepository = null;
        PublicationStatus draftStatus = null;

        public TableRepository(DatabaseContext context)
            : base(context)
        {
            this.publicationStatusRepository = new PublicationStatusRepository(context);
            this.draftStatus = this.publicationStatusRepository.GetByName(Constants.PublicationStatusName.DRAFT);
        }

        public List<Table> GetAll()
        {
            return this.context.Tables.ToList();
        }

        public IQueryable<Table> GetAllPublishedWidhoutDraft()
        {
            IQueryable<int> publishedIds = (from d in this.context.DraftTables.Where(d => d.OriginalTable != null && d.PublicationStatus.Name == draftStatus.Name.ToUpper()) select d.OriginalTable.ID);
            return this.context.Tables.Where(r => !publishedIds.Contains(r.ID));
        }

        public IQueryable<Table> GetTableByCapacity(int intendedCapacity)
        {
            return this.context.Tables.Where(r => r.Capacity == intendedCapacity);
        }
    }
}
