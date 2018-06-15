using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HexMaster.Parcheesi.Common.Configuration;
using HexMaster.Parcheesi.Common.Infrastructure;
using HexMaster.Parcheesi.NetworkService.Contracts.Repositories;
using HexMaster.Parcheesi.NetworkService.DomainModels;
using HexMaster.Parcheesi.NetworkService.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace HexMaster.Parcheesi.NetworkService.Repositories
{
    public class FriendsRepository : IFriendsRepository
    {
        private readonly IMongoCollection<FriendEntity> _collection;
        private const string CollectionName = "Network";


        public async Task<ICollection<Friend>> Get(Guid userId, string q, int page = 0, int pageSize = Constants.default_page_size)
        {
            if (page < 0) { page = 0;}
            if (pageSize < Constants.min_page_size || pageSize > Constants.max_page_size) { pageSize = Constants.default_page_size; }

            var skip = page * pageSize;

            var builder = Builders<FriendEntity>.Filter;
            var filter = builder.And(builder.Eq(ent => ent.UserId, userId));
            if (!string.IsNullOrWhiteSpace(q))
            {
                filter = filter & builder.And(builder.Regex(x => x.Name, q));
            }

            var result = await _collection
                .Find(filter)
                .SortBy(doc => doc.Name)
                .Skip(skip)
                .Limit(pageSize)
                .ToListAsync();

            return result.Select(EntityToDomainModel).ToList();
        }



        public async Task<Friend> Create(Friend model)
        {
            var entity = new FriendEntity
            {
                UserId = model.UserId,
                FriendId = model.FriendId,
                Name = model.Name,
                CreatedOn = model.CreatedOn,
                ExpiresOn = model.ExpiresOn,
                AcceptedOn = model.AcceptedOn,
                DeniedOn = model.DeniedOn,
                IsAccepted = model.IsAccepted,
                IsPending = model.IsPending
            };
            await _collection.InsertOneAsync(entity);
            return EntityToDomainModel(entity);
        }


        private static Friend EntityToDomainModel(FriendEntity ent)
        {
            return new Friend(
                ent.Id.ToString(),
                ent.UserId,
                ent.FriendId,
                ent.Name,
                ent.IsAccepted,
                ent.IsPending,
                ent.CreatedOn,
                ent.ExpiresOn,
                ent.AcceptedOn,
                ent.DeniedOn);
        }

        public FriendsRepository(IMongoClient client, IOptions<MongoDbSettings> settings)
        {
            var database = client.GetDatabase(settings.Value.Database);
            _collection = database.GetCollection<FriendEntity>(CollectionName);
        }


    }
}