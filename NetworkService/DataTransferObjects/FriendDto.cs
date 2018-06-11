using System;

namespace HexMaster.Parcheesi.NetworkService.DataTransferObjects
{
    public class FriendDto
    {
        public string Id { get; set; }
        public Guid FriendId { get; set; }
        public string FriendName { get; set; }
        public bool IsAccepted { get; set; }
    }
}