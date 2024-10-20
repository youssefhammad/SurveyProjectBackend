namespace SurveyProject.Core.DTOs.Option
{
    public class ReadOptionDTO
    {
        public int Id { get; set; }

        public string OptionText { get; set; }

        public string Value { get; set; }

        public int Order { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
