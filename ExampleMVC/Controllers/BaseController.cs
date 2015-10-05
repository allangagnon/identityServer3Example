using ExampleShared;
using IdentityModel.Client;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;
using System.Security.Claims;
using System;

namespace ExampleMVC.Controllers
{
    public class BaseController : Controller
    {
        protected async Task<TokenResponse> GetTokenAsync()
        {
            string _url = Constants.IdentityServerUri + "/connect/token";
            var client = new TokenClient(
                _url,
                Constants.APIClient,
                Constants.IdentitySecret);

            return await client.RequestClientCredentialsAsync("apiAccess");
        }


        protected async Task<string> CallApi(string token, string url)
        {
            var client = new HttpClient();
            client.SetBearerToken(token);

            var json = await client.GetStringAsync(url);
            return JArray.Parse(json).ToString();
        }

    }
}