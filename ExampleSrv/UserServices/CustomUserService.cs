using IdentityServer3.Core.Models;
using IdentityServer3.Core.Services.Default;
using IdentityServer3.Core.Services.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace ExampleSrv.UserServices
{
    public class CustomUserService : UserServiceBase
    {

        public override Task AuthenticateExternalAsync(ExternalAuthenticationContext context)
        {
            return Task.FromResult<AuthenticateResult>(null);
        }

        public override Task AuthenticateLocalAsync(LocalAuthenticationContext context)
        {
            string username = context.UserName;
            string password = context.Password;

            InMemoryUser _user = Users.Get().Where(u => u.Username == username && u.Password == password).SingleOrDefault();

            if (_user != null)
            {
                context.AuthenticateResult = new AuthenticateResult(subject: _user.Subject, name: username);
            }

            return Task.FromResult(0);
        }

        public override Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            List<Claim> _claims = new List<Claim>();

            Claim _subject = context.Subject.Claims.FirstOrDefault();

            if (_subject != null)
            {
                _claims = this.BuildClaimsForSubject(_subject.Value);
            }

            context.IssuedClaims = _claims.AsEnumerable();

            return Task.FromResult(0);
        }

        private List<Claim> BuildClaimsForSubject(string subject)
        {
            List<Claim> _claims = new List<Claim>();

            if (!String.IsNullOrEmpty(subject))
            {
                InMemoryUser _user = Users.Get().Where(u => u.Subject == subject).SingleOrDefault();

                if (_user != null)
                {
                    _claims = _user.Claims.ToList();
                }

            }

            return _claims;
        }

        public override Task IsActiveAsync(IsActiveContext context)
        {
            context.IsActive = true;
            return Task.FromResult(0);
        }

        public override Task PostAuthenticateAsync(PostAuthenticationContext context)
        {
            return Task.FromResult(0);
        }

        public override Task PreAuthenticateAsync(PreAuthenticationContext context)
        {
            return Task.FromResult(0);
        }

        public override Task SignOutAsync(SignOutContext context)
        {
            return Task.FromResult(0);
        }
    }
}