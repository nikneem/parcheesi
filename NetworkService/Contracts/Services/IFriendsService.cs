using System.Collections.Generic;
using System.Threading.Tasks;
using HexMaster.Parcheesi.Common.Infrastructure;
using HexMaster.Parcheesi.NetworkService.DataTransferObjects;

namespace HexMaster.Parcheesi.NetworkService.Contracts.Services
{
    public interface IFriendsService
    {
        Task<ICollection<FriendDto>> Get(string q, int page =0, int pageSize = Constants.default_page_size);
        Task<FriendDto> Create(FriendInvitationDto dto);
    }
}