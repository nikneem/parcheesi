using System.Collections.Generic;
using IdentityServer4;
using IdentityServer4.Models;

namespace HexMaster.Parcheesi.IdentityServer.Configuration
{
    public class Config
    {
        // ApiResources define the apis in your system
        public static IEnumerable<ApiResource> GetApis()
        {
            return new List<ApiResource>
            {
                new ApiResource("chat", "Chat Service"),
                new ApiResource("game", "Game Service"),
                new ApiResource("network", "Network Service"),
                new ApiResource("chat.signalrhub", "Chat Signalr Hub"),
                new ApiResource("game.signalrhub", "Game Signalr Hub"),
                new ApiResource("network.signalrhub", "Network Signalr Hub")
            };
        }

        // Identity resources are data like user ID, name, or email address of a user
        // see: http://docs.identityserver.io/en/release/configuration/resources.html
        public static IEnumerable<IdentityResource> GetResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
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
    }
}