using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using Paperless.Models;
using Paperless.Bussiness;

namespace Paperless.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Login()
        {
            ViewBag.Message = "Login";

            return View();
        }
         [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model,string returnUrl)
        {
            if(ModelState.IsValid)
            {
                IUserService um = BussinessFactory.Instance.userService;
                User user;
                if (um.Login(model.UserName, model.Password, out user))
                {
                    //FormsAuthentication.SetAuthCookie(model.UserName, true);
                    Session["User"] = user;
                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        switch (user.userType)
                        {
                            case UserType.New:
                                return RedirectToAction("NewUser", "Request");
                            case UserType.NoCourseFee:
                                return RedirectToAction("NoCourseFee", "Request");
                            case UserType.CourseFee:
                                return RedirectToAction("CourseFee", "Request");
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("", "The user name or password provided is incorrect.");
                }
            }
             //redisplay form
            return View(model);
        }

      
    }
}
