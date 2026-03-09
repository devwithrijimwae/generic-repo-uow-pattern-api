using generic_repo_uow_pattern_api.Entity;

namespace generic_repo_uow_pattern_api.Specifications
{
    public class ProductByNamespec : BaseSpecification<Product>
    {
        public ProductByNamespec(string productName)
            : base(x => x.ProductName.Contains(productName))
        {

        }
    }
}