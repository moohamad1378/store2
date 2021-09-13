using Microsoft.EntityFrameworkCore;
using Store_2.Application.Dtos;
using Store_2.Application.Interface.Context;
using Store_2.Domain.Discounts;
using Store_2.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_2.Application.Discounts
{
    public interface IDiscountService
    {
        List<CatalogItemDto> GetCatalogItems(string searchkey);
        bool ApplyDiscountInBasket(string CoponCode,int BasketId);
        bool RemoveDiscountFromBasket(int Basketid);
        BaseDto IsDiscountValid(String CoponCode, User? user);
    }
    public class DiscountService : IDiscountService
    {
        private readonly IDataBaseContext _context;
        private readonly IDiscountHistoryService _discountHistoryService;
        public DiscountService(IDataBaseContext context, IDiscountHistoryService discountHistoryService)
        {
            _context = context;
            _discountHistoryService = discountHistoryService;
        }

        public bool ApplyDiscountInBasket(string CoponCode, int BasketId)
        {
            var basket = _context.Baskets
                .Include(p => p.Items)
                .Include(p => p.ApplieDiscount).FirstOrDefault(p => p.Id == BasketId);
            var discount = _context.Discounts.Where(p => p.CoponCode.Equals(CoponCode))
                .FirstOrDefault();
            basket.ApplyDiscountCode(discount);
            _context.SaveChanges();
            return true;
        }

        public List<CatalogItemDto> GetCatalogItems(string searchkey)
        {
            if (!string.IsNullOrEmpty(searchkey))
            {
                var data = _context.CataLogItems.Where(p => p.Name.Contains(searchkey))
                    .Select(p => new CatalogItemDto
                    {
                        Id = p.Id,
                        Name = p.Name
                    }).ToList();
                return data;
            }
            else
            {
                var data = _context.CataLogItems.OrderByDescending(p=>p.Id).Take(20)
                    .Select(p => new CatalogItemDto
                    {
                        Id = p.Id,
                        Name = p.Name
                    }).ToList();
                return data;
            }
        }

        public BaseDto IsDiscountValid(string CoponCode, User user)
        {
            var discount = _context.Discounts.Where(p => p.CoponCode == CoponCode).FirstOrDefault();
            if(discount == null)
            {
                return new BaseDto(false, new List<string> { "CoponCode Not Valid" });
            }
            var now = DateTime.UtcNow;
            if (discount.StartDate.HasValue)
            {
                var startDate = DateTime.SpecifyKind(discount.StartDate.Value, DateTimeKind.Utc);
                if (startDate.CompareTo(now) > 0)
                    return new BaseDto(false, new List<string> { "It is not time to use the discount code yet" });
            }
            if (discount.EndDate.HasValue)
            {
                var enddate = DateTime.SpecifyKind(discount.EndDate.Value, DateTimeKind.Utc);
                if (enddate.CompareTo(now) < 0)
                {
                    return new BaseDto(false, new List<string> { "The Time For Using The Copond code has finished" });
                }
                

            }
            var checklimit = CheckDiscountLimitation(discount, user);
            if (checklimit.IsSuccess == false)
                return checklimit;
            return new BaseDto(true, null);
        }
        private BaseDto CheckDiscountLimitation(Discount discount, User user)
        {
            switch (discount.DiscountLimitation)
            {
                case DiscountLimitationType.Unlimited:
                    {
                        return new BaseDto(true, null);
                    }
                case DiscountLimitationType.NTimesOnly:
                    {
                        var totalUsage = _discountHistoryService.GetAllDiscountUsageHistory
                            (discount.Id, null, 0, 1).Data.Count();
                        if(totalUsage < discount.limitationTimes)
                        {
                            return new BaseDto(true, null);
                        }
                        else
                        {
                            return new BaseDto(false, new List<string> { " You Used  That Alot" });
                        }
                    }
                case DiscountLimitationType.NTimesPerCustomer:
                    {
                        if(user != null)
                        {
                            var totalUsage = _discountHistoryService.GetAllDiscountUsageHistory
                                (discount.Id, user.Id, 0, 1).Data.Count();
                            if (totalUsage < discount.limitationTimes)
                            {
                                return new BaseDto(true, null);
                            }
                            else
                            {
                                return new BaseDto(false, new List<string> { " you stealed this copon and you cant steal that again" });
                            }
                        }
                        else
                        {
                            return new BaseDto(true, null);
                        }

                    }
                default:
                    break;
            }
            return new BaseDto(true, null);
        }

        public bool RemoveDiscountFromBasket(int Basketid)
        {
            var basket = _context.Baskets.Find(Basketid);
            basket.RemoveDiscount();
            _context.SaveChanges();
            return true;
        }
    }
    public class CatalogItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
