using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Services.ProductDetailService;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/product-details")]
    [ApiController]
    public class ProductDetailsController : ControllerBase
    {
        private readonly IProductDetailService _productDetailService;

        public ProductDetailsController(IProductDetailService productDetailService)
        {
            _productDetailService = productDetailService;
        }

        [HttpGet("list")]
        public async Task<IActionResult> ProductDetailList()
        {
            var values = await _productDetailService.GetAllProductDetailAsync();
            return Ok(new { message = "Ürünler Listelendi", data = values });
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateProductDetail([FromBody] CreateProductDetailDto productDetailDto)
        {
            await _productDetailService.CreatProductDetailAsync(productDetailDto);
            return Ok(new { message = "Ürün Detayı Başarıyla Eklendi" });
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateProductDetail([FromBody] UpdateProductDetailDto productDetailDto)
        {
            await _productDetailService.UpdateProductDetailAsync(productDetailDto);
            return Ok(new { message = "Ürün Detayı Başarıyla Güncellendi" });
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteProductDetail(string id)
        {
            await _productDetailService.DeleteProductDetailAsync(id);
            return Ok(new { message = "Ürün Detayı Başarıyla Silindi" });
        }

        [HttpGet("get-by-id")]
        public async Task<IActionResult> GetByIdProductDetail(string productDetailId)
        {
            var value = await _productDetailService.GetByIdProductDetailAsync(productDetailId);
            return Ok(new { data = value });
        }

        [HttpGet("get-by-product-id/{id}")]
        public async Task<IActionResult> GetByProductIdProductDetail(string id)
        {
            var value = await _productDetailService.GetByProductIdProductDetailAsync(id);
            return Ok(new { data = value });
        }
    }
}
