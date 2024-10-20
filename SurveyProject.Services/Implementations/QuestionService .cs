using AutoMapper;
using SurveyProject.Core.DTOs.Question;
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
    public class QuestionService : IQuestionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public QuestionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ReadQuestionDTO>> GetQuestionsBySurveyIdAsync(int surveyId)
        {
            var questions = await _unitOfWork.Questions.GetAllAsync(
                filter: q => q.SurveyId == surveyId,
                includeProperties: "QuestionType,Options");
            return _mapper.Map<IEnumerable<ReadQuestionDTO>>(questions);
        }

        public async Task<ReadQuestionDTO> GetQuestionByIdAsync(int id)
        {
            var questions = await _unitOfWork.Questions.GetAllAsync(
                filter: q => q.Id == id,
                includeProperties: "QuestionType,Options");
            var question = questions.FirstOrDefault();
            return _mapper.Map<ReadQuestionDTO>(question);
        }

        public async Task<ReadQuestionDTO> CreateQuestionAsync(int surveyId, CreateQuestionDTO createQuestionDTO)
        {
            var survey = await _unitOfWork.Surveys.GetByIdAsync(surveyId);
            if (survey == null)
            {
                return null;
            }

            var question = _mapper.Map<Question>(createQuestionDTO);
            question.SurveyId = surveyId;
            await _unitOfWork.Questions.InsertAsync(question);
            await _unitOfWork.CommitAsync();

            var createdQuestion = await GetQuestionByIdAsync(question.Id);
            return createdQuestion;
        }

        public async Task<bool> UpdateQuestionAsync(int id, UpdateQuestionDTO updateQuestionDTO)
        {
            var question = await _unitOfWork.Questions.GetByIdAsync(id);
            if (question == null)
            {
                return false;
            }

            // Map the updated fields
            _mapper.Map(updateQuestionDTO, question);
            _unitOfWork.Questions.Update(question);
            await _unitOfWork.CommitAsync();

            return true;
        }

        public async Task<bool> DeleteQuestionAsync(int id)
        {
            var question = await _unitOfWork.Questions.GetByIdAsync(id);
            if (question == null)
            {
                return false;
            }

            _unitOfWork.Questions.Delete(question);
            await _unitOfWork.CommitAsync();
            return true;
        }
    }
}
