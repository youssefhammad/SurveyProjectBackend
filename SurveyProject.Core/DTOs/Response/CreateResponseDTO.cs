using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyProject.Core.DTOs.Response
{
    public class CreateResponseDTO
    {
        [Required]
        public int QuestionId { get; set; }

        public int? OptionId { get; set; }

        public string? ValueText { get; set; }

        public string? ValueNumber { get; set; }

        public string? ValueBoolean { get; set; }

        public string? ValueDate { get; set; }
    }
}
