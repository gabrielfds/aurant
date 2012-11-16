using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using auRant.Services.Base;
using auRant.Core.Entities;
using auRant.Core.DataBase;
using auRant.Core.DataBase.Repositories;

namespace auRant.Services
{
    public class ProductService : BaseService<Product>
    {
        ProductRepository productRepository = null;
        public ProductService(DatabaseContext context)
            :base(context)
        {
            this.productRepository = new ProductRepository(context);
        }

        public List<Product> GetAll()
        {
            return this.productRepository.GetAll();
        }
        public void Update(Product product)
        {
            this.Save();
        }
    }
}
