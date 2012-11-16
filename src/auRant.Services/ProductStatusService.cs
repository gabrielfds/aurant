using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using auRant.Core.Entities;
using auRant.Services.Base;
using auRant.Core.DataBase;
using auRant.Core.DataBase.Repositories;

namespace auRant.Services
{
    public class ProductStatusService:BaseService<PublicationStatus>
    {
        PublicationStatusRepository productStatusRepository = null;
        public ProductStatusService(DatabaseContext context)
            :base(context)
        {
            this.productStatusRepository = new PublicationStatusRepository(context);
        }

        public IQueryable<PublicationStatus> GetAll()
        {
            return this.productStatusRepository.GetAll();
        }
    }
}
