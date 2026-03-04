using generic_repo_uow_pattern_api.Common;
using generic_repo_uow_pattern_api.Entity;

namespace generic_repo_uow_pattern_api.Repository
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductsbyName(string productname);
        Task<PaginatedList<Product>> GetAllProductsWithPagging(int page, int pageSize, string searchTerm);

    }
}