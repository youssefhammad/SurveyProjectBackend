using SurveyProject.Core.DTOs.Option;
using System.ComponentModel.DataAnnotations;

namespace SurveyProject.Core.DTOs.Question
{
    public class UpdateQuestionDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string QuestionText { get; set; }

        [Required]
        public int QuestionTypeId { get; set; }

        public int Order { get; set; }

        public bool Required { get; set; }

        public List<UpdateOptionDTO> Options { get; set; }
    }
}
