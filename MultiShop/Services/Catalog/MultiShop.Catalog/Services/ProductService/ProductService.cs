using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;
using static MongoDB.Driver.WriteConcern;

namespace MultiShop.Catalog.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Product> _productCollection;

        public ProductService(IMapper mapper, IDatabaseSettings2 _databaseSettings)
        {
            var client=new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
            _mapper = mapper;
           
        }

        public async Task CreateProductAsync(CreateProductDto productToAdd)
        {
            var value=_mapper.Map<Product>(productToAdd);
             await _productCollection.InsertOneAsync(value);   
           // await _categoryCollection.InsertOneAsync(value);
        }

        public async Task DeleteProductAsync(string id)
        {
          // await _productCollection.DeleteOneAsync(id);
            await _productCollection.DeleteOneAsync(x => x.productId == id);
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
          var values= await _productCollection.Find(x=>true).ToListAsync();
           
            return _mapper.Map<List<ResultProductDto>>(values);
           
        }

        public async Task<GetByIdProductDto> GetByIdProductAsync(string id)
        {
          var value= await _productCollection.Find<Product>(x=>x.productId == id).FirstOrDefaultAsync();
          return _mapper.Map<GetByIdProductDto>(value);
         
           //Sadece Find(x=>x.productId==id) yazmak yeterli mi ?
        }

        public async Task UpdateProductAsync(UpdateProductDto productToUpdate)
        {
          var value=  _mapper.Map<Product>(productToUpdate);
            await _productCollection.FindOneAndReplaceAsync(x => x.productId == productToUpdate.productId, value);
        }
    }
}
