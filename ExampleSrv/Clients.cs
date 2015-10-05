using IdentityServer3.Core.Models;
using System.Collections.Generic;
using ExampleShared;
namespace ExampleSrv
{
    public static class Clients
    {
        public static IEnumerable<Client> Get()
        {
            return new List<Client> {
                new Client {
                    ClientId = Constants.ImplicitClient,
                    ClientName = "Example Implicit Client",
                    Flow = Flows.Implicit,
                    AllowedScopes = new List<string>()
                    {
                        "openid",
                        "profile",
                        "roles",
                        "apiAccess"
                    },
                    RedirectUris = new List<string>() {
                        Constants.ImplicitClientUri
                    },
                    PostLogoutRedirectUris = new List<string>() {
                        Constants.ImplicitClientUri
                    }
                },
                new Client
                {
                    ClientId = Constants.APIClient,
                    ClientName = "API Service Access",
                    Flow = Flows.ClientCredentials,
                    ClientSecrets = new List<Secret>
                    {
                        new Secret(Constants.IdentitySecret.Sha256())
                    },
                    AllowedScopes = new List<string>
                    {
                        "apiAccess"
                    }
                },
                new Client
                {
                    ClientId = "jsClient",
                    ClientName = "jsClient",
                    ClientSecrets = new List<Secret> {
                        new Secret(Constants.IdentitySecret.Sha256())
                    },
                    Flow = Flows.Hybrid,
                    RequireConsent = true,
                    AllowRememberConsent = true,
                    RedirectUris = new List<string> {
                        Constants.AureliaClient
                    },
                    PostLogoutRedirectUris = new List<string> {
                        Constants.AureliaClient
                    },
                    AllowedScopes = new List<string> {
                        "openid",
                        "profile",
                        "roles",
                        "apiAccess"
                    }
                }
            };
        }
    }
}

/* Flows Explained
Implicit

AuthorizationCode,

Hybrid,

ClientCredientals,

ResourceOwner


*/
