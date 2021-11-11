using System;
using System.Collections.Generic;

#nullable disable

namespace employee_UEPFeedbackformWebAPI.model
{
    public partial class Employee
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpEmail { get; set; }
        public string Pwd { get; set; }
        public int? ProjectId { get; set; }
        public int? FeedbackGiven { get; set; }
    }
}
