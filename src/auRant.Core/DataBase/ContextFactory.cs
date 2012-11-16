using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace auRant.Core.DataBase
{
    public static class ContextFactory
    {
        private const string CONTEXT = "CONTEXT";
        private const string LOCK_CONTEXT = "LOCK_CONTEXT";

        public static DatabaseContext GetContext(System.Web.HttpContext context)
        {
            lock (LOCK_CONTEXT)
            {
                if (context.Cache[CONTEXT] == null)
                {
                    DatabaseContext auRantContext = new DatabaseContext();
                    context.Cache.Insert(CONTEXT, auRantContext,null, System.Web.Caching.Cache.NoAbsoluteExpiration, new TimeSpan(0, 10 ,0));
                    return auRantContext;
                }
                else
                {
                    return (DatabaseContext)context.Cache[CONTEXT];
                }
            }
        }
    }
}
