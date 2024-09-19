using RentalManagementSystem.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentalManagementSystem.Application.Abstractions.Services
{
    public interface IReportService
    {
        Task<ResponseModel<ReportDto>> CreateReport(CreateReportDto createReportDto);

        Task<ResponseModel<ReportDto>> UpdateReport(UpdateReportDto updateReportDto);

        Task<ResponseModel<ReportDto>> GetReportById(Guid reportId);

        Task<ResponseModel<IEnumerable<ReportDto>>> GetAllReports();

        Task<ResponseModel<IEnumerable<ReportDto>>> GetReportsByUserId(Guid userId);

        Task<ResponseModel<IEnumerable<ReportDto>>> GetReportsWithinDateRange(DateTime startDate, DateTime endDate);

        Task<ResponseModel> DeleteReport(Guid reportId);

        Task<ResponseModel<bool>> ReportExists(Guid reportId);
    }
}
