using System.Collections.Generic;
using System.Threading.Tasks;
using SalesDatePrediction.Interfaces;
using SalesDatePrediction.Models.DTOs;

namespace SalesDatePrediction.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductDto>> GetProductsAsync()
        {
            return await _productRepository.GetProductsAsync();
        }

        public async Task<ProductDto> GetProductByIdAsync(int productId)
        {
            return await _productRepository.GetProductByIdAsync(productId);
        }
    }
}
