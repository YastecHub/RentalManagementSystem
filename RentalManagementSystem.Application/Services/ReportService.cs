using RentalManagementSystem.Application.Abstractions.Reposittories;
using RentalManagementSystem.Application.Abstractions.Services;
using RentalManagementSystem.Application.DTOs;

namespace RentalManagementSystem.Application.Services
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportRepository;

        public ReportService(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        public async Task<ResponseModel<IEnumerable<ReportDto>>> GenerateDailyReport(DateTime date)
        {
            try
            {
                var reports = await _reportRepository.GetDailyReport(date);
                var reportDtos = reports.Select(report => new ReportDto
                {
                    Id = report.Id,
                    ReportName = report.ReportName,
                    GeneratedDate = report.GeneratedDate,
                    GeneratedByUserId = report.GeneratedByUserId.ToString(),
                    StartDate = report.StartDate,
                    EndDate = report.EndDate,
                    TotalRentalRequests = report.TotalRentalRequests,
                    TotalRevenue = report.TotalRevenue
                });

                return new ResponseModel<IEnumerable<ReportDto>>
                {
                    IsSuccessful = true,
                    Data = reportDtos,
                    Message = $"Daily reports for {date.ToShortDateString()} generated successfully."
                };
            }
            catch (Exception)
            {
                return new ResponseModel<IEnumerable<ReportDto>>
                {
                    IsSuccessful = false,
                    Message = "Failed to generate daily report. Please try again."
                };
            }
        }

        public async Task<ResponseModel<IEnumerable<ReportDto>>> GenerateWeeklyReport(DateTime startOfWeek)
        {
            try
            {
                var reports = await _reportRepository.GetWeeklyReport(startOfWeek);
                var reportDtos = reports.Select(report => new ReportDto
                {
                    Id = report.Id,
                    ReportName = report.ReportName,
                    GeneratedDate = report.GeneratedDate,
                    GeneratedByUserId = report.GeneratedByUserId.ToString(),
                    StartDate = report.StartDate,
                    EndDate = report.EndDate,
                    TotalRentalRequests = report.TotalRentalRequests,
                    TotalRevenue = report.TotalRevenue
                });

                return new ResponseModel<IEnumerable<ReportDto>>
                {
                    IsSuccessful = true,
                    Data = reportDtos,
                    Message = $"Weekly reports starting from {startOfWeek.ToShortDateString()} generated successfully."
                };
            }
            catch (Exception)
            {
                return new ResponseModel<IEnumerable<ReportDto>>
                {
                    IsSuccessful = false,
                    Message = "Failed to generate weekly report. Please try again."
                };
            }
        }

        public async Task<ResponseModel<IEnumerable<ReportDto>>> GenerateMontlyReport(int year, int month)
        {
            try
            {
                var reports = await _reportRepository.GetMontlyReport(year, month);
                var reportDtos = reports.Select(report => new ReportDto
                {
                    Id = report.Id,
                    ReportName = report.ReportName,
                    GeneratedDate = report.GeneratedDate,
                    GeneratedByUserId = report.GeneratedByUserId.ToString(),
                    StartDate = report.StartDate,
                    EndDate = report.EndDate,
                    TotalRentalRequests = report.TotalRentalRequests,
                    TotalRevenue = report.TotalRevenue
                });

                return new ResponseModel<IEnumerable<ReportDto>>
                {
                    IsSuccessful = true,
                    Data = reportDtos,
                    Message = $"Monthly reports for {month}/{year} generated successfully."
                };
            }
            catch (Exception)
            {
                return new ResponseModel<IEnumerable<ReportDto>>
                {
                    IsSuccessful = false,
                    Message = "Failed to generate monthly report. Please try again."
                };
            }
        }

        public async Task<ResponseModel<IEnumerable<ReportDto>>> GenerateYearlyReport(int year)
        {
            try
            {
                var reports = await _reportRepository.GetYearlyReport(year);
                var reportDtos = reports.Select(report => new ReportDto
                {
                    Id = report.Id,
                    ReportName = report.ReportName,
                    GeneratedDate = report.GeneratedDate,
                    GeneratedByUserId = report.GeneratedByUserId.ToString(),
                    StartDate = report.StartDate,
                    EndDate = report.EndDate,
                    TotalRentalRequests = report.TotalRentalRequests,
                    TotalRevenue = report.TotalRevenue
                });

                return new ResponseModel<IEnumerable<ReportDto>>
                {
                    IsSuccessful = true,
                    Data = reportDtos,
                    Message = $"Yearly reports for {year} generated successfully."
                };
            }
            catch (Exception)
            {
                return new ResponseModel<IEnumerable<ReportDto>>
                {
                    IsSuccessful = false,
                    Message = "Failed to generate yearly report. Please try again."
                };
            }
        }

        public async Task<ResponseModel<IEnumerable<ReportDto>>> GenerateReportWithinDateRange(DateTime startDate, DateTime endDate)
        {
            try
            {
                var reports = await _reportRepository.GetReportWithinDateRange(startDate, endDate);
                var reportDtos = reports.Select(report => new ReportDto
                {
                    Id = report.Id,
                    ReportName = report.ReportName,
                    GeneratedDate = report.GeneratedDate,
                    GeneratedByUserId = report.GeneratedByUserId.ToString(),
                    StartDate = report.StartDate,
                    EndDate = report.EndDate,
                    TotalRentalRequests = report.TotalRentalRequests,
                    TotalRevenue = report.TotalRevenue
                });

                return new ResponseModel<IEnumerable<ReportDto>>
                {
                    IsSuccessful = true,
                    Data = reportDtos,
                    Message = $"Reports from {startDate.ToShortDateString()} to {endDate.ToShortDateString()} generated successfully."
                };
            }
            catch (Exception)
            {
                return new ResponseModel<IEnumerable<ReportDto>>
                {
                    IsSuccessful = false,
                    Message = "Failed to generate report within date range. Please try again."
                };
            }
        }

        public async Task<ResponseModel<IEnumerable<ReportDto>>> GenerateReportsByUserId(Guid userId)
        {
            try
            {
                var reports = await _reportRepository.GetReportsByUserId(userId);
                var reportDtos = reports.Select(report => new ReportDto
                {
                    Id = report.Id,
                    ReportName = report.ReportName,
                    GeneratedDate = report.GeneratedDate,
                    GeneratedByUserId = report.GeneratedByUserId.ToString(),
                    StartDate = report.StartDate,
                    EndDate = report.EndDate,
                    TotalRentalRequests = report.TotalRentalRequests,
                    TotalRevenue = report.TotalRevenue
                });

                return new ResponseModel<IEnumerable<ReportDto>>
                {
                    IsSuccessful = true,
                    Data = reportDtos,
                    Message = $"Reports for user with ID {userId} generated successfully."
                };
            }
            catch (Exception)
            {
                return new ResponseModel<IEnumerable<ReportDto>>
                {
                    IsSuccessful = false,
                    Message = "Failed to generate reports for the user. Please try again."
                };
            }
        }
    }
}
