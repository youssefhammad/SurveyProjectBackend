using SurveyProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SurveyProject.Core.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "");
        Task<T> GetByIdAsync(int id);
        Task InsertAsync(T entity);
        Task InsertRangeAsync(IEnumerable<T> responses);
        void Update(T entity);
        Task DeleteAsync(int id);
        void Delete(T entity);
        Task<int> CountAsync(Expression<Func<T, bool>> filter = null);
    }
}
