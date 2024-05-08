using Application.Dto;
using Application.Exceptions;
using Application.Extensions;
using Application.Mapping;
using DataAccess;
using DataAccess.Models;

namespace Application.Services.Implementations
{
    internal class LoginService : ILoginService
    {
        private readonly DatabaseContext _context;

        public LoginService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<AccountDto> LogInToTheAccountAsync(Guid emploeeId, string login, string password, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(login, nameof(login));
            ArgumentNullException.ThrowIfNull(password, nameof(password));

            var employee = await _context.Employees.GetEntityAsync(emploeeId, cancellationToken);
            var account = employee.Accounts.FirstOrDefault(a => a.Login.Equals(login) && a.Password.Equals(password));

            if (account is null)
            {
                throw AccountException.AccountDoesNotExist(login, password);
            }

            if (employee is Manager)
            {
                account.Role = AccountRole.Manager;
            }
            else
            {
                account.Role = AccountRole.Subordinate;
            }

            return account.AsDto();
        }
    }
}
