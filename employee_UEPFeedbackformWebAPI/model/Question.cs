using System;
using System.Collections.Generic;

#nullable disable

namespace employee_UEPFeedbackformWebAPI.model
{
    public partial class Question
    {
        public int QuestionId { get; set; }
        public int CategoryId { get; set; }
        public string QuestionName { get; set; }
        public int? ObjectiveType { get; set; }
        public int? AnswerId { get; set; }
    }
}
