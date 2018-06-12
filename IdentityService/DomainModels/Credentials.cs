using System;
using HexMaster.Parcheesi.Common.Base;
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
    }
}
