using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using auRant.Core.DataBase;
using auRant.Core.Entities;
using auRant.Core.DataBase.Base;
using auRant.Core.Entities.Base;

namespace auRant.Services.Base
{
    public class BaseService<T> where T: BaseEntity
    {
        /// <summary>
        /// The internal context
        /// </summary>
        protected DatabaseContext context = null;

        private BaseRepository<T> baseRepository = null;

        /// <summary>
        /// Receives the context and sets to internal context property
        /// </summary>
        /// <param name="context"></param>
        public BaseService(DatabaseContext context)
        {
            this.context = context;
            this.baseRepository = new BaseRepository<T>(this.context);
        }

        public T GetByID(int id)
        {
            return this.baseRepository.GetById(id);
        }

        public void Save()
        {
            this.baseRepository.Save();
        }

        public virtual T Create(T entity)
        {
            T retorno = this.baseRepository.Create(entity);
            this.baseRepository.Save();
            return retorno;
        }
    }
}
