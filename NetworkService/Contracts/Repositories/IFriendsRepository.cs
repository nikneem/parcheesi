using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HexMaster.Parcheesi.Common.Infrastructure;
using HexMaster.Parcheesi.NetworkService.DomainModels;

namespace HexMaster.Parcheesi.NetworkService.Contracts.Repositories
{
    public interface IFriendsRepository
    {
        Task<ICollection<Friend>> Get(Guid userId, string q, int page = 0, int pageSize = Constants.default_page_size);
        Task<Friend> Create(Friend model);
    }
}