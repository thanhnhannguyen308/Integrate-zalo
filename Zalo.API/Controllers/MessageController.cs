using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zalo.Model;
using Zalo.Service;

namespace Zalo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;
        public MessageController(IMessageService messageService) 
        {
            _messageService = messageService;
        }

        [HttpPost]
        [Route("text")]
        public async Task<IActionResult> SendText([FromBody] MessageTextRequest model)
        {
            try
            {
                var data = await _messageService.SendText(model);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
