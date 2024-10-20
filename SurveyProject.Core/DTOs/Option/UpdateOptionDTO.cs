using System.ComponentModel.DataAnnotations;

namespace SurveyProject.Core.DTOs.Option
{
    public class UpdateOptionDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string OptionText { get; set; }

        public string Value { get; set; }

        public int Order { get; set; }
    }
}
