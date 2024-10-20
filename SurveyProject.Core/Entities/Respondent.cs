using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyProject.Core.Entities
{
    public class Respondent : BaseEntity
    {
        [ForeignKey("Survey")]
        public int SurveyId { get; set; }
        public Survey Survey { get; set; }

        public DateTime StartedAt { get; set; }

        public DateTime? CompletedAt { get; set; }

        public string Metadata { get; set; } // Stored as JSON string

        public ICollection<Response> Responses { get; set; }
    }
}
