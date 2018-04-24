[assembly: Microsoft.Owin.OwinStartup(typeof(IdentityServerTest.Startup))]

namespace IdentityServerTest
{
    using Owin;
    using IdentityServer3.Core.Configuration;
    using IdentityServerTest.Configuration;

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var factory = new IdentityServerServiceFactory()
               .UseInMemoryUsers(InMemoryManager.GetUsers())
               .UseInMemoryScopes(InMemoryManager.GetScopes())
               .UseInMemoryClients(InMemoryManager.GetClients());

            var options = new IdentityServerOptions
            {
                SigningCertificate = Certificate.Load(),
                RequireSsl = false,
                Factory = factory
            };

            app.UseIdentityServer(options);
        }
    }
}