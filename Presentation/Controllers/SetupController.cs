using Application.Dto;
using Application.Services;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models.Accounts;
using Presentation.Models.Emploees;
using Presentation.Models.Messages;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SetupController : ControllerBase
    {
        private readonly ISetupService _service;

        public SetupController(ISetupService service)
        {
            _service = service;
        }

        public CancellationToken CancellationToken => HttpContext.RequestAborted;

        [HttpPost("creating_manager")]
        public async Task<ActionResult<ManagerDto>> CreateManagerAsync([FromBody] CreateManagerModel model)
        {
            var manager = await _service.CreateManagerAsync(model.name, CancellationToken);
            return Ok(manager);
        }

        [HttpPost("creating_subordinate")]
        public async Task<ActionResult<EmployeeDto>> CreateSubordinateAsync([FromBody] CreateSubordinateModel model)
        {
            var subordinate = await _service.CreateSubordinateAsync(model.name, model.managerId, CancellationToken);
            return Ok(subordinate);
        }

        [HttpPost("adding_manager")]
        public async Task<ActionResult> AddManagerToOtherManagerAsync(Guid managerId, Guid otherManagerId)
        {
            await _service.AddManagerToOtherManagerAsync(managerId, otherManagerId, CancellationToken);
            return Ok();
        }

        [HttpPost("creating_account")]
        public async Task<ActionResult<AccountDto>> CreateAccountAsync([FromBody] CreateAccountModel model)
        {
            var account = await _service.CreateAccountAsync(model.login, model.password, CancellationToken);
            return Ok(account);
        }

        [HttpPost("adding_account")]
        public async Task<ActionResult> AddAccountToEmployeeAsync(Guid accountId, Guid emploeeId)
        {
            await _service.AddAccountToEmployeeAsync(accountId, emploeeId, CancellationToken);
            return Ok();
        }

        [HttpPost("creating_email_source")]
        public async Task<ActionResult<EmailSourceDto>> CreateEmailMessageSourceAsync()
        {
            var emailSource = await _service.CreateEmailMessageSourceAsync(CancellationToken);
            return Ok(emailSource);
        }

        [HttpPost("creating_phone_source")]
        public async Task<ActionResult<PhoneSourceDto>> CreatePhoneMessageSourceAsync()
        {
            var phoneSource = await _service.CreatePhoneMessageSourceAsync(CancellationToken);
            return Ok(phoneSource);
        }

        [HttpPost("creating_messenger_source")]
        public async Task<ActionResult<MessengerSourceDto>> CreateMessengerMessageSourceAsync()
        {
            var messengerSource = await _service.CreateMessengerMessageSourceAsync(CancellationToken);
            return Ok(messengerSource);
        }

        [HttpPost("adding_source")]
        public async Task<ActionResult> AddSourceToAccountAsync(Guid sourceId, Guid accountId)
        {
            await _service.AddSourceToAccountAsync(sourceId, accountId, CancellationToken);
            return Ok();
        }

        [HttpPost("creating_email_message")]
        public async Task<ActionResult<EmailMessageDto>> CreateEmailMessageAsync([FromBody] CreateEmailMessageModel model)
        {
            var message = await _service.CreateEmailMessageAsync(model.emailSourceId, model.text, CancellationToken);
            return Ok(message);
        }

        [HttpPost("creating_phone_message")]
        public async Task<ActionResult<PhoneMessageDto>> CreatePhoneMessageAsync([FromBody] CreatePhoneMessageModel model)
        {
            var message = await _service.CreatePhoneMessageAsync(model.phoneSourceId, model.text, CancellationToken);
            return Ok(message);
        }

        [HttpPost("creating_messenger_message")]
        public async Task<ActionResult<MessengerMessageDto>> CreateMessengerMessageAsync([FromBody] CreateMessengerMessageModel model)
        {
            var message = await _service.CreateMessengerMessageAsync(model.messengerSourceId, model.text, CancellationToken);
            return Ok(message);
        }
    }
}
