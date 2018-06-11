using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace HexMaster.Parcheesi.IdentityService.Data.Entities
{
    public class UserProfileEntity
    {
        [BsonId]
        public Guid Id { get; set; }
        public string DisplayName { get; set; }
        public string EmailAddress { get; set; }
        public List<string> Scopes { get; set; }
        public bool IsVerified { get; set; }
        public DateTime VerificationExpiresOn { get; set; }
        public DateTime LastActivityOn { get; set; }
    }
}
