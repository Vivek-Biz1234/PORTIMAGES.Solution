using PORTIMAGES.Application.Products.DTOs;
using PORTIMAGES.Common.Responses; 

namespace PORTIMAGES.Application.Products.Interfaces
{
    public interface IProductRepository
    {
        Task<ApiResponse<object>> AddProductAsync(AddProductRequestDTO dto);

        Task<ApiResponse<object>> UpdateProductAsync(AddProductRequestDTO dto);

        Task<ApiResponse<object>> DeleteProductAsync(long id, int deletedBy);

        Task<ApiResponse<AddProductRequestDTO?>> GetProductByIdAsync(long id);

        Task<ApiResponse<List<ProductResponseDTO>>> GetProductListAsync();
    }
}
