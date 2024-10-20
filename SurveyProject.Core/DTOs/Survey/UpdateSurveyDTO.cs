using SurveyProject.Core.DTOs.Question;
using System.ComponentModel.DataAnnotations;

namespace SurveyProject.Core.DTOs.Survey
{
    public class UpdateSurveyDTO
    {
        [Required]
        [MaxLength(255)]
        public string Title { get; set; }

        public string Description { get; set; }

        public List<UpdateQuestionDTO> Questions { get; set; }
    }
}
