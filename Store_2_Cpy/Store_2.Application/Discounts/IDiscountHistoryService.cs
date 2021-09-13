using Common;
using Store_2.Application.Dtos;
using Store_2.Application.Interface.Context;
using Store_2.Domain.Discounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_2.Application.Discounts
{
    public interface IDiscountHistoryService
    {
        void InsertDiscountUsageHistory(int DiscountId, int orderId);
        DiscountUsageHistory GetDiscountUsageHistoryById(int DiscountUsageHistoryId);
        PageInatedItemDto<DiscountUsageHistory> GetAllDiscountUsageHistory(int? DiscountId
            , string? UserID, int PageIndex, int PageSize);
    }
    public class DiscountHistoryService : IDiscountHistoryService
    {
        private readonly IDataBaseContext _context;
        public DiscountHistoryService(IDataBaseContext context)
        {
            _context = context;
        }

        public PageInatedItemDto<DiscountUsageHistory> GetAllDiscountUsageHistory(int? DiscountId, string UserID, int PageIndex, int PageSize)
        {
            var query = _context.DiscountUsageHistories.AsQueryable();

            if (DiscountId.HasValue && DiscountId.Value > 0)
                query = query.Where(p => p.DiscountId == DiscountId.Value);

            if (!string.IsNullOrEmpty(UserID))
                query = query.Where(p => p.Order != null && p.Order.UserId == UserID);

            query = query.OrderByDescending(c => c.CreatedOn);
            var pagedItems = query.PagedResult(PageIndex, PageSize, out int rowCount);
            return new PageInatedItemDto<DiscountUsageHistory>(PageIndex, PageSize, rowCount, query.ToList());
        }

        public DiscountUsageHistory GetDiscountUsageHistoryById(int DiscountUsageHistoryId)
        {
            if (DiscountUsageHistoryId == 0)
                return null;

            var discountUsage = _context.DiscountUsageHistories.Find(DiscountUsageHistoryId);
            return discountUsage;
        }

        public void InsertDiscountUsageHistory(int DiscountId, int orderId)
        {
            var order = _context.Orders.Find(orderId);
            var discount = _context.Discounts.Find(DiscountId);

            DiscountUsageHistory discountUsageHistory = new DiscountUsageHistory()
            {
                CreatedOn = DateTime.Now,
                Discount = discount,
                Order = order,
            };
            _context.DiscountUsageHistories.Add(discountUsageHistory);
            _context.SaveChanges();
        }
    }
}
