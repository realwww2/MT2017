using System.Web;
using System.Web.Mvc;
using Paperless.Filters;
namespace Paperless
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new HandleErrorAttribute());
            filters.Add(new PaperlessExceptionFilter());
            filters.Add(new AuthorizeAttribute());
        }
    }
}