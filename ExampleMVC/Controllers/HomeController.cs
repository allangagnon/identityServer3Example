using ExampleShared;
using System;
using System.IO;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ExampleMVC.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public async Task<ActionResult> Directory()
        {
            var response = await base.GetTokenAsync();
            var result = await base.CallApi(response.AccessToken, Path.Combine(Constants.APIClientUri, "api/People"));

            ViewBag.results = result;
            return View("ShowResults");
        }

        [Authorize]
        public async Task<ActionResult> UserCred()
        {
            var user = User as ClaimsPrincipal;
            var token = user.FindFirst("access_token").Value;
            try
            {
                ViewBag.results = await base.CallApi(token, Path.Combine(Constants.APIClientUri, "api/identity"));
            }
            catch (Exception ex)
            {

            }

            return View("ShowResults");
        }

        [Authorize]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}