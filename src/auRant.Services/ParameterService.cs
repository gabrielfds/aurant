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
    public class ParameterService:BaseService<Parameter>
    {
        ParameterRepository parameterRepository = null;
        public ParameterService(DatabaseContext context)
            :base(context)
        {
            parameterRepository = new ParameterRepository(context);
        }

        public List<Parameter> GetAll()
        {
            return this.parameterRepository.GetAll();
        }
    }
}
