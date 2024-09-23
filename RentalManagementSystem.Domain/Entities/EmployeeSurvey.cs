using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalManagementSystem.Domain.Entities
{
    public class EmployeeSurvey
    {
        public Guid SurveyId { get; set; }
        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public DateTime SurveyDate { get; set; }

        public int MotivationLevel { get; set; }
        public int GoalAlignment { get; set; }
        public int MoodMorale { get; set; }
        public int ProductivityScore { get; set; }
    }
}
