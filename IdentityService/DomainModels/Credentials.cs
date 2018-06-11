using System;
using HexMaster.Parcheesi.Common.Base;

namespace HexMaster.Parcheesi.IdentityService.DomainModels
{
    public class Credentials : DomainModelBase<Guid>
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Secret { get; set; }


        public Credentials(Guid id, 
            string username, 
            string password, 
            string secret) : base(id)
        {
            Username = username;
            Password = password;
            Secret = secret;
        }
    }
}
