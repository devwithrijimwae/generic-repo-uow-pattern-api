using generic_repo_uow_pattern_api.Data;
using generic_repo_uow_pattern_api.Model;

namespace generic_repo_uow_pattern_api.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        void SetDbContext(MyDbContext myDbContext);
       
    }
}