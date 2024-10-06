using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentalManagementSystem.Application.Abstractions.Services;

namespace RentalManagementSystem.Hosts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportsController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet("Daily")]
        [Authorize]
        public async Task<IActionResult> GenerateDailyReport([FromQuery] DateTime date)
        {
            var result = await _reportService.GenerateDailyReport(date);
            if (result.IsSuccessful)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("Weekly")]
        [Authorize]
        public async Task<IActionResult> GenerateWeeklyReport([FromQuery] DateTime startOfWeek)
        {
            var result = await _reportService.GenerateWeeklyReport(startOfWeek);
            if (result.IsSuccessful)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("Monthly")]
        [Authorize]
        public async Task<IActionResult> GenerateMonthlyReport([FromQuery] int year, [FromQuery] int month)
        {
            var result = await _reportService.GenerateMontlyReport(year, month);
            if (result.IsSuccessful)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("Yearly")]
        [Authorize]
        public async Task<IActionResult> GenerateYearlyReport([FromQuery] int year)
        {
            var result = await _reportService.GenerateYearlyReport(year);
            if (result.IsSuccessful)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("Range")]
        [Authorize]
        public async Task<IActionResult> GenerateReportWithinDateRange([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var result = await _reportService.GenerateReportWithinDateRange(startDate, endDate);
            if (result.IsSuccessful)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("User/{userId}")]
        [Authorize]
        public async Task<IActionResult> GenerateReportsByUserId([FromRoute] Guid userId)
        {
            var result = await _reportService.GenerateReportsByUserId(userId);
            if (result.IsSuccessful)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
