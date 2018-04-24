namespace IdentityServerTest.Configuration
{
    using IdentityServer3.Core;
    using IdentityServer3.Core.Models;
    using IdentityServer3.Core.Services.InMemory;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Web;

    public static class InMemoryManager
    {
        public static List<InMemoryUser> GetUsers()
        {
            return new List<InMemoryUser>
            {
                new InMemoryUser
                {
                    Subject = "dave",
                    Username = "dave",
                    Password = "test123",
                    Claims =  new []
                    {
                        new Claim(Constants.ClaimTypes.Name, "David Evans")
                    }
                }
            };
        }

        public static IEnumerable<Scope> GetScopes()
        {
            return new[]
            {
                StandardScopes.OpenId,
                StandardScopes.Profile,
                StandardScopes.OfflineAccess,
                new Scope
                {
                    Name = "read",
                    DisplayName = "Read User Data"
                }
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new[]
            {
                new Client
                {
                    ClientId = "idservertest",
                    ClientSecrets = new List<Secret>
                    {
                        new Secret("secret".Sha256())
                    },
                    ClientName = "IdentityServerTest",
                    Flow = Flows.ResourceOwner,
                    AllowedScopes = new List<string>
                    {
                        Constants.StandardScopes.OpenId,
                        "read"
                    },
                    Enabled = true
                }
            };
        }
    }
}