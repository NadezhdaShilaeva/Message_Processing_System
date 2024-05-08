namespace Presentation.Models.Reports
{
    public record CreateReportModel(Guid managerId, int lastDays, int lastHours, int lastMinutes, int lastSeconds);
}
