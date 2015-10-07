using IdentityServer3.Core.Services.InMemory;
using System.Collections.Generic;
using System.Security.Claims;

namespace ExampleSrv
{
    public static class Users
    {
        public static List<InMemoryUser> Get()
        {
            List<InMemoryUser> _users = new List<InMemoryUser>();

            _users.Add(new InMemoryUser
            {
                Username = "s",
                Password = "s",
                Subject = "1",
                Claims = new List<Claim>
                {
                    new Claim(IdentityServer3.Core.Constants.ClaimTypes.GivenName, "Scott"),
                    new Claim(IdentityServer3.Core.Constants.ClaimTypes.FamilyName, "Sloan"),
                    new Claim(IdentityServer3.Core.Constants.ClaimTypes.Email, "scottsloan@gmail.com"),
                    new Claim(IdentityServer3.Core.Constants.ClaimTypes.Role, "Geek"),
                    new Claim(IdentityServer3.Core.Constants.ClaimTypes.Role, "Foo")
                }
            });

            return _users;
        }
    }
}