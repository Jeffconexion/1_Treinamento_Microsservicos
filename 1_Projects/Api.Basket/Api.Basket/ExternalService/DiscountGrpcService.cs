using System.Threading.Tasks;
using Grpc.Discount.Protos;

namespace Api.Basket.ExternalService
{
  public class DiscountGrpcService
  {
    private readonly DiscountProtoService.DiscountProtoServiceClient
            _discountProtoService;

    public DiscountGrpcService(DiscountProtoService.DiscountProtoServiceClient
        discountProtoService)
    {
      _discountProtoService = discountProtoService;
    }

    public async Task<CouponModel> GetDiscount(string productName)
    {
      //Aqui eu obtenho o serviço GRPC
      var discountRequest = new GetDiscountRequest { ProductName = productName };

      return await _discountProtoService.GetDiscountAsync(discountRequest);// vai retornar um CouponModel GRPC
    }
  }
}
