using SurveyProject.Core.Entities;
using SurveyProject.Core.Interfaces;
using SurveyProject.Infrastructure.Data;
using SurveyProject.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyProject.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SurveyDbContext _context;

        private IRepository<Survey> _surveys;
        private IRepository<QuestionType> _questionTypes;
        private IRepository<Question> _questions;
        private IRepository<Option> _options;
        private IRepository<Respondent> _respondents;
        private IRepository<Response> _responses;

        public UnitOfWork(SurveyDbContext context)
        {
            _context = context;
        }

        public IRepository<Survey> Surveys
        {
            get
            {
                if (_surveys == null)
                {
                    _surveys = new Repository<Survey>(_context);
                }
                return _surveys;
            }
        }

        public IRepository<QuestionType> QuestionTypes
        {
            get
            {
                if (_questionTypes == null)
                {
                    _questionTypes = new Repository<QuestionType>(_context);
                }
                return _questionTypes;
            }
        }

        public IRepository<Question> Questions
        {
            get
            {
                if (_questions == null)
                {
                    _questions = new Repository<Question>(_context);
                }
                return _questions;
            }
        }

        public IRepository<Option> Options
        {
            get
            {
                if (_options == null)
                {
                    _options = new Repository<Option>(_context);
                }
                return _options;
            }
        }

        public IRepository<Respondent> Respondents
        {
            get
            {
                if (_respondents == null)
                {
                    _respondents = new Repository<Respondent>(_context);
                }
                return _respondents;
            }
        }

        public IRepository<Response> Responses
        {
            get
            {
                if (_responses == null)
                {
                    _responses = new Repository<Response>(_context);
                }
                return _responses;
            }
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        #region IDisposable Support

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // Dispose managed state (managed objects)
                    _context.Dispose();
                }

                // Free unmanaged resources (unmanaged objects)
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
