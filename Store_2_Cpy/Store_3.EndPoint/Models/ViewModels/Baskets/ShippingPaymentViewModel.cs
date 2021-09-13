using Store_2.Application.basketsService;
using Store_2.Application.Userss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store_3.EndPoint.Models.ViewModels.Baskets
{
    public class ShippingPaymentViewModel
    {
        public BasketDto basket { get; set; }
        public List<UserAddressDto> userAddresses { get; set; }
    }
}
