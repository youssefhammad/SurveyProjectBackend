using AutoMapper;
using SurveyProject.Core.DTOs.Respondent;
using SurveyProject.Core.Entities;
using SurveyProject.Core.Interfaces;
using SurveyProject.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyProject.Services.Implementations
{
    public class RespondentService : IRespondentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RespondentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ReadRespondentDTO> CreateRespondentAsync(CreateRespondentDTO createRespondentDTO)
        {
            // Ensure Survey exists
            var survey = await _unitOfWork.Surveys.GetByIdAsync(createRespondentDTO.SurveyId);
            if (survey == null)
            {
                return new ReadRespondentDTO();
            }

            try
            {
                // Map Respondent
                var respondent = _mapper.Map<Respondent>(createRespondentDTO);
                respondent.StartedAt = DateTime.UtcNow;
                respondent.CompletedAt = DateTime.UtcNow;

                // Create responses list
                var responses = new List<Response>();

                if (createRespondentDTO.Responses != null && createRespondentDTO.Responses.Any())
                {
                    foreach (var respDTO in createRespondentDTO.Responses)
                    {
                        // Validate Question belongs to the Survey
                        var question = await _unitOfWork.Questions.GetByIdAsync(respDTO.QuestionId);
                        if (question == null || question.SurveyId != createRespondentDTO.SurveyId)
                        {
                            throw new ValidationException($"Invalid question id {respDTO.QuestionId} for survey {createRespondentDTO.SurveyId}");
                        }

                        var response = new Response
                        {
                            Respondent = respondent,
                            QuestionId = respDTO.QuestionId,
                            ValueText = null,
                            ValueNumber = null,
                            ValueBoolean = null,
                            ValueDate = null,
                            OptionId = null
                        };

                        if (!string.IsNullOrEmpty(respDTO.ValueText))
                        {
                            response.ValueText = respDTO.ValueText;
                        }
                        else if (!string.IsNullOrEmpty(respDTO.ValueNumber))
                        {
                            if (decimal.TryParse(respDTO.ValueNumber, out decimal numberValue))
                            {
                                response.ValueNumber = numberValue;
                            }
                            else
                            {
                                throw new ValidationException($"Invalid number value for question {respDTO.QuestionId}");
                            }
                        }
                        else if (!string.IsNullOrEmpty(respDTO.ValueBoolean))
                        {
                            if (bool.TryParse(respDTO.ValueBoolean, out bool boolValue))
                            {
                                response.ValueBoolean = boolValue;
                            }
                            else
                            {
                                throw new ValidationException($"Invalid boolean value for question {respDTO.QuestionId}");
                            }
                        }
                        else if (!string.IsNullOrEmpty(respDTO.ValueDate))
                        {
                            if (DateTime.TryParse(respDTO.ValueDate, out DateTime dateValue))
                            {
                                response.ValueDate = dateValue;
                            }
                            else
                            {
                                throw new ValidationException($"Invalid date value for question {respDTO.QuestionId}");
                            }
                        }
                        else if (respDTO.OptionId.HasValue)
                        {
                            var option = await _unitOfWork.Options.GetByIdAsync(respDTO.OptionId.Value);
                            if (option == null || option.QuestionId != respDTO.QuestionId)
                            {
                                throw new ValidationException($"Invalid option id {respDTO.OptionId} for question {respDTO.QuestionId}");
                            }
                            response.OptionId = respDTO.OptionId;
                        }

                        responses.Add(response);
                    }
                }

                respondent.Responses = responses;

                await _unitOfWork.Respondents.InsertAsync(respondent);

                await _unitOfWork.CommitAsync();

                var createdRespondent = await _unitOfWork.Respondents.GetAllAsync(
                    filter: r => r.Id == respondent.Id,
                    includeProperties: "Survey,Responses,Responses.Question,Responses.Option");

                var mappedRespondent = _mapper.Map<ReadRespondentDTO>(createdRespondent.FirstOrDefault());

                return mappedRespondent;
            }
            catch (Exception ex)
            {
                throw; 
            }
        }
    }
}
