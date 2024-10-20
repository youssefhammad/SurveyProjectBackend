using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyProject.Core.Entities
{
    public class Survey : BaseEntity
    {
        [Required]
        [MaxLength(255)]
        public string Title { get; set; }

        public string Description { get; set; }

        public ICollection<Question> Questions { get; set; }

        public ICollection<Respondent> Respondents { get; set; }
    }
}
