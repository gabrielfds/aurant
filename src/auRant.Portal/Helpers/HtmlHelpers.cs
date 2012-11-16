using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace auRant.Visual.Helpers
{
    public static class HtmlHelpers
    {
        public static MvcHtmlString Img(this HtmlHelper helper, string text)
        {
            string ret = string.Format("<img src=\"{0}\"/>", text);
            return new MvcHtmlString(ret);
        }
    }
}