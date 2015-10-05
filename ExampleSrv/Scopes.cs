using IdentityServer3.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExampleSrv
{
    public static class Scopes
    {
        public static IEnumerable<Scope> Get()
        {
            var scopes = new List<Scope>
            {
                new Scope
                {
                    Enabled = true,
                    Name = "roles",
                    Type = ScopeType.Identity,
                    Claims = new List<ScopeClaim>
                    {
                        new ScopeClaim("role")
                    }
                },
                new Scope
                {
                    Enabled = true,
                    Name = "apiAccess",
                    DisplayName = "API Access",
                    Description = "Access to all the APIs",
                    Type = ScopeType.Resource,
                    Claims = new List<ScopeClaim>
                    {
                        new ScopeClaim("role")
                    }
                }
            };

            scopes.AddRange(StandardScopes.All);

            return scopes;
        }
    }
}