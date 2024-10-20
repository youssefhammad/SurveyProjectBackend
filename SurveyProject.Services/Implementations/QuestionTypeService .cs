using AutoMapper;
using SurveyProject.Core.DTOs.QuestionType;
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
    public class QuestionTypeService : IQuestionTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public QuestionTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ReadQuestionTypeDTO>> GetAllQuestionTypesAsync()
        {
            var questionTypes = await _unitOfWork.QuestionTypes.GetAllAsync();
            return _mapper.Map<IEnumerable<ReadQuestionTypeDTO>>(questionTypes);
        }

        public async Task<ReadQuestionTypeDTO> GetQuestionTypeByIdAsync(int id)
        {
            var questionType = await _unitOfWork.QuestionTypes.GetByIdAsync(id);
            return _mapper.Map<ReadQuestionTypeDTO>(questionType);
        }

        public async Task<ReadQuestionTypeDTO> CreateQuestionTypeAsync(CreateQuestionTypeDTO createQuestionTypeDTO)
        {
            var questionType = _mapper.Map<QuestionType>(createQuestionTypeDTO);
            await _unitOfWork.QuestionTypes.InsertAsync(questionType);
            await _unitOfWork.CommitAsync();

            return _mapper.Map<ReadQuestionTypeDTO>(questionType);
        }

        public async Task<bool> UpdateQuestionTypeAsync(int id, UpdateQuestionTypeDTO updateQuestionTypeDTO)
        {
            var questionType = await _unitOfWork.QuestionTypes.GetByIdAsync(id);
            if (questionType == null)
            {
                return false;
            }

            _mapper.Map(updateQuestionTypeDTO, questionType);
            _unitOfWork.QuestionTypes.Update(questionType);
            await _unitOfWork.CommitAsync();

            return true;
        }

        public async Task<bool> DeleteQuestionTypeAsync(int id)
        {
            var questionType = await _unitOfWork.QuestionTypes.GetByIdAsync(id);
            if (questionType == null)
            {
                return false;
            }

            _unitOfWork.QuestionTypes.Delete(questionType);
            await _unitOfWork.CommitAsync();
            return true;
        }
    }
}
