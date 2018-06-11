using System.Threading.Tasks;
using HexMaster.Parcheesi.NetworkService.Contracts.Services;
using HexMaster.Parcheesi.NetworkService.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;

namespace HexMaster.Parcheesi.NetworkService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FriendsController : ControllerBase
    {
        private readonly IFriendsService _friendsService;

        public FriendsController(IFriendsService friendsService)
        {
            _friendsService = friendsService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string q)
        {
            var model = await _friendsService.Get(q);
            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]FriendInvitationDto invitation)
        {
            var model = await _friendsService.Create(invitation);
            return Ok(model);
        }


    }
}