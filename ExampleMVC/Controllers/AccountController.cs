using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExampleMVC.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        [Authorize]
        public ActionResult Login()
        {
            return Redirect("/");
        }

        public ActionResult Logout()
        {
            Request.GetOwinContext().Authentication.SignOut();
            return Redirect("/");
        }
    }
}