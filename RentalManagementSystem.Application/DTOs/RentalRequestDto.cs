using RentalManagementSystem.Entities;
using RentalManagementSystem.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalManagementSystem.Application.DTOs
{
    public class RentalRequestDto
    {
        public Guid Id { get; set; }

        public string UserId { get; set; }

        public string ProductId { get; set; }

        public RentalPeriod RentalPeriod { get; set; }

        public DateTime RentalStartDate { get; set; }

        public DateTime RentalEndDate { get; set; }

        public RentalStatus Status { get; set; }
    }
}
