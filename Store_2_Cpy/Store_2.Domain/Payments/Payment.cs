using Store_2.Domain.Attributes;
using Store_2.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_2.Domain.Payments
{
    [Auditable]
    public class Payment
    {
        public Guid Id { get; set; }
        public int Ammount { get; set; }
        public bool IsPay { get; private set; } = false;
        public DateTime? DatePay { get; private set; } = null;
        public string Authority { get; private set; }
        public long RefId { get; private set; } = 0;
        public Order? Order { get; private set; }
        public int OrderId { get; private set; }
        public Payment(int ammount,int orderid)
        {
            Ammount = ammount;
            OrderId = orderid;
        }
        public Payment()
        {

        }
        public void PaymentIsDone(string authority,long refid)
        {
            IsPay = true;
            DatePay = DateTime.Now;
            Authority = authority;
            RefId = refid;
        }
    }
}
