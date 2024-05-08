using Application.Dto;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models.Reports;

namespace Presentation.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    [Authorize(Policy = "Manager")]
    public class ManagerController : ControllerBase
    {
        private readonly IManagerService _service;

        public ManagerController(IManagerService service)
        {
            _service = service;
        }

        public CancellationToken CancellationToken => HttpContext.RequestAborted;

        [HttpPost("{accountId:Guid}/searching_reports")]
        public async Task<ActionResult<IReadOnlyCollection<Guid>>> FindReportsAsync(Guid accountId, [FromBody] FindReportsModel model)
        {
            var date = new DateTime(model.year, model.month, model.day);
            var reports = await _service.FindReportsAsync(accountId, date, CancellationToken);
            return Ok(reports);
        }

        [HttpPost("{accountId:Guid}/getting_report")]
        public async Task<ActionResult<ReportDto>> GetReportAsync(Guid accountId, Guid reportId)
        {
            var report = await _service.GetReportAsync(accountId, reportId, CancellationToken);
            return Ok(report);
        }

        [HttpPost("{accountId:Guid}/creating_report")]
        public async Task<ActionResult<ReportDto>> CreateReportAsync(Guid accountId, [FromBody] CreateReportModel model)
        {
            var interval = new TimeSpan(model.lastDays, model.lastHours, model.lastMinutes, model.lastSeconds);
            var report = await _service.CreateReportAsync(accountId, model.managerId, interval, CancellationToken);
            return Ok(report);
        }
    }
}
