using RentalManagementSystem.Domain.Entities.Contracts;
using RentalManagementSystem.Enum;

namespace RentalManagementSystem.Entities
{
    public class RentalRequest : BaseEntity
    {
        public string UserId { get; set; }
        public User User { get; set; }

        public string ProductId { get; set; }

        public Product Product { get; set; }

        public RentalPeriod RentalPeriod { get; set; }

        public DateTime RentalStartDate { get; set; }

        public DateTime RentalEndDate { get; set; }

        public RentalStatus Status { get; set; }
    }
}
