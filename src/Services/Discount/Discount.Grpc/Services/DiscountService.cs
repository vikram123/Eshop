using Discount.Grpc.Data;
using Grpc.Core;
using Microsoft.EntityFrameworkCore;
using Mapster;
using Discount.Grpc.NewFolder;
namespace Discount.Grpc.Services
{
    public class DiscountService(DiscountContext dbContext, ILogger<DiscountService> logger) : discountProtoService.discountProtoServiceBase
    {
        public override async Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
        {
            var Coupon = request.Coupon.Adapt<Coupon>();
            Coupon.description = "test vikram";
            dbContext.Add(Coupon);
            await dbContext.SaveChangesAsync();

            logger.LogInformation("Data is instereted");
            var CouponModel = Coupon.Adapt<CouponModel>();
            return CouponModel;
            // return base.CreateDiscount(request, context);
        }
        public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
        {
            // return base.GetDiscount(request, context);

            var coupon = await dbContext.Coupons.FirstOrDefaultAsync(x => x.ProductName == request.ProductName);

            if (coupon is null)
                coupon = new NewFolder.Coupon { ProductName = "NO discount", Amount = 0, description = "test fail" };


            var CouponModel = coupon.Adapt<CouponModel>();
            //  var CouponModel = new CouponModel();
            return CouponModel;

        }

        public override Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
        {
            return base.UpdateDiscount(request, context);
        }

        public override  Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
        {
            //var coupon = await dbContext.Coupons.FirstOrDefaultAsync(x => x.ProductName == "one plus 13");
            //dbContext.Coupons.Remove(coupon);
            return base.DeleteDiscount(request, context);
        }
    }
}
