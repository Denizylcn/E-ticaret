using MultiShop.Catalog.Dtos.ProductImageDtos;

namespace MultiShop.Catalog.Services.ProductImageService
{
    public interface IProductImageService
    {
        Task CreatProductImage(CreateProductImageDto imageToAdd);
        Task<List<ResultProductImageDto>> GetAllProductImages();
        //idye göre çekme işi ama product idye  göre 
        Task UpdateProductImage(UpdateProductImageDto imageToUpdate);

        Task<GetByIdProductImageDto> GetByIdProductImages(string productImageId);
        Task<List<ResultProductImageDto>> GetByProductIdProductImages(string productId);
        Task DeleteProductImage(string id);

    }
}
