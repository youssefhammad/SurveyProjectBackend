using SurveyProject.Core.DTOs.Question;

namespace SurveyProject.Core.DTOs.Survey
{
    public class ReadSurveyDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public List<ReadQuestionDTO> Questions { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
