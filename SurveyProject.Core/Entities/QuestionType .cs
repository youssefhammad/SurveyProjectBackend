using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyProject.Core.Entities
{
    public class QuestionType : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string TypeName { get; set; }

        [Required]
        [MaxLength(50)]
        public string DataType { get; set; }

        public ICollection<Question> Questions { get; set; }
    }
}
