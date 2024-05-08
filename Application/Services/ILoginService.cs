using Application.Dto;

namespace Application.Services
{
    public interface ILoginService
    {
        Task<AccountDto> LogInToTheAccountAsync(Guid emploeeId, string login, string password, CancellationToken cancellationToken);
    }
}
