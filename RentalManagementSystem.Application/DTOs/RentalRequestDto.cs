using RentalManagementSystem.Enum;

namespace RentalManagementSystem.Application.DTOs
{
    public class RentalRequestDto
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public Guid ProductId { get; set; }

        public RentalPeriod RentalPeriod { get; set; }

        public DateTime RentalStartDate { get; set; }

        public DateTime RentalEndDate { get; set; }

        public RentalStatus Status { get; set; }
    }

    public class CreateRentalRequestDto
    {

        public Guid UserId { get; set; }

        public Guid ProductId { get; set; }

        public RentalPeriod RentalPeriod { get; set; }

        public DateTime RentalStartDate { get; set; }

        public DateTime RentalEndDate { get; set; }

        public RentalStatus Status { get; set; }
    }


    public class UpdateRentalRequestDto
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public Guid ProductId { get; set; }

        public RentalPeriod RentalPeriod { get; set; }

        public DateTime RentalStartDate { get; set; }

        public DateTime RentalEndDate { get; set; }

        public RentalStatus Status { get; set; }
    }
}
