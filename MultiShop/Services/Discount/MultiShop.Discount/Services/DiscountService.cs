using Dapper;
using MultiShop.Discount.Context;
using MultiShop.Discount.Dtos;
using MultiShop.Discount.Entities;

namespace MultiShop.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly DapperContext _dapperContext;

        public DiscountService(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task CreateCouponAsync(CreateCouponDto createCouponDto)
        {
            string query= "insert into Coupons (cuoponName,cuoponCode,cuoponRate,maxUsageCount,isActive,validDate) values (@cuoponName, @cuoponCode, @cuoponRate, @maxUsageCount, @isActive, @validDate)";
            
            var parameters = new DynamicParameters();
          //  parameters.Add("@cuoponName", createCouponDto.cuoponName);
            foreach (var property in createCouponDto.GetType().GetProperties())
            {
                parameters.Add("@" + property.Name, property.GetValue(createCouponDto));
            }

            using (var connection = _dapperContext.CreateConnection()) 
            {
                await connection.ExecuteAsync(query, parameters);   
            }
        }

        public async Task DeleteCouponAsync(int couponId)
        {
            string query = "Delete From Coupons where couponId=@couponId";
            var parameters = new DynamicParameters();   
            parameters.Add("couponId",couponId);//@ koyulmayacak mı 
            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<GetByIdCouponDto> GetByIdCouponAsync(int couponId)
        {
            string query = "Select * From Coupons where couponId=@couponId";
            var parameters = new DynamicParameters();
            parameters.Add("couponId", couponId);
            using (var connection = _dapperContext.CreateConnection())
            {
                var value =await connection.QueryFirstOrDefaultAsync<GetByIdCouponDto> (query,parameters);
                return value;
            }
        }

        public async Task<List<ResultCouponDto>> GetCouponsAsync()
        {
            string query = "Select * From Coupons";
            using (var connection = _dapperContext.CreateConnection())
            {
               var values= await connection.QueryAsync<ResultCouponDto>(query);
                return values.ToList();
            }
        }

        public async Task UpdateCouponAsync(UpdateCouponDto updateCouponDto)
        {
            string query = "UPDATE Coupons SET cuoponName = @cuoponName, cuoponCode = @cuoponCode, " +
                    "cuoponRate = @cuoponRate, maxUsageCount = @maxUsageCount, " +
                    "isActive = @isActive, validDate = @validDate " +
                    "WHERE couponId = @couponId";

            var parameters = new DynamicParameters();
            parameters.Add("cuoponName", updateCouponDto.cuoponName);
            parameters.Add("cuoponCode", updateCouponDto.cuoponCode);
            parameters.Add("cuoponRate", updateCouponDto.cuoponRate);
            parameters.Add("maxUsageCount", updateCouponDto.maxUsageCount);
            parameters.Add("isActive", updateCouponDto.isActive);
            parameters.Add("validDate", updateCouponDto.validDate);
            parameters.Add("couponId", updateCouponDto.couponId);

            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
