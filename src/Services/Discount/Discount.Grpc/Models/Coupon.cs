namespace Discount.Grpc.NewFolder
{
    public class Coupon
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = default!;
        public string description { get; set; } = default!;

        public decimal Amount { get; set; }
    }
}
