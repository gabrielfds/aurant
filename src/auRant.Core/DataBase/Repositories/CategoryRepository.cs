using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using auRant.Core.Entities;
using auRant.Core.DataBase.Base;

namespace auRant.Core.DataBase.Repositories
{
    public class CategoryRepository:BaseRepository<ProductCategory>
    {

        /// <summary>
        /// The DbContext for the repository
        /// </summary>
        DatabaseContext context = null;

        /// <summary>
        /// Receives and set the context for the repository
        /// </summary>
        /// <param name="context">The context</param>
        /// 
        public CategoryRepository(DatabaseContext context)
            :base(context)
        {
            this.context = context;
        }


        public List<ProductCategory> GetAll()
        {
            return this.context.Categories.ToList();
        }
    }
}
