using SurveyProject.Core.DTOs.Question;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyProject.Core.DTOs.Survey
{
    public class CreateSurveyDTO
    {
        [Required]
        [MaxLength(255)]
        public string Title { get; set; }

        public string Description { get; set; }

        public List<CreateQuestionDTO> Questions { get; set; }
    }
}
