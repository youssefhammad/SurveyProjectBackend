namespace SurveyProject.Core.DTOs.Response
{
    public class ReadResponseDTO
    {
        public int Id { get; set; }

        public int QuestionId { get; set; }

        public string QuestionText { get; set; }

        public int? OptionId { get; set; }

        public string OptionText { get; set; }

        public string ValueText { get; set; }

        public decimal? ValueNumber { get; set; }

        public bool? ValueBoolean { get; set; }

        public DateTime? ValueDate { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
