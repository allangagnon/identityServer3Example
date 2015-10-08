using ExampleShared;
using IdentityServer3.AccessTokenValidation;
using Owin;
using System.Web.Http;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Linq;
using Microsoft.Owin.Cors;

namespace ExampleAPI
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
           
            // token validation
            app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions
            {
                Authority = Constants.IdentityServerUri,
                RequiredScopes = new[] { "apiAccess" }
            });

            // add app local claims per request
            app.UseClaimsTransformation(incoming =>
            {
                // either add claims to incoming, or create new principal
                var appPrincipal = new ClaimsPrincipal(incoming);
                incoming.Identities.First().AddClaim(new Claim("appSpecific", "some_value"));

                return Task.FromResult(appPrincipal);
            });

            app.UseCors(CorsOptions.AllowAll);

            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            // web api configuration
            app.UseWebApi(config);
        }
    }
}