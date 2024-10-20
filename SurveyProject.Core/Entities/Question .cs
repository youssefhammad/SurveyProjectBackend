using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyProject.Core.Entities
{
    public class Question : BaseEntity
    {
        [Required]
        public string QuestionText { get; set; }

        [ForeignKey("Survey")]
        public int SurveyId { get; set; }
        public Survey Survey { get; set; }

        [ForeignKey("QuestionType")]
        public int QuestionTypeId { get; set; }
        public QuestionType QuestionType { get; set; }

        public int Order { get; set; }

        public bool Required { get; set; }

        public ICollection<Option> Options { get; set; }

        public ICollection<Response> Responses { get; set; }
    }
}
