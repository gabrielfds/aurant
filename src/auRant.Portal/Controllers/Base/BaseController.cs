using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using auRant.Core.Entities;
using auRant.Services;
using auRant.Core.DataBase;

namespace auRant.Visual.Controllers.Base
{
    public class BaseController : Controller
    {
        protected List<Parameter> Parameter { get; private set; }
        protected ParameterService parameterService = null;

        public BaseController()
        {
            this.parameterService = new ParameterService(ContextFactory.GetContext(System.Web.HttpContext.Current));
            this.Parameter = this.parameterService.GetAll();
        }
    }
}
