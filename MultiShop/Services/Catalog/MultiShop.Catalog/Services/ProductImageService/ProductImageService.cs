using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductImageService
{
    public class ProductImageService:IProductImageService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<ProductImage> _productImageCollection;

        public ProductImageService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client=new MongoClient(_databaseSettings.ConnectionString); 
            var database=client.GetDatabase(_databaseSettings.DatabaseName);
            _productImageCollection = database.GetCollection<ProductImage>(_databaseSettings.ProductImageCollectionName);
            _mapper = mapper;
            
        }

        public async Task CreatProductImage(CreateProductImageDto imageToAdd)
        {
           var value= _mapper.Map<ProductImage>(imageToAdd);
            await _productImageCollection.InsertOneAsync(value);   
        }

        public async Task DeleteProductImage(string id)
        {
           await _productImageCollection.DeleteOneAsync(x=>x.productImagesId==id);
        }

        public async Task<List<ResultProductImageDto>> GetAllProductImages()
        {
            var values = await _productImageCollection.Find(x => true).ToListAsync();

            // AutoMapper kullanarak veriyi ResultProductImageDto'ya dönüştürme
            return _mapper.Map<List<ResultProductImageDto>>(values);
        }

        public async Task<GetByIdProductImageDto> GetByIdProductImages(string ProductImageId)
        {
            var value = await _productImageCollection.Find<ProductImage>(x => x.productImagesId == ProductImageId).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductImageDto>(value);

        }

        

        public async Task<List<ResultProductImageDto>> GetByProductIdProductImages(string id)
        {
            var value = await _productImageCollection.Find<ProductImage>(x=>x.productId == id).ToListAsync();
            return _mapper.Map<List<ResultProductImageDto>>(value); 
        }

        public async Task UpdateProductImage(UpdateProductImageDto imageToUpdate)
        {
            var value=_mapper.Map<ProductImage>(imageToUpdate);
             await _productImageCollection.ReplaceOneAsync<ProductImage>(x => x.productImagesId == imageToUpdate.productImagesId, value);
        }

        //Product Image'i kaydetmek için method gerekli . 
    }
}
