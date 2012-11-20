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
    public class SupplierService:BaseService<Supplier>
    {
        supplierRepository supplierRepository = null;
        public SupplierService(DatabaseContext context)
            :base(context)
        {
            this.supplierRepository = new supplierRepository(context);
        }

        public List<Supplier> GetAll()
        {
            return this.supplierRepository.GetAll();
        }
    }
}
