using Store_2.Application.Interface.Context;
using Store_2.Domain.Discounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_2.Application.Discounts.AddNewDiscountservice
{
    public interface IAddNewDiscountservice
    {
        void Execute(AddNewDiscountDto discountDto);
    }
    public class AddNewDiscountservice : IAddNewDiscountservice
    {
        private readonly IDataBaseContext _context;
        public AddNewDiscountservice(IDataBaseContext context)
        {
            _context = context;
        }
        public void Execute(AddNewDiscountDto discountDto)
        {
            var newdiscount = new Discount()
            {
                Name = discountDto.Name,
                CoponCode = discountDto.CoponCode,
                DiscountAmount = discountDto.DiscountAmount,
                DiscountLimitationId = discountDto.DiscountLimitationId,
                DiscountPercentage = discountDto.DiscountPercentage,
                DiscountTypeid = discountDto.DiscountTypeId,
                EndDate = discountDto.EndDate,
                RequiredCouponCode = discountDto.RequiredCouponCode,
                StartDate = discountDto.StartDate,
                UsePercentage = discountDto.UsePercentage,
            };
            if (discountDto.appliedToCatalogItem != null)
            {
                var catalogitem = _context.CataLogItems.Where(p => discountDto.appliedToCatalogItem.Contains(p.Id)).ToList();
                newdiscount.cataLogItems = catalogitem;
            }
            _context.Discounts.Add(newdiscount);
            _context.SaveChanges();
        }
    }
    public class AddNewDiscountDto
    {
 
        public string Name { get; set; }
        public bool UsePercentage { get; set; }
        public int DiscountPercentage { get; set; }
        public int DiscountAmount { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool RequiredCouponCode { get; set; }
        public string CoponCode { get; set; }
        public int DiscountLimitationId { get; set; }
        public int DiscountTypeId { get; set; }
        public int LimitationTimes { get; set; } = 0;
        public List<int> appliedToCatalogItem { get; set; }

    }
}
