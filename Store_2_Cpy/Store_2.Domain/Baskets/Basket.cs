using Store_2.Domain.Attributes;
using Store_2.Domain.Catalogs;
using Store_2.Domain.Discounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_2.Domain.Baskets
{
    [Auditable]
    public class Basket
    {
        public int Id { get; set; }
        public string  BuyerId { get;private set; }
        private readonly List<BasketItem> _Items = new List<BasketItem>();

        public int DiscountAmount { get; private set; } = 0;
        public Discount ApplieDiscount { get; private set; }
        public int? ApplieDiscountId { get; private set; }
        public ICollection<BasketItem> Items => _Items.AsReadOnly();
        public Basket(string BuyerId)
        {
            this.BuyerId = BuyerId;
        }
        public void AddItem(int cataLogItemid, int quantity, int unitPrice)
        {
            if (!Items.Any(p => p.CataLogItemid == cataLogItemid))
            {
                _Items.Add(new BasketItem(cataLogItemid, quantity, unitPrice));
                return;
            }
            var existingitem = Items.FirstOrDefault(p => p.CataLogItemid==cataLogItemid);
            existingitem.AddQountity(quantity);
        }
        public int TotalPrice()
        {
            int totalPrice = _Items.Sum(p => p.UnitPrice * p.Quantity);
            totalPrice -= ApplieDiscount.GetDiscountAmount(totalPrice); 
            return totalPrice;
        }
        public int TotalPiceWithoutDiscount()
        {
            int totalPrice = _Items.Sum(p => p.UnitPrice * p.Quantity);
            return totalPrice;
        }
        public void ApplyDiscountCode(Discount discount)
        {
            ApplieDiscount = discount;
            ApplieDiscountId = discount.Id;
            DiscountAmount = discount.GetDiscountAmount(TotalPiceWithoutDiscount());
        }
        public void RemoveDiscount()
        {
            ApplieDiscount = null;
            ApplieDiscountId = null;
            DiscountAmount = 0;
        }
    }
    [Auditable]
    public class BasketItem
    {
        public int Id { get; set; }
        public int UnitPrice { get;private set; }
        public int Quantity { get;private set; }
        public int CataLogItemid { get;private set; }
        public CataLogItem cataLogItem { get;private set; }
        public int BasketId { get;private set; }
        public BasketItem(int cataLogItemid,int quantity,int unitPrice)
        {
            UnitPrice = unitPrice;
            CataLogItemid = cataLogItemid;
            Setquantity(quantity);
        }
        public void AddQountity(int qountity)
        {
            Quantity += qountity;
        }
        public void Setquantity(int qountity)
        {

            Quantity = qountity;
        }
    }
}
