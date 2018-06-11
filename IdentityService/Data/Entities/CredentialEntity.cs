using System;
using MongoDB.Bson.Serialization.Attributes;

namespace HexMaster.Parcheesi.IdentityService.Data.Entities
{
    public class CredentialEntity
    {
        [BsonId]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Secret { get; set; }
    }
}
