using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyProject.Core.Entities
{
    public class Response : BaseEntity
    {
        [ForeignKey("Respondent")]
        public int RespondentId { get; set; }
        public Respondent Respondent { get; set; }

        [ForeignKey("Question")]
        public int QuestionId { get; set; }
        public Question Question { get; set; }

        [ForeignKey("Option")]
        public int? OptionId { get; set; }
        public Option Option { get; set; }
        public string? ValueText { get; set; }
        public decimal? ValueNumber { get; set; }
        public bool? ValueBoolean { get; set; }
        public DateTime? ValueDate { get; set; }
    }
}
