using System;
using HexMaster.Parcheesi.Common;
using HexMaster.Parcheesi.Common.Base;
using HexMaster.Parcheesi.Common.Infrastructure.Enums;
using HexMaster.Parcheesi.Common.ValueObjects;

namespace HexMaster.Parcheesi.IdentityService.DomainModels
{
    public class Credentials : DomainModelBase<Guid>
    {
        public string Username { get; set; }
        public Password Password { get; set; }


        public Credentials(Guid id, 
            string username, 
            string password, 
            string secret) : base(id)
        {
            Username = username;
            Password = new Password(password, secret);
        }
        private Credentials( 
            string username, 
            string password) : base(Guid.NewGuid(), TrackingState.Added )
        {
            Username = username;
            Password = new Password(password, Randomizer.GenerateSecret());
        }

        public static Credentials Create(string username, string password)
        {
            return new Credentials(username, password);
        }
    }
}
