using Discount.Grpc.NewFolder;
using Microsoft.EntityFrameworkCore;

namespace Discount.Grpc.Data
{
    public class DiscountContext:DbContext
    {
        public DbSet<Coupon> Coupons { get; set; }

        public DiscountContext(DbContextOptions<DiscountContext> options) : 
            base(options) 
        {
        
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coupon>().HasData(
              new Coupon { Id=1,ProductName="Iphone X",description=" Iphone ",Amount=150.00M },
              new Coupon { Id = 2, ProductName = "Samsung S24", description = " Samung ", Amount = 200.00M }
                );

        }
    }
}
