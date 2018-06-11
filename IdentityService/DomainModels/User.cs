using System;
using HexMaster.Parcheesi.Common.Base;

namespace HexMaster.Parcheesi.IdentityService.DomainModels
{
    public class User : DomainModelBase<Guid>
    {
        public string DisplayName { get; }
        public string Email { get; }
        public bool IsVerified { get; }
        public DateTime VerificationExpiresOn { get; }
        public DateTime LastActivityOn { get; }
        public Credentials Credentials { get; }


        public User(Guid id, 
            string displayName,
            string email, 
            bool isVerified,
            DateTime verificationExpiresOn,
            DateTime lastActivityOn,
            Credentials credentials = null)
        : base(id)
        {
            DisplayName = displayName;
            Email = email;
            IsVerified = isVerified;
            VerificationExpiresOn = verificationExpiresOn;
            LastActivityOn = lastActivityOn;
            Credentials = credentials;
        }
    }
}
