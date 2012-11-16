using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using auRant.Core.Entities;
using auRant.Core.DataBase.Base;

namespace auRant.Core.DataBase.Repositories
{
    public class PublicationStatusRepository : BaseRepository<PublicationStatus>
    {
        public PublicationStatusRepository(DatabaseContext context)
            :base(context)
        {
        }


        public IQueryable<PublicationStatus> GetAll()
        {
            return this.context.PulicationStatus;
        }

        public PublicationStatus GetByName(string name)
        {
            return this.context.PulicationStatus.Where(s => s.Name.ToUpper() == name.ToUpper()).FirstOrDefault();
        }
    }
}
