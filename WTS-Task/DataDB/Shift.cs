using System;
using System.Collections.Generic;

#nullable disable

namespace WTS_Task.DataDB
{
    public partial class Shift
    {
        public int ShiftId { get; set; }
        public DateTime ShiftStart { get; set; }
        public DateTime ShiftEnd { get; set; }
        public string ShiftName { get; set; }
    }
}
