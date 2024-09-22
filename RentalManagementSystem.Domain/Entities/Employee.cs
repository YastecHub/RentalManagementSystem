using RentalManagementSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalManagementSystem.Domain.Entities
{
    public class Employee
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }

        public string Position { get; set; }
        public string Department { get; set; }

        public DateTime HireDate { get; set; }

        public User User { get; set; } 
    }
}
