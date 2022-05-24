using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WTS_Task.DataDB;
using WTS_Task.Models;

namespace WTS_Task.Methods
{
    public class Employee
    {
        WTSDBContext wTSDBContext = new WTSDBContext();

        public List<EmployeeWithHours> GetAllEmployeesWithHours() 
        {
            List<EmployeeWithHours> employeesWithHours = new List<EmployeeWithHours>();
            Employee_Works_Shift employee_Works_Shift = new Employee_Works_Shift();

            var employees = wTSDBContext.Employees.ToList();

            foreach (var employee in employees) 
            {
                EmployeeWithHours employeeWithHours = new EmployeeWithHours();

                employeeWithHours.EmployeeId = employee.EmployeeId;
                employeeWithHours.FirstName = employee.FirstName;
                employeeWithHours.Surname = employee.Surname;
                employeeWithHours.MonthlyHours = employee_Works_Shift.GetEmployeeHoursPerMonth(employee.EmployeeId);

                employeesWithHours.Add(employeeWithHours);
            }

            return employeesWithHours;
        }
    }
}
