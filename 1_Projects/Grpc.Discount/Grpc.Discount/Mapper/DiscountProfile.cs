using AutoMapper;
using Grpc.Discount.Entities;
using Grpc.Discount.Protos;

namespace Grpc.Discount.Mapper
{
  public class DiscountProfile : Profile
  {

    public DiscountProfile()
    {
      CreateMap<Coupon, CouponModel>().ReverseMap();
    }


  }
}
