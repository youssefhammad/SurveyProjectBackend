using SurveyProject.Core.DTOs.Response;

namespace SurveyProject.Core.DTOs.Respondent
{
    public class ReadRespondentDTO
    {
        public int Id { get; set; }

        public int SurveyId { get; set; }

        public string SurveyTitle { get; set; }

        public DateTime StartedAt { get; set; }

        public DateTime? CompletedAt { get; set; }

        public string Metadata { get; set; }

        public List<ReadResponseDTO> Responses { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
