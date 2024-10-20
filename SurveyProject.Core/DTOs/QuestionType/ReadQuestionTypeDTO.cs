namespace SurveyProject.Core.DTOs.QuestionType
{
    public class ReadQuestionTypeDTO
    {
        public int Id { get; set; }

        public string TypeName { get; set; }

        public string DataType { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
