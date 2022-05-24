using System;
using System.Collections.Generic;

#nullable disable

namespace WTS_Task.DataDB
{
    public partial class EmployeeWorksShift
    {
        public int EmployeeId { get; set; }
        public int ShiftId { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Shift Shift { get; set; }
    }
}
