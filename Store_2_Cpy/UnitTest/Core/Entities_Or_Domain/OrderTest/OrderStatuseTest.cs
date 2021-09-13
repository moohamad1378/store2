using Store_2.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest.Builders;
using Xunit;

namespace UnitTest.Core.Entities_Or_Domain.OrderTest
{
    public class OrderStatuseTest
    {
        [Fact]
        public void When_Order_is_Deliveried_OrderStatus_Changes_To_Deliveried()
        {
            var builder = new OrderBuilder();
            var order = builder.CreateOrderWithDefaultValues();
            order.OrderDelivered();
            Assert.Equal(OrderStatuse.Delivered, order.OrderStatuse);
        }
    }
}
