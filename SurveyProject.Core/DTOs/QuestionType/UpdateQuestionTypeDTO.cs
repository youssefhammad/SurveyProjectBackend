using System.ComponentModel.DataAnnotations;

namespace SurveyProject.Core.DTOs.QuestionType
{
    public class UpdateQuestionTypeDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string TypeName { get; set; }

        [Required]
        [MaxLength(50)]
        public string DataType { get; set; }
    }
}
