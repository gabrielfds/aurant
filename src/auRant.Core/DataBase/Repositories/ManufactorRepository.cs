using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using auRant.Core.Entities;
using auRant.Core.DataBase.Base;

namespace auRant.Core.DataBase.Repositories
{
    public class ManufactorRepository:BaseRepository<Suplier>
    {
        public ManufactorRepository(DatabaseContext context)
            :base(context)
        {
        }

        public List<Suplier> GetAll()
        {
            return this.context.Manufactors.ToList();
        }
    }
}
