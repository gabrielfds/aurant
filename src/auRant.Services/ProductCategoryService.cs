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
    public class ProductCategoryService:BaseService<ProductCategory>
    {
        CategoryRepository categoryRepository = null;
        public ProductCategoryService(DatabaseContext context)
            :base(context)
        {
            this.categoryRepository = new CategoryRepository(context);
        }

        public List<ProductCategory> GetAll()
        {
            return this.categoryRepository.GetAll();
        }
    }
}
