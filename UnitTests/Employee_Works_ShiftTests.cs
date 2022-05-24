using NUnit.Framework;
using System;
using WTS_Task.Methods;
using WTS_Task.DataDB;
using System.Linq;
using System.Collections.Generic;

namespace UnitTests
{
    public class Employee_Works_ShiftTests
    {
        WTSDBContext wTSDBContext;
        Employee_Works_Shift employee_Works_Shift;

        EmployeeWorksShift employeeWorksShift;
        List<EmployeeWorksShift> employeeWorksShifts;

        [SetUp]
        public void SetUp() 
        {
            wTSDBContext = new WTSDBContext();
            employee_Works_Shift = new Employee_Works_Shift();
        }

        [Test]
        public void GetEmployeeHoursPerMonth_Works() 
        {
            int totalHoursTest = 0;

            //get random first entry and use it to get rest with same employee id
            employeeWorksShift = wTSDBContext.EmployeeWorksShifts.First();
            employeeWorksShifts = wTSDBContext.EmployeeWorksShifts.Where(e => e.EmployeeId == employeeWorksShift.EmployeeId).ToList();

            foreach (var item in employeeWorksShifts) 
            {
                var shift = wTSDBContext.Shifts.Where(s => s.ShiftId == item.ShiftId).FirstOrDefault();
                int shiftHours = Convert.ToInt32((shift.ShiftEnd - shift.ShiftStart).TotalHours);

                totalHoursTest = totalHoursTest + shiftHours;
            }

            int totalHoursMethod = employee_Works_Shift.GetEmployeeHoursPerMonth(employeeWorksShift.EmployeeId);

            //verify both return same number of hours
            Assert.AreEqual(totalHoursTest, totalHoursMethod);

        }
    }
}
