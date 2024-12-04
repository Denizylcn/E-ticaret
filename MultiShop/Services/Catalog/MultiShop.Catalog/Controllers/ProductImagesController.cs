using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Services.ProductImageService;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImagesController : ControllerBase
    {
        private readonly IProductImageService _productImageService;

        public ProductImagesController(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetAllImages()
        {
           var value= await _productImageService.GetAllProductImages();
            return Ok(
                new { message = "Ürün Fotoğrafları Listelendi", data = value }
            );
        }
        [HttpPost("create")]

        
        public async Task<IActionResult> CreateProductImage(List<CreateProductImageDto> addToProductImageList)
        {
            foreach (var item in addToProductImageList)
            {
               await _productImageService.CreatProductImage(item);
                break;
            }
            return Ok(new {message="Ürün Fotoğrafları Eklendi"});
        }
        [HttpPut("update")]
        public async Task<IActionResult> UpdateProductImage(UpdateProductImageDto updateProductImageDto)
        {
            await _productImageService.UpdateProductImage(updateProductImageDto);
            return Ok(new {message="Ürün Fotoğrafı Güncellendi"});
        }
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteProductImage(string id) 
        {
            await _productImageService.DeleteProductImage(id);
            return Ok(new { message = "Ürün Fotoğrafı Silindi" });

        }
        [HttpGet("get-by-id")]
        public async Task<IActionResult> GetByIdProductImage (string productImageId)
        {
         var value= await _productImageService.GetByIdProductImages(productImageId);
            return Ok(new {message="Idye uygun görsel", data= value });
        }
        [HttpGet("get-by-product-id")]
        public async Task<IActionResult> GetByProductIdProductImage(string productId)
        { 
         //List<ResultProductImageDto>
         var value= await _productImageService.GetByProductIdProductImages(productId);

         return Ok(new {message="Product ID'ye uygun görseller", data=value});
        }
    }
}
