using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalManagementSystem.Application.DTOs
{
    public class ChangePasswordModelDto
    {
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
