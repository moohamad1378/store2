using Store_2.Domain.Attributes;
using Store_2.Domain.Catalogs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_2.Domain.Discounts
{
    [Auditable]
    public class Discount
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool UsePercentage { get; set; }
        public int DiscountPercentage { get; set; }
        public int DiscountAmount { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool RequiredCouponCode { get; set; }
        public string CoponCode { get; set; }
        [NotMapped]
        public DiscountType discountType
        {
            get => (DiscountType)this.DiscountTypeid;
            set => this.DiscountTypeid = (int)value;
        }
        public int DiscountTypeid { get; set; }
        public ICollection<CataLogItem> cataLogItems { get; set; }
        public int limitationTimes { get; set; }
        [NotMapped]
        public DiscountLimitationType DiscountLimitation
        {
            get => (DiscountLimitationType)this.DiscountLimitationId;
            set => this.DiscountLimitationId = (int)value;
        }
        public int DiscountLimitationId { get; set; }
        public int GetDiscountAmount(int amount)
        {
            var result = 0;
            if (UsePercentage)
            {
                result=(((amount) * (DiscountPercentage)) / 100);
            }
            else
            {
                result = DiscountAmount;
            };
            return result;
        }

    }
    public enum DiscountType
    {
        AssingnedProduct=0,
        AssingnedToCategory=1,
        AssingnedToUser = 2,
        AssingnedToBrand = 3,

    }
    public enum DiscountLimitationType
    {

        [Display(Name = "Without Limit")]
        Unlimited = 0,

        [Display(Name = "Limited")]
        NTimesOnly = 1,

        [Display(Name = "N Tims")]
        NTimesPerCustomer = 2,
    }
}
