using AutoMapper;
using SurveyProject.Core.DTOs.Option;
using SurveyProject.Core.DTOs.Question;
using SurveyProject.Core.DTOs.QuestionType;
using SurveyProject.Core.DTOs.Respondent;
using SurveyProject.Core.DTOs.Response;
using SurveyProject.Core.DTOs.Survey;
using SurveyProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyProject.Core.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Survey, ReadSurveyDTO>()
                .ForMember(dest => dest.Questions, opt => opt.MapFrom(src => src.Questions));

            CreateMap<CreateSurveyDTO, Survey>();

            CreateMap<UpdateSurveyDTO, Survey>();

            CreateMap<Question, ReadQuestionDTO>()
                .ForMember(dest => dest.QuestionTypeName, opt => opt.MapFrom(src => src.QuestionType.TypeName))
                .ForMember(dest => dest.Options, opt => opt.MapFrom(src => src.Options));

            CreateMap<CreateQuestionDTO, Question>();

            CreateMap<UpdateQuestionDTO, Question>();
            
            CreateMap<Option, ReadOptionDTO>();

            CreateMap<CreateOptionDTO, Option>();

            CreateMap<UpdateOptionDTO, Option>();

            CreateMap<QuestionType, ReadQuestionTypeDTO>();

            CreateMap<CreateQuestionTypeDTO, QuestionType>();

            CreateMap<UpdateQuestionTypeDTO, QuestionType>();

            CreateMap<Respondent, ReadRespondentDTO>()
                .ForMember(dest => dest.SurveyTitle, opt => opt.MapFrom(src => src.Survey.Title))
                .ForMember(dest => dest.Responses, opt => opt.MapFrom(src => src.Responses));

            CreateMap<CreateRespondentDTO, Respondent>();
            
            CreateMap<Response, ReadResponseDTO>()
                .ForMember(dest => dest.QuestionText, opt => opt.MapFrom(src => src.Question.QuestionText))
                .ForMember(dest => dest.OptionText, opt => opt.MapFrom(src => src.Option.OptionText));

            CreateMap<CreateResponseDTO, Response>();

        }
    }
}
