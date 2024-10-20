using SurveyProject.Core.DTOs.Response;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyProject.Core.DTOs.Respondent
{
    public class CreateRespondentDTO
    {
        [Required]
        public int SurveyId { get; set; }

        public string Metadata { get; set; }

        public List<CreateResponseDTO> Responses { get; set; }
    }
}
