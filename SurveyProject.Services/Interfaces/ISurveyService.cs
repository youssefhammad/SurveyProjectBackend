using SurveyProject.Core.DTOs.Survey;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyProject.Services.Interfaces
{
    public interface ISurveyService
    {
        Task<IEnumerable<ReadSurveyDTO>> GetAllSurveysAsync();
        Task<ReadSurveyDTO> GetSurveyByIdAsync(int id);
        Task<ReadSurveyDTO> CreateSurveyAsync(CreateSurveyDTO createSurveyDTO);
        Task<bool> UpdateSurveyAsync(int id, UpdateSurveyDTO updateSurveyDTO);
        Task<bool> DeleteSurveyAsync(int id);
    }
}
