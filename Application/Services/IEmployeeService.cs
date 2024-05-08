using Application.Dto;

namespace Application.Services
{
    public interface IEmployeeService
    {
        Task<IReadOnlyCollection<MessageDto>> FindMessagesAsync(Guid accountId, CancellationToken cancellationToken);
        Task ProcessMesageAsync(Guid accountId, Guid messageId, Guid emploeeId, CancellationToken cancellationToken);
    }
}
