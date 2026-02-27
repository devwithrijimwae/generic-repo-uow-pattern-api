using generic_repo_uow_pattern_api.Entity;
using generic_repo_uow_pattern_api.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Net;

[Route("api/[controller]")]
[ApiController]
public class ProductWithUOWController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductWithUOWController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _unitOfWork.GetRepository<Product>().GetAllAsync();

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Product product)
    {
        try
        {
            using var transaction = _unitOfWork.BeginTransactionAsync();

            var productionEntity = new Product
            {
                Price = product.Price,
                ProductName = product.ProductName
            };
           var productResult = await _unitOfWork.GetRepository<Product>().AddAsync(productionEntity);
               await _unitOfWork.SaveChangesAsync();

            var orderEntity = new Order
            {
                OrderDate = DateTime.Now,
                ProductId = productResult.ProductId
            };
            await _unitOfWork.GetRepository<Order>().AddAsync(orderEntity);
            await _unitOfWork.SaveChangesAsync();

            await _unitOfWork.CommitAsync();

            return StatusCode((int)HttpStatusCode.Created, new { Id = productResult.ProductId }); 
        }
        catch (Exception)
        {
            await _unitOfWork.RollbackAsync();
            throw;

        }
    }
}