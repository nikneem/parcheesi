using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HexMaster.Parcheesi.Common.Infrastructure;
using HexMaster.Parcheesi.NetworkService.Contracts.Repositories;
using HexMaster.Parcheesi.NetworkService.Contracts.Services;
using HexMaster.Parcheesi.NetworkService.DataTransferObjects;
using HexMaster.Parcheesi.NetworkService.DomainModels;

namespace HexMaster.Parcheesi.NetworkService.Services
{
    public class FriendsService : IFriendsService
    {
        private readonly IFriendsRepository _friendsRepository;

        public async Task<ICollection<FriendDto>> Get(
            string q, 
            int page = 0,
            int pageSize = Constants.default_page_size)
        {
            var response = await _friendsRepository.Get(Guid.Parse("00000000-0000-0000-0001-000000000000"), q, page, pageSize);
            return response.Select(model => new FriendDto
            {
                Id = model.Id,
                FriendId = model.FriendId,
                FriendName = model.Name,
                IsAccepted = model.IsAccepted
            }).ToList();
        }

        public async Task<FriendDto> Create(FriendInvitationDto dto)
        {
            var friend = new Friend(Guid.Parse("00000000-0000-0000-0001-000000000000"), dto.FriendId, dto.Name);
            var model = await _friendsRepository.Create(friend);
            return new FriendDto
            {
                Id = model.Id,
                FriendId = model.FriendId,
                FriendName = model.Name,
                IsAccepted = model.IsAccepted
            };
        }

        public async Task<FriendDto> Update(FriendInvitationDto dto)
        {
            throw new NotImplementedException();
        }


        public FriendsService(IFriendsRepository friendsRepository)
        {
            _friendsRepository = friendsRepository;
        }

    }
}
