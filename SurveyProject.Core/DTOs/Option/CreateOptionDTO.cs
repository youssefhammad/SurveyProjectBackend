using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyProject.Core.DTOs.Option
{
    public class CreateOptionDTO
    {
        [Required]
        public string OptionText { get; set; }

        public string Value { get; set; }

        public int Order { get; set; }
    }
}
