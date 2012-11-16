using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using auRant.Core.Entities;
using auRant.Core.Entities.Base;

namespace auRant.Core.DataBase.Repositories
{
    public interface IPublishingRepository<T>
    {
        IQueryable<T> GetAllPublishedWidhoutDraft();
        void Save();
        void Delete(int id);
    }
    
}
