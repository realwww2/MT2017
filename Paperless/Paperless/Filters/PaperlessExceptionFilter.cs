using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Paperless.Log;
namespace Paperless.Filters
{
    public class PaperlessExceptionFilter : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            Logger logger = new Logger();
            logger.LogError(filterContext);
            base.OnException(filterContext);
        }
    }
}