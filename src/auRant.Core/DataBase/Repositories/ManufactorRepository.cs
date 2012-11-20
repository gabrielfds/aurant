using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using auRant.Core.Entities;
using auRant.Core.DataBase.Base;

namespace auRant.Core.DataBase.Repositories
{
    public class supplierRepository:BaseRepository<Supplier>
    {
        public supplierRepository(DatabaseContext context)
            :base(context)
        {
        }

        public List<Supplier> GetAll()
        {
            return this.context.Supliers.ToList();
        }
    }
}
