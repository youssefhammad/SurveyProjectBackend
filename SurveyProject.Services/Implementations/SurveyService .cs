using AutoMapper;
using SurveyProject.Core.DTOs.Survey;
using SurveyProject.Core.Entities;
using SurveyProject.Core.Interfaces;
using SurveyProject.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyProject.Services.Implementations
{
    public class SurveyService : ISurveyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SurveyService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ReadSurveyDTO>> GetAllSurveysAsync()
        {
            var surveys = await _unitOfWork.Surveys.GetAllAsync(
                includeProperties: "Questions,Questions.QuestionType,Questions.Options");
            return _mapper.Map<IEnumerable<ReadSurveyDTO>>(surveys);
        }

        public async Task<ReadSurveyDTO> GetSurveyByIdAsync(int id)
        {
            var surveys = await _unitOfWork.Surveys.GetAllAsync(
                filter: s => s.Id == id,
                includeProperties: "Questions,Questions.QuestionType,Questions.Options");
            var survey = surveys.FirstOrDefault();
            return _mapper.Map<ReadSurveyDTO>(survey);
        }

        public async Task<ReadSurveyDTO> CreateSurveyAsync(CreateSurveyDTO createSurveyDTO)
        {
            var survey = _mapper.Map<Survey>(createSurveyDTO);
            await _unitOfWork.Surveys.InsertAsync(survey);
            await _unitOfWork.CommitAsync();

            // Fetch the created survey with related data
            var createdSurvey = await GetSurveyByIdAsync(survey.Id);
            return createdSurvey;
        }

        public async Task<bool> UpdateSurveyAsync(int id, UpdateSurveyDTO updateSurveyDTO)
        {
            var survey = await _unitOfWork.Surveys.GetByIdAsync(id);
            if (survey == null)
            {
                return false;
            }

            // Map the updated fields
            _mapper.Map(updateSurveyDTO, survey);
            _unitOfWork.Surveys.Update(survey);
            await _unitOfWork.CommitAsync();

            return true;
        }

        public async Task<bool> DeleteSurveyAsync(int id)
        {
            var survey = await _unitOfWork.Surveys.GetByIdAsync(id);
            if (survey == null)
            {
                return false;
            }

            _unitOfWork.Surveys.Delete(survey);
            await _unitOfWork.CommitAsync();
            return true;
        }
    }
}
