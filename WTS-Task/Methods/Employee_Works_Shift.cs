using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WTS_Task.DataDB;
using WTS_Task.Models;

namespace WTS_Task.Methods
{
    public class Employee_Works_Shift
    {
        WTSDBContext wTSDBContext = new WTSDBContext();
        public int GetEmployeeHoursPerMonth(int Employee_ID) 
        {
            int totalHours = 0;
            var employeeWorksShifts = wTSDBContext.EmployeeWorksShifts.Where(e => e.EmployeeId == Employee_ID).ToList();

            foreach (var employeeWorksShift in employeeWorksShifts) 
            {
                Shift shift = wTSDBContext.Shifts.Where(s => s.ShiftId == employeeWorksShift.ShiftId).FirstOrDefault();
                int shiftHours = Convert.ToInt32((shift.ShiftEnd - shift.ShiftStart).TotalHours);

                totalHours = totalHours + shiftHours;
            }
            
            return totalHours;
        }
    }
}
