using System;
using HexMaster.Parcheesi.Common.Contracts;

namespace HexMaster.Parcheesi.Common.Infrastructure.Models
{
    public class UserContext : IUserContext
    {

        public Guid UserId { get; }
    }
}
