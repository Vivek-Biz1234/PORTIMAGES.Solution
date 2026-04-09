namespace PORTIMAGES.Application.Products.DTOs
{
    public class ProductInnerDetailsDTO
    {
        public long? ID { get; set; }
        public long ProductId { get; set; }
        public string EncID { get; set; }
        public string ComponentName { get; set; }
        public decimal ComponentWeight { get; set; }
        public string WeightUnit { get; set; }
    }
}
