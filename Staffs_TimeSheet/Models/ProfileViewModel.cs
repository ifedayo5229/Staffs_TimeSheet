using System.Collections.Generic;
using Staffs_TimeSheet.Data.Entities;

namespace Staffs_TimeSheet.Models
{
    public class ProfileViewModel
    {
        public List<TimeTracker> ClockHistory { get; set; } = new List<TimeTracker>();
        public string UserName { get; set; }
        public string Status { get; set; }
    }
}