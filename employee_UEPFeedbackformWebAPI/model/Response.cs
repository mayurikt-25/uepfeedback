using System;
using System.Collections.Generic;

#nullable disable

namespace employee_UEPFeedbackformWebAPI.model
{
    public partial class Response
    {
        public int ResponseId { get; set; }
        public string Empname { get; set; }
        public int? QuestionId { get; set; }
        public string EmpAnswer { get; set; }
        public string EmpComment { get; set; }
    }
}
