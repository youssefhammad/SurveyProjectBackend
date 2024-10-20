using SurveyProject.Core.DTOs.Option;

namespace SurveyProject.Core.DTOs.Question
{
    public class ReadQuestionDTO
    {
        public int Id { get; set; }

        public string QuestionText { get; set; }

        public int QuestionTypeId { get; set; }

        public string QuestionTypeName { get; set; }

        public int Order { get; set; }

        public bool Required { get; set; }

        public List<ReadOptionDTO> Options { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
