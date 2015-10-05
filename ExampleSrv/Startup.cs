using ExampleSrv.UserServices;
using IdentityServer3.Core.Configuration;
using IdentityServer3.Core.Services;
using IdentityServer3.Core.Services.Default;
using Owin;
using Serilog;

namespace ExampleSrv
{
    public sealed class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Log.Logger = new LoggerConfiguration()
                        .MinimumLevel.Debug()
                        .WriteTo.Trace()
                        .CreateLogger();

            app.Map("/core",
                coreApp =>
                {
                    var factory = new IdentityServerServiceFactory()
                                   .UseInMemoryClients(Clients.Get())
                                   .UseInMemoryScopes(Scopes.Get());


                    var userSrv = new CustomUserService();
                    factory.UserService = new Registration<IUserService>(resolver => userSrv);
                    factory.CorsPolicyService = new Registration<ICorsPolicyService>(
                        new DefaultCorsPolicyService { AllowAll = true }
                    );

                    var options = new IdentityServerOptions
                    {
                        SiteName = "Example Identity Server",
                        SigningCertificate = Cert.Load(),
                        RequireSsl = true,
                        Factory = factory,
                        EventsOptions = new EventsOptions
                        {
                            RaiseSuccessEvents = true,
                            RaiseErrorEvents = true,
                            RaiseFailureEvents = true,
                            RaiseInformationEvents = true
                        },
                        AuthenticationOptions = new IdentityServer3.Core.Configuration.AuthenticationOptions
                        {
                            EnablePostSignOutAutoRedirect = true
                        }
                    };

                    coreApp.UseIdentityServer(options);
                });
        }
    }
}