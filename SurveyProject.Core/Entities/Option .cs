using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyProject.Core.Entities
{
    public class Option : BaseEntity
    {
        [Required]
        public string OptionText { get; set; }

        public string Value { get; set; }

        public int Order { get; set; }

        [ForeignKey("Question")]
        public int QuestionId { get; set; }
        public Question Question { get; set; }

        public ICollection<Response> Responses { get; set; }
    }
}
