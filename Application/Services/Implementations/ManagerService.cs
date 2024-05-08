using Application.Dto;
using Application.Exceptions;
using Application.Extensions;
using Application.Mapping;
using DataAccess;
using DataAccess.Models;

namespace Application.Services.Implementations
{
    internal class ManagerService : IManagerService
    {
        private readonly DatabaseContext _context;

        public ManagerService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyCollection<Guid>> FindReportsAsync(Guid accountId, DateTime dateTime, CancellationToken cancellationToken)
        {
            var account = await _context.Accounts.GetEntityAsync(accountId, cancellationToken);
            var reports = account.Reports.Where(r => r.DateTime.Date.Equals(dateTime)).Select(r => r.Id).ToList();

            return reports;
        }

        public async Task<ReportDto> GetReportAsync(Guid accountId, Guid reportId, CancellationToken cancellationToken)
        {
            var account = await _context.Accounts.GetEntityAsync(accountId, cancellationToken);
            var report = account.Reports.FirstOrDefault(r => r.Id == reportId);

            if (report is null)
            {
                throw ReportException.ReportNotFound(reportId);
            }

            return report.AsDto();
        }

        public async Task<ReportDto> CreateReportAsync(Guid accountId, Guid managerId, TimeSpan interval, CancellationToken cancellationToken)
        {
            var account = await _context.Accounts.GetEntityAsync(accountId, cancellationToken);
            var manager = await _context.Managers.GetEntityAsync(managerId, cancellationToken);

            DateTime latestDate = DateTime.Now - interval;

            int countOfProcessedMessages = manager.Subordinates.SelectMany(s => s.Accounts)
                .SelectMany(a => a.MessageSources).SelectMany(s => s.FindMessages())
                .Where(m => m.DateTime >= latestDate && m.MessageState == MessageState.Processed).Count();

            int countOfReceivedMessages = manager.Subordinates.SelectMany(s => s.Accounts)
                .SelectMany(a => a.MessageSources).SelectMany(s => s.FindMessages())
                .Where(m => m.DateTime >= latestDate && m.MessageState == MessageState.Received).Count();

            int totalCountOfMessages = manager.Subordinates.SelectMany(s => s.Accounts).SelectMany(a => a.MessageSources)
                .SelectMany(s => s.FindMessages()).Where(m => m.DateTime >= latestDate).Count();

            var report = new Report(Guid.NewGuid(), DateTime.Now, interval, managerId, countOfProcessedMessages, countOfReceivedMessages, totalCountOfMessages);
            account.Reports.Add(report);

            _context.Reports.Add(report);
            await _context.SaveChangesAsync(cancellationToken);

            return report.AsDto();
        }
    }
}
