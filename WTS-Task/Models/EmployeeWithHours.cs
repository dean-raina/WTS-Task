using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WTS_Task.Models
{
    public class EmployeeWithHours
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public int MonthlyHours { get; set; }
    }
}
