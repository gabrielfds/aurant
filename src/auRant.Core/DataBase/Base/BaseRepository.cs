using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using auRant.Core.Entities.Base;
using System.Data.Entity;
using System.Linq.Expressions;

namespace auRant.Core.DataBase.Base
{
    public class BaseRepository<T> where T: BaseEntity
    {
        /// <summary>
        /// The context for the repository
        /// </summary>
        protected DatabaseContext context = null;

         /// <summary>
        /// Receives and set the context for the repository
        /// </summary>
        /// <param name="context">The context</param>
        public BaseRepository(DatabaseContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Get an element by its ID
        /// </summary>
        /// <returns>a T element</returns>
        public T GetById(int id)
        {
            return this.context.Set<T>().Where(t => t.ID == id).FirstOrDefault();
        }

        /// <summary>
        /// Creates a T element
        /// </summary>
        /// <param name="entity">The entity to be created</param>
        /// <returns>T</returns>
        public virtual T Create(T entity)
        {
            return this.context.Set<T>().Add(entity);
        }

        /// <summary>
        /// Save the changes to the database
        /// </summary>
        public void Save()
        {
            this.context.SaveChanges();
        }

        /// <summary>
        /// Deletes a entity from the context that has the id equals to Key
        /// </summary>
        /// <param name="Key">The key for the key being deleted</param>
        public void Delete(int Key)
        {
            T toDelete = this.context.Set<T>().Where(e => e.ID == Key).FirstOrDefault();
            if (toDelete != null)
            {
                this.context.Set<T>().Remove(toDelete);
            }
        }
    }
}
