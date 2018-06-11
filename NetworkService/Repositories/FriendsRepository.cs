using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HexMaster.Parcheesi.Common.Infrastructure;
using HexMaster.Parcheesi.NetworkService.Contracts.Repositories;
using HexMaster.Parcheesi.NetworkService.DomainModels;
using HexMaster.Parcheesi.NetworkService.Entities;
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

            var result = await _collection
                .Find(doc => doc.UserId == userId && (string.IsNullOrEmpty(q) || doc.Name.Contains(q)))
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

        public FriendsRepository(IMongoClient client)
        {
            var database = client.GetDatabase("ParcheesiNetwork");
            _collection = database.GetCollection<FriendEntity>(CollectionName);
        }


    }
}