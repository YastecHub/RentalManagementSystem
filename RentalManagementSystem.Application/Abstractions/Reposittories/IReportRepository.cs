using RentalManagementSystem.Entities;

namespace RentalManagementSystem.Application.Abstractions.Reposittories
{
    public interface IReportRepository
    {

        Task<IEnumerable<Report>> GetDailyReport(DateTime date);

        Task<IEnumerable<Report>> GetWeeklyReport(DateTime startOfWeek);

        Task<IEnumerable<Report>> GetMontlyReport(int year, int month);

        Task<IEnumerable<Report>> GetYearlyReport(int year);

        Task<IEnumerable<Report>> GetReportWithinDateRange(DateTime startDate, DateTime endDate);

        Task<IEnumerable<Report>> GetReportsByUserId(Guid userId);
    }
}
