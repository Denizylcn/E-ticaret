using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Dtos.ProductImageDtos;

namespace MultiShop.Catalog.Services.ProductDetailService
{
    public interface IProductDetailService
    {
        Task CreatProductDetailAsync(CreateProductDetailDto detailToAdd);
        Task<List<ResultProductDetailDto>> GetAllProductDetailAsync();
        //idye göre çekme işi ama product idye  göre 
        Task UpdateProductDetailAsync(UpdateProductDetailDto detailToUpdate);

        Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string productDetailId);
        Task<ResultProductDetailDto> GetByProductIdProductDetailAsync(string productId);
        Task DeleteProductDetailAsync(string id);
    }
}
