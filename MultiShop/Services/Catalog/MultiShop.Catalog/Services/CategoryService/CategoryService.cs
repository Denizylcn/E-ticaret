﻿using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Category> _categoryCollection;    
        private readonly IMapper _mapper;
        public CategoryService(IMapper mapper,IDatabaseSettings2 _databaseSettings)
        {
           
            var client= new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _categoryCollection=database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }
        public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
           var value=_mapper.Map<Category>(createCategoryDto);
            await _categoryCollection.InsertOneAsync(value);  
        }

        public async Task DeleteCategoryAsync(string id)
        {
            await _categoryCollection.DeleteOneAsync(x => x.categoryId == id);
        }

        public async Task<List<ResultCategoryDto>> GetAllAsync()
        {
           var values=await _categoryCollection.Find(x=>true).ToListAsync();
            return _mapper.Map<List<ResultCategoryDto>>(values);    
        }

        public async Task<GetbyIdCategoryDto> GetbyIdCategoryAsync(string Id)
        {
            var value= await _categoryCollection.Find<Category>(x=>x.categoryId==Id).FirstOrDefaultAsync();
            return _mapper.Map<GetbyIdCategoryDto>(value);  
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
           var values= _mapper.Map<Category>(updateCategoryDto);
            await _categoryCollection.FindOneAndReplaceAsync(x=>x.categoryId==updateCategoryDto.categoryId,values);
        }
    }
}
