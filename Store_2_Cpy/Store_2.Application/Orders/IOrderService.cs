using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Store_2.Application.Discounts;
using Store_2.Application.Exceptions;
using Store_2.Application.Interface.Context;
using Store_2.ApplicationUriComposer;
using Store_2.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_2.Application.Orders
{
    public interface IOrderService
    {
        int CreateOrder(int Basketid, int UserAddress, PaymentMethod paymentMethod);
    }
    public class OrderService : IOrderService
    {
        private readonly IDataBaseContext context;
        private readonly IMapper mapper;
        private readonly IUriComposerServicer uriComposerServicer;
        private readonly IDiscountHistoryService _discountHistoryService;
        public OrderService(IDataBaseContext context1, IMapper mapper1
            , IUriComposerServicer uriComposerServicer1,IDiscountHistoryService discountHistoryService)
        {
            context = context1;
            mapper = mapper1;
            uriComposerServicer = uriComposerServicer1;
            _discountHistoryService = discountHistoryService;
        }
        public int CreateOrder(int Basketid, int UserAddressid, PaymentMethod paymentMethod)
        {
            var basket = context.Baskets
                .Include(p => p.Items)
                .Include(p=>p.ApplieDiscount)
                .SingleOrDefault(p => p.Id == Basketid);
            if (basket == null)
                throw new NotFoundException(nameof(basket), Basketid);

            int[] Ids = basket.Items
                .Select(p => p.CataLogItemid).ToArray();

            var catalogitems = context.CataLogItems
                .Include(p=>p.Discounts)
                .Include(p=>p.catalogItemImages)
                .Where(p => Ids.Contains(p.Id));

            var orderitems = basket.Items.Select(basketitem =>
            {
                var catalogitem = catalogitems.First(c => c.Id == basketitem.CataLogItemid);
                var orderitem = new OrderItem(catalogitem.Id,
                    catalogitem.Name,
                    uriComposerServicer.ComposeIamgeUri
                    (catalogitem?.catalogItemImages?.FirstOrDefault()?.Src ?? ""),
                    catalogitem.Price,
                    basketitem.Quantity);
                return orderitem;

            }).ToList();
            var useraddress = context.UserAddresses.SingleOrDefault(p => p.Id == UserAddressid);
            var address = mapper.Map<Address>(useraddress);
            var order = new Order(basket.BuyerId, address, orderitems, paymentMethod
                ,basket.ApplieDiscount);
            context.Orders.Add(order);
            context.Baskets.Remove(basket);
            context.SaveChanges();
            if(basket.ApplieDiscount != null)
            {
                _discountHistoryService.InsertDiscountUsageHistory(basket.Id, order.Id);
            }
            return order.Id;
        }
    }
}
