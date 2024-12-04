namespace MultiShop.Discount.Dtos
{
    public class UpdateCouponDto
    {
        public int couponId { get; set; }
        public string cuoponName { get; set; }
        public string cuoponCode { get; set; }
        public double cuoponRate { get; set; }
        public int maxUsageCount { get; set; }
        public bool isActive { get; set; }
        public DateTime validDate { get; set; }
    }
}
