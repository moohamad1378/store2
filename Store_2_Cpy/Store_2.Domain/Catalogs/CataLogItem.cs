using Store_2.Domain.Attributes;
using Store_2.Domain.Discounts;
using Store_2.Domain.Orders;
using System.Collections.Generic;

namespace Store_2.Domain.Catalogs
{
    [Auditable]
    public class CataLogItem
    {
        //private int _price = 0;
        //private int? _Oldprice = null;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }


        public int Price {
            get;
            //{
            //    return GetPrice();
            //}
            set;
            //{
            //    Price = _price;
            //}
        }
        public int? OldPrice
        {
            get;
            //{
            //    return _Oldprice;
            //}
            set;
            //{
            //    OldPrice = _Oldprice;
            //}
        }
        public int? PercentDiscount { get; set; }

        public CatalogType CatalogType { get; set; }
        public int CatalogTypeId { get; set; }
        public CatalogBrand CatalogBrand { get; set; }
        public int CatalogBrandId { get; set; }
        public int AvailableStock { get; set; }
        public int RestockThershold { get; set; }
        public int MaxStockThresjold { get; set; }
        public int VisitCount { get; set; }
        public ICollection<CataLogItemFeature> cataLogItemFeatures { get; set; }
        public ICollection<CatalogItemImage> catalogItemImages { get; set; }
        public ICollection<Discount> Discounts { get; set; }
        public ICollection<CatalogItemFavorite> CatalogItemFavorites { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }

        //private int GetPrice()
        //{
        //    var dis = GetPreferredDiscount(Discounts, _price);
        //    if (dis != null)
        //    {
        //        var discountamount = dis.GetDiscountAmount(_price);
        //        int newprice = _price - discountamount;
        //        _Oldprice = _price;
        //        PercentDiscount = (discountamount * 100) / _price;
        //        return newprice;
        //    }
        //    return _price;
        //}
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
