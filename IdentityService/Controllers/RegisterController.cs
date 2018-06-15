using System.Threading.Tasks;
using HexMaster.Parcheesi.Common.DataTransferObjects.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HexMaster.Parcheesi.IdentityService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegistrationRequestDto dto)
        {
            return null;
        }
    }
}