using RentalManagementSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalManagementSystem.Application.Abstractions.Reposittories
{
    public interface IReportRepository
    {
        Task<Report> GetReportById(Guid reportId);

        Task<IEnumerable<Report>> GetAllReports();

        Task<IEnumerable<Report>> GetReportByUserId(Guid userId);

        Task<IEnumerable<Report>> GetReportWithinDateRange(DateTime startDate, DateTime endDate);

        Task<Report> AddReport(Report report);

        Task<Report> UpdateReport(Report report);

        Task<Report> DeleteReport(Guid reportId);

        Task<bool> ReportExists(Guid reportId);
    }
}
