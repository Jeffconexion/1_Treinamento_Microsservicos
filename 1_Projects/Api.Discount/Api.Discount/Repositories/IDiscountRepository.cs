﻿using System.Threading.Tasks;
using Api.Discount.Entitys;

namespace Api.Discount.Repositories
{
  public interface IDiscountRepository
  {
    Task<Coupon> GetDiscount(string productName);
    Task<bool> CreateDiscount(Coupon coupon);
    Task<bool> UpdateDiscount(Coupon coupon);
    Task<bool> DeleteDiscount(string productName);
  }
}
