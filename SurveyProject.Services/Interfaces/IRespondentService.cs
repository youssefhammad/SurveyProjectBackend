using SurveyProject.Core.DTOs.Respondent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyProject.Services.Interfaces
{
    public interface IRespondentService
    {
        Task<ReadRespondentDTO> CreateRespondentAsync(CreateRespondentDTO createRespondentDTO);
    }
}
