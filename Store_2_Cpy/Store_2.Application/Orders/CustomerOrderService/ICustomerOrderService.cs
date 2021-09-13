using Microsoft.EntityFrameworkCore;
using Store_2.Application.Interface.Context;
using Store_2.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_2.Application.Orders.CustomerOrderService
{
    public interface ICustomerOrderService
    {
        List<MyOrderDto> GetMyOrder(string UserId);
    }
    public class CustomerOrderService : ICustomerOrderService
    {
        private readonly IDataBaseContext context;

        public CustomerOrderService(IDataBaseContext context )
        {
            this.context = context;
        }
        public List<MyOrderDto> GetMyOrder(string UserId)
        {

            var orders = context.Orders
                .Include(p => p.OrderItems)
                .Where(p => p.UserId == UserId)
                .OrderByDescending(p => p.Id)
                .Select(p => new MyOrderDto
                {
                    Id=p.Id,
                    Date=context.Entry(p).Property("InsertTime").CurrentValue.ToString(),
                    OrderStatuse=p.OrderStatuse,
                    PaymentStatue=p.PaymentStatue,
                    Price=p.TotalPrice(),
                }).ToList();
            return orders;
        }
    }
    public class MyOrderDto
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public string Date { get; set; }
        public OrderStatuse OrderStatuse { get; set; }
        public PaymentStatue PaymentStatue { get; set; }
    }
}
