using System.Collections.Generic;
using System.Threading.Tasks;
using SalesDatePrediction.Models.DTOs;

namespace SalesDatePrediction.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProductsAsync();
        Task<ProductDto> GetProductByIdAsync(int productId);
    }
}
