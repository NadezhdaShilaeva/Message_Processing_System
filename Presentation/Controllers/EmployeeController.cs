using Application.Dto;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models.Messages;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _service;

        public EmployeeController(IEmployeeService service)
        {
            _service = service;
        }

        public CancellationToken CancellationToken => HttpContext.RequestAborted;

        [HttpPost("{accountId:Guid}/searching_messages")]
        public async Task<ActionResult<IReadOnlyCollection<MessageDto>>> FindMessagesAsync(Guid accountId)
        {
            var messages = await _service.FindMessagesAsync(accountId, CancellationToken);
            return Ok(messages);
        }

        [HttpPost("{accountId:Guid}/process_message")]
        public async Task<ActionResult> ProcessMesageAsync(Guid accountId, [FromBody] ProcessMesageModel model)
        {
            await _service.ProcessMesageAsync(accountId, model.messageId, model.emploeeId, CancellationToken);
            return Ok();
        }
    }
}
