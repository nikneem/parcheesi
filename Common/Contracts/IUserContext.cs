using System;

namespace HexMaster.Parcheesi.Common.Contracts
{
    public interface IUserContext
    {
        Guid UserId { get; }
        string Email { get; }
        string DisplayName { get; }

    }
}