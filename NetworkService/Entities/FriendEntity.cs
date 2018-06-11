using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HexMaster.Parcheesi.NetworkService.Entities
{
    public class FriendEntity
    {

        [BsonId]
        public ObjectId Id { get; set; }
        public Guid UserId { get;  set; }
        public Guid FriendId { get;  set; }
        public string Name { get; set; }
        public bool IsAccepted { get;  set; }
        public bool IsPending { get;  set; }
        public DateTime CreatedOn { get;  set; }
        public DateTime ExpiresOn { get;  set; }
        public DateTime? AcceptedOn { get;  set; }
        public DateTime? DeniedOn { get;  set; }

    }
}
