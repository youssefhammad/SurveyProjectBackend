using Microsoft.EntityFrameworkCore;
using SurveyProject.Core.Interfaces;
using SurveyProject.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SurveyProject.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly SurveyDbContext _context;
        internal DbSet<T> dbSet;

        public Repository(SurveyDbContext context)
        {
            _context = context;
            this.dbSet = _context.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            // Include properties separated by comma
            foreach (var includeProperty in includeProperties.Split(
                new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty.Trim());
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual async Task InsertAsync(T entity)
        {
            await dbSet.AddAsync(entity);
        }

        public async Task InsertRangeAsync(IEnumerable<T> responses)
        {
            await dbSet.AddRangeAsync(responses);
        }

        public virtual void Update(T entity)
        {
            dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public virtual async Task DeleteAsync(int id)
        {
            T entityToDelete = await dbSet.FindAsync(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(T entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
        }

        public virtual async Task<int> CountAsync(Expression<Func<T, bool>> filter = null)
        {
            if (filter != null)
                return await dbSet.CountAsync(filter);
            else
                return await dbSet.CountAsync();
        }
    }
}
