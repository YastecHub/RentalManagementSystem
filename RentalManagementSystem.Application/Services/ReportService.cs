using RentalManagementSystem.Application.Abstractions.Reposittories;
using RentalManagementSystem.Application.Abstractions.Services;
using RentalManagementSystem.Application.DTOs;
using RentalManagementSystem.Entities;

namespace RentalManagementSystem.Application.Services
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportRepository;

        public ReportService(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        public async Task<ResponseModel<ReportDto>> CreateReport(CreateReportDto createReportDto)
        {
            try
            {
                var report = new Report
                {
                    Id = Guid.NewGuid(),
                    ReportName = createReportDto.ReportName,
                    GeneratedDate = DateTime.Now,
                    GeneratedByUserId = Guid.Parse(createReportDto.GeneratedByUserId),
                    StartDate = createReportDto.StartDate,
                    EndDate = createReportDto.EndDate,
                    TotalRentalRequests = createReportDto.TotalRentalRequests,
                    TotalRevenue = createReportDto.TotalRevenue,
                };

                var addedReport = await _reportRepository.AddReport(report);

                var reportDto = new ReportDto
                {
                    Id = addedReport.Id,
                    ReportName = addedReport.ReportName,
                    GeneratedDate = addedReport.GeneratedDate,
                    GeneratedByUserId = addedReport.GeneratedByUserId.ToString(),
                    StartDate = addedReport.StartDate,
                    EndDate = addedReport.EndDate,
                    TotalRentalRequests = addedReport.TotalRentalRequests,
                    TotalRevenue = addedReport.TotalRevenue,
                };

                return new ResponseModel<ReportDto>
                {
                    IsSuccessful = true,
                    Data = reportDto,
                    Message = "Report created successfully"
                };
            }
            catch (Exception)
            {
                return new ResponseModel<ReportDto>
                {
                    IsSuccessful = false,
                    Message = "Failed to create the report. Please try again."
                };
            }
        }

        public async Task<ResponseModel> DeleteReport(Guid reportId)
        {
            try
            {
                var report = await _reportRepository.GetReportById(reportId);
                if (report == null)
                {
                    return new ResponseModel
                    {
                        IsSuccessful = false,
                        Message = "Report not found"
                    };
                }

                await _reportRepository.DeleteReport(reportId);

                return new ResponseModel
                {
                    IsSuccessful = true,
                    Message = "Report deleted successfully"
                };
            }
            catch (Exception)
            {
                return new ResponseModel
                {
                    IsSuccessful = false,
                    Message = "Failed to delete the report. Please try again."
                };
            }
        }

        public async Task<ResponseModel<IEnumerable<ReportDto>>> GetAllReports()
        {
            try
            {
                var reports = await _reportRepository.GetAllReports();

                var reportDtos = reports.Select(report => new ReportDto
                {
                    Id = report.Id,
                    ReportName = report.ReportName,
                    GeneratedDate = report.GeneratedDate,
                    GeneratedByUserId = report.GeneratedByUserId.ToString(),
                    StartDate = report.StartDate,
                    EndDate = report.EndDate,
                    TotalRentalRequests = report.TotalRentalRequests,
                    TotalRevenue = report.TotalRevenue,
                }).ToList();

                return new ResponseModel<IEnumerable<ReportDto>>
                {
                    IsSuccessful = true,
                    Data = reportDtos,
                    Message = "Reports retrieved successfully"
                };
            }
            catch (Exception)
            {
                return new ResponseModel<IEnumerable<ReportDto>>
                {
                    IsSuccessful = false,
                    Message = "Failed to retrieve reports. Please try again."
                };
            }
        }

        public async Task<ResponseModel<ReportDto>> GetReportById(Guid reportId)
        {
            try
            {
                var report = await _reportRepository.GetReportById(reportId);
                if (report == null)
                {
                    return new ResponseModel<ReportDto>
                    {
                        IsSuccessful = false,
                        Message = "Report not found"
                    };
                }

                var reportDto = new ReportDto
                {
                    Id = report.Id,
                    ReportName = report.ReportName,
                    GeneratedByUserId = report.GeneratedByUserId.ToString(),
                    GeneratedDate = report.GeneratedDate,
                    StartDate = report.StartDate,
                    EndDate = report.EndDate,
                    TotalRentalRequests = report.TotalRentalRequests,
                    TotalRevenue = report.TotalRevenue,
                };

                return new ResponseModel<ReportDto>
                {
                    IsSuccessful = true,
                    Message = $"Report with {report.ReportName} retrieved successfully",
                    Data = reportDto
                };
            }
            catch (Exception)
            {
                return new ResponseModel<ReportDto>
                {
                    IsSuccessful = false,
                    Message = "Failed to retrieve the report. Please try again."
                };
            }
        }

        public async Task<ResponseModel<IEnumerable<ReportDto>>> GetReportsByUserId(Guid userId)
        {
            try
            {
                var reports = await _reportRepository.GetReportByUserId(userId);

                var reportDtos = reports.Select(report => new ReportDto
                {
                    Id = report.Id,
                    ReportName = report.ReportName,
                    GeneratedDate = report.GeneratedDate,
                    GeneratedByUserId = report.GeneratedByUserId.ToString(),
                    StartDate = report.StartDate,
                    EndDate = report.EndDate,
                    TotalRentalRequests = report.TotalRentalRequests,
                    TotalRevenue = report.TotalRevenue,
                }).ToList();

                return new ResponseModel<IEnumerable<ReportDto>>
                {
                    IsSuccessful = true,
                    Data = reportDtos,
                    Message = $"Reports for user with ID {userId} retrieved successfully"
                };
            }
            catch (Exception)
            {
                return new ResponseModel<IEnumerable<ReportDto>>
                {
                    IsSuccessful = false,
                    Message = "Failed to retrieve reports for the user. Please try again."
                };
            }
        }

        public async Task<ResponseModel<IEnumerable<ReportDto>>> GetReportsWithinDateRange(DateTime startDate, DateTime endDate)
        {
            try
            {
                var reports = await _reportRepository.GetReportWithinDateRange(startDate, endDate);

                var reportDtos = reports.Select(report => new ReportDto
                {
                    Id = report.Id,
                    ReportName = report.ReportName,
                    GeneratedByUserId = report.GeneratedByUserId.ToString(),
                    GeneratedDate = report.GeneratedDate,
                    StartDate = report.StartDate,
                    EndDate = report.EndDate,
                    TotalRentalRequests = report.TotalRentalRequests,
                    TotalRevenue = report.TotalRevenue,
                }).ToList();

                return new ResponseModel<IEnumerable<ReportDto>>
                {
                    IsSuccessful = true,
                    Data = reportDtos,
                    Message = $"Reports within {startDate} and {endDate} retrieved successfully"
                };
            }
            catch (Exception)
            {
                return new ResponseModel<IEnumerable<ReportDto>>
                {
                    IsSuccessful = false,
                    Message = "Failed to retrieve reports. Please try again."
                };
            }
        }

        public async Task<ResponseModel<bool>> ReportExists(Guid reportId)
        {
            try
            {
                var exists = await _reportRepository.ReportExists(reportId);

                return new ResponseModel<bool>
                {
                    IsSuccessful = exists,
                    Data = exists,
                    Message = exists ? "Report exists" : "Report does not exist"
                };
            }
            catch (Exception)
            {
                return new ResponseModel<bool>
                {
                    IsSuccessful = false,
                    Message = "Failed to check if the report exists. Please try again."
                };
            }
        }

        public async Task<ResponseModel<ReportDto>> UpdateReport(UpdateReportDto updateReportDto)
        {
            try
            {
                var existingReport = await _reportRepository.GetReportById(updateReportDto.Id);
                if (existingReport == null)
                {
                    return new ResponseModel<ReportDto>
                    {
                        IsSuccessful = false,
                        Message = "Report not found"
                    };
                }

                existingReport.ReportName = updateReportDto.ReportName;
                existingReport.GeneratedDate = updateReportDto.GeneratedDate;
                existingReport.GeneratedByUserId = Guid.Parse(updateReportDto.GeneratedByUserId);
                existingReport.StartDate = updateReportDto.StartDate;
                existingReport.EndDate = updateReportDto.EndDate;
                existingReport.TotalRevenue = updateReportDto.TotalRevenue;
                existingReport.TotalRentalRequests = updateReportDto.TotalRentalRequests;

                await _reportRepository.UpdateReport(existingReport);

                var reportDto = new ReportDto
                {
                    Id = existingReport.Id,
                    ReportName = existingReport.ReportName,
                    GeneratedByUserId = existingReport.GeneratedByUserId.ToString(),
                    StartDate = existingReport.StartDate,
                    EndDate = existingReport.EndDate,
                    TotalRentalRequests = existingReport.TotalRentalRequests,
                    TotalRevenue = existingReport.TotalRevenue,
                };

                return new ResponseModel<ReportDto>
                {
                    IsSuccessful = true,
                    Data = reportDto,
                    Message = "Report updated successfully"
                };
            }
            catch (Exception)
            {
                return new ResponseModel<ReportDto>
                {
                    IsSuccessful = false,
                    Message = "Failed to update the report. Please try again."
                };
            }
        }
    }
}
