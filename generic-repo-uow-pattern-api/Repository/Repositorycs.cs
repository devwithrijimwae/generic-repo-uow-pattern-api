using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using generic_repo_uow_pattern_api.Data;
using Microsoft.EntityFrameworkCore;

namespace generic_repo_uow_pattern_api.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected DbSet<T> _dbSet;
        private MyDbContext _myDbContext;

        public Repository(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
            _dbSet = myDbContext.Set<T>();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _myDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            await _myDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void SetDbContext(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
            _dbSet = myDbContext.Set<T>();
        }

        public async Task UpdateAsync(T entity)
        {
            _myDbContext.Entry(entity).State = EntityState.Modified;
            await _myDbContext.SaveChangesAsync();
        }
    }
}