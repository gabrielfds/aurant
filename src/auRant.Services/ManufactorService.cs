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
    public class ManufactorService:BaseService<Manufactor>
    {
        ManufactorRepository manufactorRepository = null;
        public ManufactorService(DatabaseContext context)
            :base(context)
        {
            this.manufactorRepository = new ManufactorRepository(context);
        }

        public List<Manufactor> GetAll()
        {
            return this.manufactorRepository.GetAll();
        }
    }
}
