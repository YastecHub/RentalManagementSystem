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
        public async Task<Report> AddReport(Report report)
        {
            await _applicationDbContext.Reports.AddAsync(report);
            await _applicationDbContext.SaveChangesAsync();
            return report;
        }

        public async Task<Report> DeleteReport(Guid reportId)
        {
           var report = await GetReportById(reportId);
            if(report != null)
            {
                _applicationDbContext.Reports.Remove(report);
                await _applicationDbContext.SaveChangesAsync();
            }
            return report;
        }

        public async Task<IEnumerable<Report>> GetAllReports()
        {
            return await _applicationDbContext.Reports
                 .Include(r => r.GeneratedByUser)
                 .ToListAsync();
        }

        public async Task<Report> GetReportById(Guid reportId)
        {
            return await _applicationDbContext.Reports
                 .Include(r => r.GeneratedByUser)
                 .FirstOrDefaultAsync(r => r.Id == reportId);
        }

        public async Task<IEnumerable<Report>> GetReportWithinDateRange(DateTime startDate, DateTime endDate)
        {
            return await _applicationDbContext.Reports
                .Where(r => r.GeneratedDate >= startDate && r.GeneratedDate <= endDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<Report>> GetReportByUserId(Guid userId)
        {
           return await _applicationDbContext.Reports
                .Include(r => r.GeneratedByUser)
                .Where(r => r.GeneratedByUserId == userId)
                .ToListAsync();
        }

        public async Task<bool> ReportExists(Guid reportId)
        {
            return await _applicationDbContext.Reports
                .AnyAsync(r => r.Id == reportId);
        }

        public async Task<Report> UpdateReport(Report report)
        {
           _applicationDbContext.Reports.Update(report);
            await _applicationDbContext.SaveChangesAsync();
            return report;
        }
    }
}
