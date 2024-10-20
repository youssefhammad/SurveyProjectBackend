using SurveyProject.Core.DTOs.QuestionType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyProject.Services.Interfaces
{
    public interface IQuestionTypeService
    {
        Task<IEnumerable<ReadQuestionTypeDTO>> GetAllQuestionTypesAsync();
        Task<ReadQuestionTypeDTO> GetQuestionTypeByIdAsync(int id);
        Task<ReadQuestionTypeDTO> CreateQuestionTypeAsync(CreateQuestionTypeDTO createQuestionTypeDTO);
        Task<bool> UpdateQuestionTypeAsync(int id, UpdateQuestionTypeDTO updateQuestionTypeDTO);
        Task<bool> DeleteQuestionTypeAsync(int id);
    }
}
