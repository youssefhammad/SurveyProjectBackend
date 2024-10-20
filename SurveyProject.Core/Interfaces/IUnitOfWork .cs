using SurveyProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyProject.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Survey> Surveys { get; }
        IRepository<QuestionType> QuestionTypes { get; }
        IRepository<Question> Questions { get; }
        IRepository<Option> Options { get; }
        IRepository<Respondent> Respondents { get; }
        IRepository<Response> Responses { get; }

        Task<int> CommitAsync();
    }
}
