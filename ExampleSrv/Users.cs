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
                    new Claim(ClaimTypes.GivenName, "Scott"),
                    new Claim(ClaimTypes.Surname, "Sloan"),
                    new Claim(ClaimTypes.Email, "scottsloan@gmail.com"),
                    new Claim(ClaimTypes.Role, "Geek"),
                    new Claim(ClaimTypes.Role, "Foo")
                }
            });

            return _users;
        }
    }
}