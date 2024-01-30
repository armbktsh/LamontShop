using Duende.IdentityServer;

namespace Identity.API;

public static class Config
{
    public static IEnumerable<Client> Clients => new[]
    {
        new Client
        {
            ClientId = "WebMVC",

            AllowedGrantTypes = GrantTypes.Code,

            AllowedCorsOrigins = {"https://localhost:5010"},

            RedirectUris = {"https://localhost:5010/signin-oidc"},

            PostLogoutRedirectUris = {"https://localhost:5010/signout-callback-oidc"},

            ClientSecrets = {new Secret("secret".Sha256())},

             AllowedScopes = new List<string>
             {
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile,
                "roles",
                "ProductAPI"
             }
        }
    };

    public static IEnumerable<ApiScope> ApiScopes => new[]
    {
        new ApiScope("ProductAPI", "Products API")
    };

    public static IEnumerable<IdentityResource> IdentityResources => new List<IdentityResource>
    {
        new IdentityResources.Profile(),
        new IdentityResources.OpenId(),
        new IdentityResource("roles", new[]{ "role" })
    };
}