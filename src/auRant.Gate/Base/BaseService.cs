using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Publication.Core.DataBase;

namespace Publication.Services.Base
{
    public class BaseService
    {
        /// <summary>
        /// The internal context
        /// </summary>
        protected PortalContext context = null;

        /// <summary>
        /// Receives the context and sets to internal context property
        /// </summary>
        /// <param name="context"></param>
        public BaseService(PortalContext context)
        {
            this.context = context;
        }
    }
}
