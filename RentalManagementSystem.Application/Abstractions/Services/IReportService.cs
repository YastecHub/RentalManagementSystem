using RentalManagementSystem.Application.DTOs;

namespace RentalManagementSystem.Application.Abstractions.Services
{
    public interface IReportService
    {
        Task<ResponseModel<IEnumerable<ReportDto>>> GenerateDailyReport(DateTime date);

        Task<ResponseModel<IEnumerable<ReportDto>>> GenerateWeeklyReport(DateTime startOfWeek);

        Task<ResponseModel<IEnumerable<ReportDto>>> GenerateMontlyReport(int year, int month);

        Task<ResponseModel<IEnumerable<ReportDto>>> GenerateYearlyReport(int year);

        Task<ResponseModel<IEnumerable<ReportDto>>> GenerateReportWithinDateRange(DateTime startDate, DateTime endDate);

        Task<ResponseModel<IEnumerable<ReportDto>>> GenerateReportsByUserId(Guid userId);
    }
}
