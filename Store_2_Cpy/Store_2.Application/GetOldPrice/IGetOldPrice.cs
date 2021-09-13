using Store_2.Domain.Catalogs;
using Store_2.Domain.Discounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_2.Application.GetOldPrice
{
    interface IGetOldPrice
    {
        int GetPrice(ICollection<Discount> Discounts, int _price);
    }
    public class GetOldPrice : IGetOldPrice
    {
        private int _price = 0;
        private int? _Oldprice = null;
        private ICollection<Discount> Discounts { get; set; }
        public int? PercentDiscount { get; set; }
        CataLogItem cataLogItem = new CataLogItem();
        public int GetPrice(ICollection<Discount> Discounts, int _price)
        {
            var dis = GetPreferredDiscount(Discounts, _price);
            if (dis != null)
            {
                var discountamount = dis.GetDiscountAmount(_price);
                int newprice = _price - discountamount;
                _Oldprice = _price;
                PercentDiscount = (discountamount * 100) / _price;
                return newprice;
            }
            return _price;
        }

        private Discount GetPreferredDiscount(ICollection<Discount> discounts, int price)
        {
            Discount preferredDiscount = null;
            decimal? maximumDiscountValue = null;
            if (discounts != null)
            {
                foreach (var discount in discounts)
                {
                    var currentDiscountValue = discount.GetDiscountAmount(price);
                    if (currentDiscountValue != decimal.Zero)
                    {
                        if (!maximumDiscountValue.HasValue || currentDiscountValue > maximumDiscountValue)
                        {
                            maximumDiscountValue = currentDiscountValue;
                            preferredDiscount = discount;
                        }
                    }
                }
            }

            return preferredDiscount;
        }
    }
}
