using Application.Dto;
using DataAccess.Models;

namespace Application.Mapping
{
    public static class ReportMapping
    {
        public static ReportDto AsDto(this Report report)
        {
            return new ReportDto(report.Id, report.DateTime, report.Interval, report.ManagerId,
                report.CountOfProcessedMessages, report.CountOfReceivedMessages, report.TotalCountOfMessages);
        }
    }
}
