using Application.Dto;

namespace Application.Services
{
    public interface ISetupService
    {
        Task<ManagerDto> CreateManagerAsync(string name, CancellationToken cancellationToken);
        Task<EmployeeDto> CreateSubordinateAsync(string name, Guid managerId, CancellationToken cancellationToken);
        Task<ManagerDto> AddManagerToOtherManagerAsync(Guid managerId, Guid otherManagerId, CancellationToken cancellationToken);
        Task<AccountDto> CreateAccountAsync(string login, string password, CancellationToken cancellationToken);
        Task<EmployeeDto> AddAccountToEmployeeAsync(Guid accountId, Guid emploeeId, CancellationToken cancellationToken);
        Task<EmailSourceDto> CreateEmailMessageSourceAsync(CancellationToken cancellationToken);
        Task<PhoneSourceDto> CreatePhoneMessageSourceAsync(CancellationToken cancellationToken);
        Task<MessengerSourceDto> CreateMessengerMessageSourceAsync(CancellationToken cancellationToken);
        Task<AccountDto> AddSourceToAccountAsync(Guid sourceId, Guid accountId, CancellationToken cancellationToken);
        Task<EmailMessageDto> CreateEmailMessageAsync(Guid emailSourceId, string text, CancellationToken cancellationToken);
        Task<PhoneMessageDto> CreatePhoneMessageAsync(Guid phoneSourceId, string text, CancellationToken cancellationToken);
        Task<MessengerMessageDto> CreateMessengerMessageAsync(Guid messengerSourceId, string text, CancellationToken cancellationToken);
    }
}
