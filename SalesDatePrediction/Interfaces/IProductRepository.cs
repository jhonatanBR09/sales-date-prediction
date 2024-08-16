using SalesDatePrediction.Models.DTOs;

namespace SalesDatePrediction.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductDto>> GetProductsAsync();
        Task<ProductDto> GetProductByIdAsync(int productId);
    }
}
