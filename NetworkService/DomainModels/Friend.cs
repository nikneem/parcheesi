using System;
using HexMaster.Parcheesi.Common.Base;

namespace HexMaster.Parcheesi.NetworkService.DomainModels
{
    public class Friend : DomainModelBase<Guid>
    {
        public Guid UserId { get; private set; }
        public Guid FriendId { get; private set; }
        public bool IsAccepted { get; private set; }
        public bool IsPending { get; private set; }
        public DateTime CreatedOn { get; private set; }
        public DateTime ExpiresOn { get; private set; }
        public DateTime? AcceptedOn { get; private set; }
        public DateTime? DeniedOn { get; private set; }
    }
}