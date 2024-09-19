using RentalManagementSystem.Entities;

namespace RentalManagementSystem.Application.DTOs
{
    public class ReportDto
    {
        public Guid Id { get; set; }
        public string ReportName { get; set; }
        public DateTime GeneratedDate { get; set; }
        public string GeneratedByUserId { get; set; }
        public User GeneratedByUser { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int TotalRentalRequests { get; set; }
        public decimal TotalRevenue { get; set; }
    }

    public class CreateReportDto
    {
        public string ReportName { get; set; }
        public DateTime GeneratedDate { get; set; }
        public string GeneratedByUserId { get; set; }
        public User GeneratedByUser { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int TotalRentalRequests { get; set; }
        public decimal TotalRevenue { get; set; }
    }

    public class UpdateReportDto
    {
        public Guid Id { get; set; }
        public string ReportName { get; set; }
        public DateTime GeneratedDate { get; set; }
        public string GeneratedByUserId { get; set; }
        public User GeneratedByUser { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int TotalRentalRequests { get; set; }
        public decimal TotalRevenue { get; set; }
    }
}
