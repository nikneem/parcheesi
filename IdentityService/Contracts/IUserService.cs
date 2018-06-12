using System.Threading.Tasks;
using HexMaster.Parcheesi.Common.DataTransferObjects.Authentication;

namespace HexMaster.Parcheesi.IdentityService.Contracts
{
    public interface IUserService
    {
        Task<RegistrationResponseDto> Register(RegistrationRequestDto dto);
    }
}