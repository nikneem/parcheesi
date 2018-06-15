using System;
using System.Threading.Tasks;
using Common.ExtensionMethods;
using HexMaster.Parcheesi.Common.Configuration;
using HexMaster.Parcheesi.IdentityService.Configuration;
using HexMaster.Parcheesi.IdentityService.Contracts.Repositories;
using HexMaster.Parcheesi.IdentityService.Data.Entities;
using HexMaster.Parcheesi.IdentityService.DomainModels;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace HexMaster.Parcheesi.IdentityService.Data
{
    public class UsersRepository: IUsersRepository
    {
        private readonly IMongoCollection<CredentialEntity> _credentialsCollection;
        private readonly IMongoCollection<UserProfileEntity> _usersCollection;

        public UsersRepository(IOptions<MongoDbSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var database = client.GetDatabase(settings.Value.Database);
            _credentialsCollection = database.GetCollection<CredentialEntity>("Credentials");
            _usersCollection = database.GetCollection<UserProfileEntity>("Userprofiles");
        }

        public async Task<User> Find(string username, string password)
        {
            var credentialsEntity = await _credentialsCollection
                .Find(x => x.Username == username)
                .FirstOrDefaultAsync();

            var encryptedPassword = password.Hash(credentialsEntity.Secret);
            if (encryptedPassword == credentialsEntity.Password)
            {
                var userEntity = await _usersCollection
                    .Find(x => x.Id == credentialsEntity.UserId)
                    .FirstOrDefaultAsync();
                var credentials = new Credentials(
                    credentialsEntity.Id,
                    credentialsEntity.Username,
                    credentialsEntity.Password,
                    credentialsEntity.Secret);
                return new User(
                    userEntity.Id,
                    userEntity.DisplayName,
                    userEntity.EmailAddress,
                    userEntity.IsVerified,
                    userEntity.VerificationExpiresOn,
                    userEntity.LastActivityOn,
                    credentials
                    );
            }

            return null;
        }

        public async Task<User> Find(Guid userId)
        {
                var userEntity = await _usersCollection
                    .Find(x => x.Id == userId)
                    .FirstOrDefaultAsync();
                return new User(
                    userEntity.Id,
                    userEntity.DisplayName,
                    userEntity.EmailAddress,
                    userEntity.IsVerified,
                    userEntity.VerificationExpiresOn,
                    userEntity.LastActivityOn
                );
        }
    }
}
