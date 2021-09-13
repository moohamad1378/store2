using Microsoft.EntityFrameworkCore;
using Store_2.Application.Interface.Context;
using Store_2.Domain.Orders;
using Store_2.Domain.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_2.Application.Payments
{
    public interface IPaymentService
    {
        PaymentOfOrderDto PayForOrder(int OrderID);
        PaymenDto GetPayment(Guid id);
        bool VerifyPayment(Guid id, string Authority, long RefId);
    }
    public class PaymentService : IPaymentService
    {
        private readonly IDataBaseContext _context;
        private readonly IIdentityDatabaseContext _identityDatabaseContext;
        public PaymentService(IDataBaseContext context,
            IIdentityDatabaseContext identityDatabaseContext)
        {
            _context = context;
            _identityDatabaseContext = identityDatabaseContext;
        }

        public PaymenDto GetPayment(Guid id)
        {
            var payment = _context.Payments
                .Include(p => p.Order)
                .ThenInclude(p => p.OrderItems)
                .Include(p=>p.Order).ThenInclude(p=>p.DiscountAmout)
                .Include(p => p.Order)
                .SingleOrDefault(p => p.Id == id);

            var user = _identityDatabaseContext.Users.SingleOrDefault(p => p.Id == payment.Order.UserId);

            string description = $"پرداخت سفارش شماره {payment.OrderId} " + Environment.NewLine;
            description += "محصولات" + Environment.NewLine;
            foreach (var item in payment.Order.OrderItems.Select(p => p.ProductName))
            {
                description += $" -{item}";
            }

            PaymenDto paymentDto = new PaymenDto
            {
                Amount = payment.Order.TotalPrice(),
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Userid = user.Id,
                Id = payment.Id,
                Description = description,
            };
            return paymentDto;
        }

        public PaymentOfOrderDto PayForOrder(int orderId)
        {
            var order = _context.Orders
                .Include(p=>p.OrderItems)
                .Include(p=>p.DiscountAmout)
                .SingleOrDefault(p => p.Id == orderId);
            if (order == null) throw new Exception("");
            var payment = _context.Payments.SingleOrDefault(p => p.OrderId == orderId);
            if (payment == null)
            {
                payment = new Payment(order.TotalPrice(), order.Id);
                _context.Payments.Add(payment);
                _context.SaveChanges();
            }
            return new PaymentOfOrderDto()
            {
                Amount = payment.Ammount,
                PaymentId = payment.Id,
                paymentMethod = order.PaymentMethod
            };
        }

        public bool VerifyPayment(Guid id, string Authority, long RefId)
        {
            var payment = _context.Payments
                    .Include(p => p.Order)
                    .SingleOrDefault(p => p.Id == id);

                    if (payment == null)
                        throw new Exception("payment not found");

            payment.Order.PaymentDone();
            payment.PaymentIsDone(Authority, RefId);

           _context.SaveChanges();
            return true;
        }
    }
    public class PaymentOfOrderDto
    {
        public Guid PaymentId { get; set; }
        public int Amount { get; set; }
        public PaymentMethod paymentMethod { get; set; }
    }
    public class PaymenDto
    {
        public Guid Id { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public int Amount { get; set; }
        public string Userid { get; set; }
    }
}
