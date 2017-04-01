using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using Paperless.Models;

namespace Paperless.Controllers
{

    public class ErrorController : Controller
    {
        public ActionResult Index()
        {
            Exception e = new Exception("Invalid Controller or Action Name");
            HandleErrorInfo eInfo = new HandleErrorInfo(e, "Unknown", "Unknown");
            return View("Error", eInfo);
        }
    }
}
