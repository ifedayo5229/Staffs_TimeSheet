using System;
using System.ComponentModel.DataAnnotations;

namespace Staffs_TimeSheet.Data.Entities
{
    public class TimeTracker
    {
        [Key]
        public int Id { get; set; }
        public string Status { get; set; }
        public string Date { get; set; }
        public DateTime Time { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public string UserId { get; set; }
    }
}