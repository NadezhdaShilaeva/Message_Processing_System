using Application.Dto;

namespace Application.Services
{
    public interface IManagerService
    {
        Task<IReadOnlyCollection<Guid>> FindReportsAsync(Guid accountId, DateTime dateTime, CancellationToken cancellationToken);
        Task<ReportDto> GetReportAsync(Guid accountId, Guid reportId, CancellationToken cancellationToken);
        Task<ReportDto> CreateReportAsync(Guid accountId, Guid managerId, TimeSpan interval, CancellationToken cancellationToken);
    }
}
