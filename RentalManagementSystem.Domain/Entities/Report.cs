using RentalManagementSystem.Domain.Entities.Contracts;
using System;

namespace RentalManagementSystem.Entities
{
    public class Report : BaseEntity
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
}
