using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zalo.Model;
using Zalo.Service;

namespace Zalo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManageController : ControllerBase
    {
        public readonly IManageService _manageService;

        public ManageController(IManageService manageService)
        {
            this._manageService = manageService;
        }

        [HttpPost]
        [Route("GetOA")]
        public async Task<IActionResult> GetOAInfo([FromBody] string accessToken)
        {
            try
            {
                var data = await _manageService.GetOAInfo(accessToken);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
