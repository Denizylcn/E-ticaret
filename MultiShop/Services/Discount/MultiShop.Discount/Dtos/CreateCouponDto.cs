namespace MultiShop.Discount.Dtos
{
    public class CreateCouponDto
    {
        public string cuoponName { get; set; }
        public string cuoponCode { get; set; }
        public double cuoponRate { get; set; }
        public int maxUsageCount { get; set; }
        public bool isActive { get; set; }
        public DateTime validDate { get; set; }

    }
}
