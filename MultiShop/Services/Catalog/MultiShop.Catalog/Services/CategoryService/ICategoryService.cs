using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Entities;

namespace MultiShop.Catalog.Services.CategoryService
{
    public interface ICategoryService
    {
        Task<List<ResultCategoryDto>> GetAllAsync();
       
        Task CreateCategoryAsync(CreateCategoryDto createCategoryDto);  
        Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
        Task<GetbyIdCategoryDto> GetbyIdCategoryAsync(string Id);
        Task DeleteCategoryAsync(string id);

    }
}
