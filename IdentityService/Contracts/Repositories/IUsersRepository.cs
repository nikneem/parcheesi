using System;
using System.Threading.Tasks;
using HexMaster.Parcheesi.IdentityService.DomainModels;

namespace HexMaster.Parcheesi.IdentityService.Contracts.Repositories
{
    public interface IUsersRepository
    {
        Task<User> Find(string username, string password);
        Task<User> Find(Guid userId);
    }
}