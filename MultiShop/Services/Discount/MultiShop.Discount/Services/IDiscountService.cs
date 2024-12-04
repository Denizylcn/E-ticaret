﻿using MultiShop.Discount.Dtos;

namespace MultiShop.Discount.Services
{
    public interface IDiscountService
    {
        Task<List<ResultCouponDto>> GetCouponsAsync();
        Task CreateCouponAsync(CreateCouponDto createCouponDto);   
        Task UpdateCouponAsync(UpdateCouponDto updateCouponDto);    
        Task DeleteCouponAsync(int couponId);
        Task <GetByIdCouponDto> GetByIdCouponAsync(int couponId);   

    }
}