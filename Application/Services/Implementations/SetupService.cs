using Application.Dto;
using Application.Exceptions;
using Application.Extensions;
using Application.Mapping;
using DataAccess;
using DataAccess.Models;

namespace Application.Services.Implementations
{
    internal class SetupService : ISetupService
    {
        private readonly DatabaseContext _context;

        public SetupService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<ManagerDto> CreateManagerAsync(string name, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(name, nameof(name));

            var manager = new Manager(Guid.NewGuid(), name);

            _context.Managers.Add(manager);
            _context.Employees.Add(manager);
            await _context.SaveChangesAsync(cancellationToken);

            return manager.AsDto();
        }

        public async Task<EmployeeDto> CreateSubordinateAsync(string name, Guid managerId, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(name, nameof(name));

            var manager = await _context.Managers.GetEntityAsync(managerId, cancellationToken);
            var subordinate = new Subordinate(Guid.NewGuid(), name);
            manager.Subordinates.Add(subordinate);

            _context.Subordinates.Add(subordinate);
            _context.Employees.Add(subordinate);
            await _context.SaveChangesAsync(cancellationToken);

            return subordinate.AsDto();
        }

        public async Task<ManagerDto> AddManagerToOtherManagerAsync(Guid managerId, Guid otherManagerId, CancellationToken cancellationToken)
        {
            var manager = await _context.Managers.GetEntityAsync(managerId, cancellationToken);
            var mainManager = await _context.Managers.GetEntityAsync(otherManagerId, cancellationToken);
            if (manager.Equals(mainManager))
            {
                throw EmployeeException.SameManagers(managerId, otherManagerId);
            }

            if (_context.Managers.SelectMany(m => m.Subordinates).Contains(manager))
            {
                throw EmployeeException.AlreadyHasManager(managerId);
            }

            mainManager.Subordinates.Add(manager);

            await _context.SaveChangesAsync(cancellationToken);

            return manager.AsDto();
        }

        public async Task<AccountDto> CreateAccountAsync(string login, string password, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(login, nameof(login));
            ArgumentNullException.ThrowIfNull(password, nameof(password));

            if (_context.Accounts.FirstOrDefault(a => a.Login.Equals(login)) is not null)
            {
                throw AccountException.LoginAlreadyExists(login);
            }

            var account = new Account(Guid.NewGuid(), login, password);

            _context.Accounts.Add(account);
            await _context.SaveChangesAsync(cancellationToken);

            return account.AsDto();
        }

        public async Task<EmployeeDto> AddAccountToEmployeeAsync(Guid accountId, Guid emploeeId, CancellationToken cancellationToken)
        {
            var employee = await _context.Employees.GetEntityAsync(emploeeId, cancellationToken);
            var account = await _context.Accounts.GetEntityAsync(accountId, cancellationToken);
            employee.Accounts.Add(account);
            account.Employees.Add(employee);

            await _context.SaveChangesAsync(cancellationToken);

            return employee.AsDto();
        }

        public async Task<EmailSourceDto> CreateEmailMessageSourceAsync(CancellationToken cancellationToken)
        {
            var emailMessageSource = new EmailSource(Guid.NewGuid());

            _context.MessageSources.Add(emailMessageSource);
            _context.EmailSources.Add(emailMessageSource);
            await _context.SaveChangesAsync(cancellationToken);

            return emailMessageSource.AsDto();
        }

        public async Task<PhoneSourceDto> CreatePhoneMessageSourceAsync(CancellationToken cancellationToken)
        {
            var phoneMessageSource = new PhoneSource(Guid.NewGuid());

            _context.MessageSources.Add(phoneMessageSource);
            _context.PhoneSources.Add(phoneMessageSource);
            await _context.SaveChangesAsync(cancellationToken);

            return phoneMessageSource.AsDto();
        }

        public async Task<MessengerSourceDto> CreateMessengerMessageSourceAsync(CancellationToken cancellationToken)
        {
            var messengerMessageSource = new MessengerSource(Guid.NewGuid());

            _context.MessageSources.Add(messengerMessageSource);
            _context.MessengerSources.Add(messengerMessageSource);
            await _context.SaveChangesAsync(cancellationToken);

            return messengerMessageSource.AsDto();
        }

        public async Task<AccountDto> AddSourceToAccountAsync(Guid sourceId, Guid accountId, CancellationToken cancellationToken)
        {
            var account = await _context.Accounts.GetEntityAsync(accountId, cancellationToken);
            var source = await _context.MessageSources.GetEntityAsync(sourceId, cancellationToken);
            account.MessageSources.Add(source);
            source.Accounts.Add(account);

            await _context.SaveChangesAsync(cancellationToken);

            return account.AsDto();
        }

        public async Task<EmailMessageDto> CreateEmailMessageAsync(Guid emailSourceId, string text, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(text, nameof(text));

            var source = await _context.EmailSources.GetEntityAsync(emailSourceId, cancellationToken);
            var message = new EmailMessage(Guid.NewGuid(), DateTime.Now, MessageState.New, text);
            source.EmailMessages.Add(message);

            _context.EmailMessages.Add(message);
            await _context.SaveChangesAsync(cancellationToken);

            return message.AsDto();
        }

        public async Task<PhoneMessageDto> CreatePhoneMessageAsync(Guid phoneSourceId, string text, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(text, nameof(text));

            var source = await _context.PhoneSources.GetEntityAsync(phoneSourceId, cancellationToken);
            var message = new PhoneMessage(Guid.NewGuid(), DateTime.Now, MessageState.New, text);
            source.PhoneMessages.Add(message);

            _context.PhoneMessages.Add(message);
            await _context.SaveChangesAsync(cancellationToken);

            return message.AsDto();
        }

        public async Task<MessengerMessageDto> CreateMessengerMessageAsync(Guid messengerSourceId, string text, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(text, nameof(text));

            var source = await _context.MessengerSources.GetEntityAsync(messengerSourceId, cancellationToken);
            var message = new MessengerMessage(Guid.NewGuid(), DateTime.Now, MessageState.New, text);
            source.MessengerMessages.Add(message);

            _context.MessengerMessages.Add(message);
            await _context.SaveChangesAsync(cancellationToken);

            return message.AsDto();
        }
    }
}
