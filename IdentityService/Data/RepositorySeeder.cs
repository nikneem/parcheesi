using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.ExtensionMethods;
using HexMaster.Parcheesi.IdentityService.Configuration;
using HexMaster.Parcheesi.IdentityService.Data.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace HexMaster.Parcheesi.IdentityService.Data
{
    public class RepositorySeeder
    {
        private readonly IMongoCollection<CredentialEntity> _credentialsCollection;
        private readonly IMongoCollection<UserProfileEntity> _usersCollection;

        public RepositorySeeder(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);
            _credentialsCollection = database.GetCollection<CredentialEntity>("Credentials");
            _usersCollection = database.GetCollection<UserProfileEntity>("Userprofiles");
        }

        public async Task Seed()
        {
            if (await _usersCollection.CountAsync(x=> x.IsVerified) == 0)
            {
                await _usersCollection.InsertManyAsync(GetDefaultUsers());
            }
            if (await _credentialsCollection.CountAsync(ent => !string.IsNullOrEmpty(ent.Username)) == 0)
            {
                await _credentialsCollection.InsertManyAsync(GetDefaultCredentials());
            }
        }


        private static List<UserProfileEntity> GetDefaultUsers()
        {
            return new List<UserProfileEntity>
            {
                new UserProfileEntity
                {
                    Id = Guid.Parse("00000000-0000-0000-0001-000000000000"),
                    DisplayName = "Henkie Appie",
                    EmailAddress = "henkie@appie.com",
                    IsVerified = true,
                    LastActivityOn = DateTime.UtcNow,
                    VerificationExpiresOn = DateTime.UtcNow.AddDays(10),
                    Scopes = new List<string> {"profile", "game"}
                },
                new UserProfileEntity
                {
                    Id = Guid.Parse("00000000-0000-0000-0002-000000000000"),
                    DisplayName = "Henkie Appie",
                    EmailAddress = "henkie@appie.com",
                    IsVerified = true,
                    LastActivityOn = DateTime.UtcNow,
                    VerificationExpiresOn = DateTime.UtcNow.AddDays(10),
                    Scopes = new List<string> {"profile", "game"}
                }
            };
        }
        private static List<CredentialEntity> GetDefaultCredentials()
        {
            var secret1 = Guid.NewGuid().ToString().Replace("-", "");
            var secret2 = Guid.NewGuid().ToString().Replace("-", "");
            return new List<CredentialEntity>
            {
                new CredentialEntity
                {
                    Id = Guid.Parse("00000000-0000-0000-0001-000000000001"),
                    UserId = Guid.Parse("00000000-0000-0000-0001-000000000000"),
                    Username = "freddy-franeker",
                    Secret = secret1,
                    Password = "geheim".Hash(secret1)
                },
                new CredentialEntity
                {
                    Id = Guid.Parse("00000000-0000-0000-0002-000000000002"),
                    UserId = Guid.Parse("00000000-0000-0000-0002-000000000000"),
                    Username = "blitse-dirk",
                    Secret = secret2,
                    Password = "geheim".Hash(secret2)
                }
            };
        }

    }
}
