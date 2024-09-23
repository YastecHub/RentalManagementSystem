using RentalManagementSystem.Entities;
using System;
using System.Collections.Generic;

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

        public decimal Salary { get; set; }
        public string EmployeeCode { get; set; } 

        public string OfficePhoneNumber { get; set; }
        public string OfficeEmail { get; set; }

        
        public Guid? SupervisorId { get; set; }
        public Employee Supervisor { get; set; }

        public List<WorkHistory> WorkHistories { get; set; } = new List<WorkHistory>();
    }
}
