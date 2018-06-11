using System;
using HexMaster.Parcheesi.Common.Base;

namespace HexMaster.Parcheesi.NetworkService.DomainModels
{
    public class Friend : DomainModelBase<string>
    {
        public Guid UserId { get; private set; }
        public Guid FriendId { get; private set; }
        public string Name { get; }
        public bool IsAccepted { get; private set; }
        public bool IsPending { get; private set; }
        public DateTime CreatedOn { get; private set; }
        public DateTime ExpiresOn { get; private set; }
        public DateTime? AcceptedOn { get; private set; }
        public DateTime? DeniedOn { get; private set; }


        public Friend(string id, 
            Guid userId,
            Guid friendId,
            string name,
            bool isAccepted, 
            bool isPending, 
            DateTime createdOn, 
            DateTime expiresOn, 
            DateTime? acceptedOn,
            DateTime? deniedOn)
            : base(id)
        {
            UserId = userId;
            FriendId = friendId;
            Name = name;
            IsAccepted = isAccepted;
            IsPending = isPending;
            CreatedOn = createdOn;
            ExpiresOn = expiresOn;
            AcceptedOn = acceptedOn;
            DeniedOn = deniedOn;
        }
        public Friend(
            Guid userId,
            Guid friendId,
            string name)
        {
            UserId = userId;
            FriendId = friendId;
            Name = name;
            CreatedOn=DateTime.UtcNow;
            ExpiresOn = DateTime.UtcNow.AddDays(14);
        }

    }
}