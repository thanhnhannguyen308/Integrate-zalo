using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zalo.Model;
using Zalo.Service;

namespace Zalo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IAutService _autService;

        public AuthController(IConfiguration configuration, IAutService autService)
        {
            _configuration = configuration;
            _autService = autService;
        }

        [HttpPost]
        [Route("access-token")]
        public async Task<IActionResult> GetPermisionAsync([FromBody]string Id)
        {
            try
            {
                var token = await _autService.GetAccessToken(Id);
                return Ok(token);
            }catch (Exception ex) 
            { 
                return BadRequest(ex.Message);
            }
            
        }

        
    }
}
