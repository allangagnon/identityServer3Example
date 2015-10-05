using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Thinktecture.IdentityModel.Mvc;

namespace ExampleMVC.Controllers
{

    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        // [ResourceAuthorize("Read", "ClaimDetails")]
        // [HandleForbidden]
        public ActionResult Claims()
        {
            return View((User as ClaimsPrincipal).Claims);
        }

        [HandleForbidden]
        public ActionResult UpdateClaims()
        {
            if (!HttpContext.CheckAccess("Write", "ClaimDetails", "some more data"))
            {
                // either 401 or 403 based on authentication state
                return this.AccessDenied();
            }

            ViewBag.Message = "Update your contact details!";

            return View();
        }
    }
}