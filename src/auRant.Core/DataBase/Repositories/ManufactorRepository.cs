using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using auRant.Core.Entities;
using auRant.Core.DataBase.Base;

namespace auRant.Core.DataBase.Repositories
{
    public class ManufactorRepository:BaseRepository<Manufactor>
    {
        public ManufactorRepository(DatabaseContext context)
            :base(context)
        {
        }

        public List<Manufactor> GetAll()
        {
            return this.context.Manufactors.ToList();
        }
    }
}
