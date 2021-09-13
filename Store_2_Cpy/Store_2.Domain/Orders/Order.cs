using Store_2.Domain.Attributes;
using Store_2.Domain.Discounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_2.Domain.Orders
{
    [Auditable]
    public class Order
    {
        public int Id { get; set; }
        public string UserId { get; private set; }
        public DateTime OrderDate { get; private set; } = DateTime.Now;
        public Address Address { get;private set; }
        public PaymentMethod PaymentMethod { get;private set; }
        public PaymentStatue PaymentStatue { get;private set; }
        public OrderStatuse OrderStatuse { get;private set; }
        private readonly List<OrderItem> _orderItems = new List<OrderItem>();
        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems.AsReadOnly();

        public decimal DiscountAmout { get; private set; }
        public Discount AppliedDiscount { get; private set; }
        public int? AppliedDiscountId { get; set; }
        public Order(string userid,Address address,List<OrderItem> orderItems,PaymentMethod paymentMethod
            ,Discount discount)
        {
            UserId = userid;
            Address = address;
            _orderItems = orderItems;
            PaymentMethod = paymentMethod;
            if(discount != null)
            {

            }
        }
        public Order()
        {

        }
        public void PaymentDone()
        {
            PaymentStatue = PaymentStatue.Paid;
        }
        public void OrderDelivered()
        {
            OrderStatuse = OrderStatuse.Delivered;
        }
        public void OrderCancelled()
        {
            OrderStatuse = OrderStatuse.Cancelled;
        }
        public void OrderReturned()
        {
            OrderStatuse = OrderStatuse.Returned;
        }
        public int TotalPrice()
        {
            int totalPrice = _orderItems.Sum(p => p.UnitPrice * p.Units);
            if(AppliedDiscount != null)
            {
                totalPrice -= AppliedDiscount.GetDiscountAmount(totalPrice);
            }
            
            return totalPrice;
        }
        public int TotalPriceWithoutDiscount()
        {
            int totalPrice = _orderItems.Sum(p => p.UnitPrice * p.Units);
            return totalPrice;
        }
        public void ApplyDiscountCode(Discount discount)
        {
            this.AppliedDiscount = discount;
            this.AppliedDiscountId = discount.Id;
            this.DiscountAmout = discount.GetDiscountAmount(TotalPrice());
        }

    }
    public enum PaymentMethod
    {
        onlinePament=0,
        PaymentOnThepost=1
    }
    public enum PaymentStatue
    {
        WaitingForPayment=0,
        Paid=1
    }
    public enum OrderStatuse
    {
        Processing=0,

        Delivered=1,

        Returned=2,

        Cancelled=3
    }
}
