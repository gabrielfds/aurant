using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using auRant.Core.Entities;
using auRant.Core.DataBase.Base;

namespace auRant.Core.DataBase.Repositories
{
    public class ParameterRepository:BaseRepository<Parameter>
    {
        public ParameterRepository(DatabaseContext context)
            :base(context)
        {

        }

        public List<Parameter> GetAll()
        {
            return context.Parmeters.ToList();
        }
    }
}
