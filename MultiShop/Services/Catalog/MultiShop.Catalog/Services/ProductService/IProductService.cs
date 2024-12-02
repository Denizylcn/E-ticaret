using MultiShop.Catalog.Dtos.ProductDtos;

namespace MultiShop.Catalog.Services.ProductService
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GetAllProductAsync();
        Task CreateProductAsync(CreateProductDto productToAdd);

        Task UpdateProductAsync(UpdateProductDto productToUptade);

        Task<GetByIdProductDto> GetByIdProductAsync(string id);
        Task DeleteProductAsync(string id);
    }
}

