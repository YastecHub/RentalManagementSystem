using RentalManagementSystem.Domain.Entities.Contracts;

namespace RentalManagementSystem.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }

        public double RentalPrice { get; set; }

        public string? Description { get; set; }

        public int StockQuantity { get; set; }

        public bool Available { get; set; }
    }
}

