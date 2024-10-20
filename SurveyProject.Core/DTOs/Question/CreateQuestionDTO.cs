using SurveyProject.Core.DTOs.Option;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyProject.Core.DTOs.Question
{
    public class CreateQuestionDTO
    {
        [Required]
        public string QuestionText { get; set; }

        [Required]
        public int QuestionTypeId { get; set; }

        public int Order { get; set; }

        public bool Required { get; set; }

        public List<CreateOptionDTO> Options { get; set; }
    }
}
