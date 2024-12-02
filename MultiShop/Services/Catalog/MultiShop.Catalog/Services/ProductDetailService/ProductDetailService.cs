using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductDetailService
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<ProductDetail> _productDetailCollection;

        public ProductDetailService(IMapper mapper,IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _productDetailCollection = database.GetCollection<ProductDetail>(databaseSettings.ProductDetailCollectionName);
            _mapper = mapper;
        }

        public async Task CreatProductDetailAsync(CreateProductDetailDto detailToAdd)
        {
           var value = _mapper.Map<ProductDetail>(detailToAdd);
           await _productDetailCollection.InsertOneAsync(value); 
        }

        public async Task DeleteProductDetailAsync(string id)
        {
         await _productDetailCollection.DeleteOneAsync(x=>x.productDetailId == id);    
           
        }

        public async Task<List<ResultProductDetailDto>> GetAllProductDetailAsync()
        {
           var values= await _productDetailCollection.Find(x=>true).ToListAsync();
            return _mapper.Map<List<ResultProductDetailDto>>(values); 
            
        }

        public async Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(GetByIdProductDetailDto getByIdProductDetailDto)
        {
          var value= await _productDetailCollection.Find(x=>x.productDetailId== getByIdProductDetailDto.productDetailId).FirstOrDefaultAsync();   
            return _mapper.Map<GetByIdProductDetailDto>(value);
        }

        public async Task<ResultProductDetailDto> GetByProductIdProductDetailAsync(string id)
        {
           var value = await _productDetailCollection.Find(x=>x.productId== id).FirstOrDefaultAsync();
            return _mapper.Map<ResultProductDetailDto>(value);
        }

        public async Task UpdateProductDetailAsync(UpdateProductDetailDto detailToUpdate)
        {
           var value = _mapper.Map<ProductDetail>(detailToUpdate);
          await _productDetailCollection.ReplaceOneAsync(x => x.productDetailId == detailToUpdate.productDetailId, value);
        }
    }
}
