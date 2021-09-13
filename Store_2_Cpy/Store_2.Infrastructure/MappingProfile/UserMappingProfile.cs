using AutoMapper;
using Store_2.Application.Userss;
using Store_2.Domain.Orders;
using Store_2.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_2.Infrastructure.MappingProfile
{
    public class UserMappingProfile:Profile
    {
        public UserMappingProfile()
        {
            CreateMap<UserAddress, UserAddressDto>().ReverseMap();
            CreateMap<AddUserAddressDto, UserAddress>().ReverseMap();

            CreateMap<UserAddress, Address>();
        }
    }
}
