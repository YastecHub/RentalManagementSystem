using Microsoft.EntityFrameworkCore;
using RentalManagementSystem.Application.Abstractions.Reposittories;
using RentalManagementSystem.Entities;
using RentalManagementSystem.Persistence.Context;

namespace RentalManagementSystem.Persistence.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ReportRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        
        public async Task<IEnumerable<Report>> GetReportWithinDateRange(DateTime startDate, DateTime endDate)
        {
            return await _applicationDbContext.Reports
                .Where(r => r.GeneratedDate >= startDate && r.GeneratedDate <= endDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<Report>> GetReportsByUserId(Guid userId)
        {
           return await _applicationDbContext.Reports
                .Include(r => r.GeneratedByUser)
                .Where(r => r.GeneratedByUserId == userId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Report>> GetDailyReport(DateTime date)
        {
           return await _applicationDbContext.Reports
                .Where(r => r.GeneratedDate.Date == date.Date)
                .ToListAsync();
        }

        public async Task<IEnumerable<Report>> GetWeeklyReport(DateTime startOfWeek)
        {
            var endOfWeek = startOfWeek.AddDays(7);
            return await _applicationDbContext.Reports
                .Where(r => r.GeneratedDate >= startOfWeek && r.GeneratedDate < endOfWeek)
                .ToListAsync();
        }

        public async Task<IEnumerable<Report>> GetMontlyReport(int year, int month)
        {
            return await _applicationDbContext.Reports
                .Where(r => r.GeneratedDate.Year == year  && r.GeneratedDate.Month == month)
                .ToListAsync();
        }

        public async Task<IEnumerable<Report>> GetYearlyReport(int year)
        {
            return await _applicationDbContext.Reports
                .Where(r => r.GeneratedDate.Year == year)
                .ToListAsync();
        }

    }
}
