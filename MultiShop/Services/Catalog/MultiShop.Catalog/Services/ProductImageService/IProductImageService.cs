using MultiShop.Catalog.Dtos.ProductImageDtos;

namespace MultiShop.Catalog.Services.ProductImageService
{
    public interface IProductImageService
    {
        Task CreatProductImage(CreateProductImageDto imageToAdd);
        Task<List<ResultProductImageDto>> GetAllProductImages();
        //idye göre çekme işi ama product idye  göre 
        Task UpdateProductImage(UpdateProductImageDto imageToUpdate);

        Task<GetByIdProductImageDto> GetByIdProductImages(GetByIdProductImageDto idProductImage);
        Task<List<ResultProductImageDto>> GetByProductIdProductImages(string id);
        Task DeleteProductImage(string id);

    }
}
