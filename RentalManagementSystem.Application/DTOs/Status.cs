using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalManagementSystem.Application.DTOs
{
    public class Status
    {
        public int StatusCode { get; set; } 
        public string Message { get; set; }  
        public string? Token { get; set; }
        public object? Data { get; set; }

        public Status()
        {
            StatusCode = 0; 
            Message = string.Empty;
        }
    }
}
