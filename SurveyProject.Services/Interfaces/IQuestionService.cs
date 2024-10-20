using SurveyProject.Core.DTOs.Question;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyProject.Services.Interfaces
{
    public interface IQuestionService
    {
        Task<IEnumerable<ReadQuestionDTO>> GetQuestionsBySurveyIdAsync(int surveyId);
        Task<ReadQuestionDTO> GetQuestionByIdAsync(int id);
        Task<ReadQuestionDTO> CreateQuestionAsync(int surveyId, CreateQuestionDTO createQuestionDTO);
        Task<bool> UpdateQuestionAsync(int id, UpdateQuestionDTO updateQuestionDTO);
        Task<bool> DeleteQuestionAsync(int id);
    }
}
