using Application.Dto;
using Application.Exceptions;
using Application.Extensions;
using Application.Mapping;
using DataAccess;
using DataAccess.Models;

namespace Application.Services.Implementations
{
    internal class EmployeeService : IEmployeeService
    {
        private readonly DatabaseContext _context;

        public EmployeeService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyCollection<MessageDto>> FindMessagesAsync(Guid accountId, CancellationToken cancellationToken)
        {
            var account = await _context.Accounts.GetEntityAsync(accountId, cancellationToken);
            var messages = new List<Message>(account.MessageSources.SelectMany(s => s.FindMessages()));

            messages.ForEach(message =>
            {
                if (message.MessageState == MessageState.New)
                {
                    message.MessageState = MessageState.Received;
                }
            });

            await _context.SaveChangesAsync(cancellationToken);

            return messages.Select(message => message.AsDto()).ToList();
        }

        public async Task ProcessMesageAsync(Guid accountId, Guid messageId, Guid employeeId, CancellationToken cancellationToken)
        {
            var account = await _context.Accounts.GetEntityAsync(accountId, cancellationToken);
            var employee = await _context.Employees.GetEntityAsync(employeeId, cancellationToken);
            var message = await _context.Messages.GetEntityAsync(messageId, cancellationToken);
            if (!account.MessageSources.SelectMany(s => s.FindMessages()).Contains(message))
            {
                throw MessageException.CannotProcessed(messageId, employeeId);
            }

            if (message.MessageState == MessageState.New)
            {
                throw MessageException.NotReceived(messageId);
            }

            if (message.MessageState == MessageState.Processed)
            {
                throw MessageException.AlreadyProcessed(messageId);
            }

            message.Employee = employee;
            message.MessageState = MessageState.Processed;

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
