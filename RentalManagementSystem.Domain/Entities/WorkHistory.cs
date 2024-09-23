using System;

namespace RentalManagementSystem.Domain.Entities
{
    public class WorkHistory
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }

        public string PreviousPosition { get; set; }
        public string PreviousDepartment { get; set; }

        public string NewPosition { get; set; }
        public string NewDepartment { get; set; }

        public DateTime ChangeDate { get; set; }
        public string ReasonForChange { get; set; }

        public Employee Employee { get; set; }
    }
}
