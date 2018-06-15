using System;
using System.Collections.Generic;
using IdentityServer4;
using IdentityServer4.Models;

namespace HexMaster.Parcheesi.IdentityService.Configuration
{
    public class Config
    {
        // ApiResources define the apis in your system
        public static IEnumerable<ApiResource> GetApis()
        {

            //34c3c730-4472-46b9-915f-fa4c74473334
            //5f6d879f-fa9a-495c-bb11-cf66fc6f4845
            //e1c25d92-7315-4db0-a8e9-8767ae49bd1b
            //b9a9ed3d-849d-414e-a565-7e54668d4ebc
            //b5fafb8e-127c-4ed7-8e08-c7be4ae0b741
            var apis = new Dictionary<string, Guid>
            {
                {"gateway-api", Guid.Parse("27a62c79-3c7c-412c-b342-432933ba1aae")},
                {"content-service", Guid.Parse("1f026e5c-c9e2-4862-a783-156b58dc0c6c")},
                {"chat-service", Guid.Parse("5a106cfd-d861-4498-9744-b4cb9032d9ee")},
                {"network-service", Guid.Parse("e46d0760-c1b2-4453-967f-91687785c207")},
                {"game-service", Guid.Parse("bf0f9a8c-4aee-4f03-a818-71a03c8b9bf7")}
            };
            return new List<ApiResource>
            {
                new ApiResource("gateway-api", "Gateway API") { ApiSecrets = { new Secret(apis["gateway-api"].ToString().Sha256()) } },
                new ApiResource("content-service", "Content service") { ApiSecrets = { new Secret(apis["content-service"].ToString().Sha256()) } },
                new ApiResource("chat-service", "Chat service") { ApiSecrets = { new Secret(apis["chat-service"].ToString().Sha256()) } },
                new ApiResource("network-service", "Chat service") { ApiSecrets = { new Secret(apis["network-service"].ToString().Sha256()) } },
                new ApiResource("game-service", "Game service") { ApiSecrets = { new Secret(apis["game-service"].ToString().Sha256()) } }
            };
        }

        public static IEnumerable<IdentityResource> GetResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Email(),
                new IdentityResources.Profile()
            };
        }


        // client want to access resources (aka scopes)
        public static IEnumerable<Client> GetClients(Dictionary<string,string> clientsUrl)
        {


            return new List<Client>
            {
                // JavaScript Client
                new Client
                {
                    ClientId = "spa-pwa",
                    ClientName = "Parcheesi OpenId SPA Client",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = new List<Secret> { new Secret("superSecretPassword".Sha256()) },  
                    AllowAccessTokensViaBrowser = true,
                    RedirectUris =           { $"{clientsUrl["Spa"]}/" },
                    RequireConsent = false,
                    PostLogoutRedirectUris = { $"{clientsUrl["Spa"]}/" },
                    AllowedCorsOrigins =     { $"{clientsUrl["Spa"]}" },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "chat",
                        "game",
                        "network",
                        "chat.signalrhub",
                        "game.signalrhub",
                        "network.signalrhub"
                    }
                }
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                // native clients

                new Client
                {
                    ClientId = "spa",
                    ClientSecrets = { new Secret("spa".Sha256()) },
                    ClientName = "Front-end project",
                    AllowAccessTokensViaBrowser = true,
                    AllowOfflineAccess = true,
                    RequireClientSecret = true,
                    AccessTokenType = AccessTokenType.Jwt,
                    RedirectUris = { "https://notused" },
                    PostLogoutRedirectUris = { "https://notused" },
                    RefreshTokenUsage = TokenUsage.OneTimeOnly,
                    RefreshTokenExpiration = TokenExpiration.Absolute,

                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                    AllowedScopes = { "openid", "profile", "email", "api" },
                },

                new Client
                {
                    ClientId = "native.hybrid",
                    ClientName = "Native Client (Hybrid with PKCE)",

                    RedirectUris = { "https://notused" },
                    PostLogoutRedirectUris = { "https://notused" },

                    RequireClientSecret = false,

                    AllowedGrantTypes = GrantTypes.Hybrid,
                    RequirePkce = true,
                    AllowedScopes = { "openid", "profile", "email", "api" },

                    AllowOfflineAccess = true,
                    RefreshTokenUsage = TokenUsage.ReUse
                },
                new Client
                {
                    ClientId = "server.hybrid",
                    ClientName = "Server-based Client (Hybrid)",

                    RedirectUris = { "https://notused" },
                    PostLogoutRedirectUris = { "https://notused" },

                    ClientSecrets = { new Secret("secret".Sha256()) },

                    AllowedGrantTypes = GrantTypes.Hybrid,
                    AllowedScopes = { "openid", "profile", "email", "api" },

                    AllowOfflineAccess = true,
                    RefreshTokenUsage = TokenUsage.ReUse
                },
                new Client
                {
                    ClientId = "native.code",
                    ClientName = "Native Client (Code with PKCE)",

                    RedirectUris = { "https://notused" },
                    PostLogoutRedirectUris = { "https://notused" },

                    RequireClientSecret = false,

                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = true,
                    AllowedScopes = { "openid", "profile", "email", "api" },

                    AllowOfflineAccess = true,
                    RefreshTokenUsage = TokenUsage.ReUse
                },
                new Client
                {
                    ClientId = "server.code",
                    ClientName = "Service Client (Code)",

                    RedirectUris = { "https://notused" },
                    PostLogoutRedirectUris = { "https://notused" },

                    ClientSecrets = { new Secret("secret".Sha256()) },

                    AllowedGrantTypes = GrantTypes.Code,
                    AllowedScopes = { "openid", "profile", "email", "api" },

                    AllowOfflineAccess = true,
                    RefreshTokenUsage = TokenUsage.ReUse
                },

                // server to server
                new Client
                {
                    ClientId = "client",
                    ClientSecrets = { new Secret("secret".Sha256()) },

                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = { "api" },
                },

                // implicit (e.g. SPA or OIDC authentication)
                new Client
                {
                    ClientId = "implicit",
                    ClientName = "Implicit Client",
                    AllowAccessTokensViaBrowser = true,

                    RedirectUris = { "https://notused" },
                    PostLogoutRedirectUris = { "https://notused" },
                    FrontChannelLogoutUri = "http://localhost:5000/signout-idsrv", // for testing identityserver on localhost

                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowedScopes = { "openid", "profile", "email", "api" },
                },

                // implicit using reference tokens (e.g. SPA or OIDC authentication)
                new Client
                {
                    ClientId = "implicit.reference",
                    ClientName = "Implicit Client using reference tokens",
                    AllowAccessTokensViaBrowser = true,

                    AccessTokenType = AccessTokenType.Reference,

                    RedirectUris = { "https://notused" },
                    PostLogoutRedirectUris = { "https://notused" },

                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowedScopes = { "openid", "profile", "email", "api" },
                },

                // implicit using reference tokens (e.g. SPA or OIDC authentication)
                new Client
                {
                    ClientId = "implicit.shortlived",
                    ClientName = "Implicit Client using short-lived tokens",
                    AllowAccessTokensViaBrowser = true,

                    AccessTokenLifetime = 70,

                    RedirectUris = { "https://notused" },
                    PostLogoutRedirectUris = { "https://notused" },

                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowedScopes = { "openid", "profile", "email", "api" },
                }
            };
        }
    }
}