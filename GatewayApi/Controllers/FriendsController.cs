using System.Threading.Tasks;
using HexMaster.Parcheesi.GatewayApi.Base;
using IdentityModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HexMaster.Parcheesi.GatewayApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FriendsController : GatewayBaseController
    {

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            var user = HttpContext.User;
            var userId = user.FindFirst(JwtClaimTypes.Subject).Value;
//            return new[] { $"Service A has recognized you as {displayName} with email {email} and identity {userId}." };


            var httpClient = GetSecureClient("networkservice");
            var response = await httpClient.GetAsync("/api/friends");
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                return Ok(responseContent);
            }

            return StatusCode((int)response.StatusCode);

        }

    }
}