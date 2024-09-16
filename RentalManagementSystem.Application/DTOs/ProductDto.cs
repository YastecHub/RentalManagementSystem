using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalManagementSystem.Application.DTOs
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public double RentalPrice { get; set; }

        public string Description { get; set; }

        public int StockQuantity { get; set; }

        public bool Available { get; set; }
    }
}
