using System.Threading.Tasks;
using HexMaster.Parcheesi.Common.DataTransferObjects.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace HexMaster.Parcheesi.GatewayApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {


        public async Task<IActionResult> Post([FromBody] RegistrationRequestDto dto)
        {
            return Accepted();
        }

    }
}