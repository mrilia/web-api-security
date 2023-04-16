using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace IDPServer;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
        };

    public static IEnumerable<ApiResource> ApiRecources =>
        new ApiResource[]
        {
            new ApiResource("sampleapi", "Sample API")
            {
                Scopes={"sampleapi"},
                Name = "sampleApi",
                DisplayName = "Sample API",
                Description = "Applications can access to the sample api",
                //TODO: Don't use magic strings
                ApiSecrets=new List<Secret>{ new Secret("secret".Sha256())}
            }
        };

    public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
            {
            new ApiScope("sampleapi")};

    //TODO: Read clients from DB
    public static IEnumerable<Client> Clients =>
        new Client[]
            {
            new Client(){
                ClientName ="sample-Api",
                ClientId ="sampleapi",
                AllowedGrantTypes=GrantTypes.ResourceOwnerPassword,
                AllowedScopes =
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    "sampleapi"
                },
                ClientSecrets =
                {
                    new Secret("secret".Sha256())
                },
                RequireConsent = true
            }
            };
}