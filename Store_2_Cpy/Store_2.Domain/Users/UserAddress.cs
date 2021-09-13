using Store_2.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_2.Domain.Users
{
    [Auditable]
    public class UserAddress
    {
        public int Id { get; set; }
        public string State { get; private set; }
        public string City { get; private set; }
        public string ZipCode { get; private set; }
        public string PostalAddress { get; private set; }
        public string UserId { get; private set; }
        public string ReciverName { get; private set; }
        public UserAddress(string city, string state, string zipcoe, string postaladdress,
            string userid, string recivername)
        {
            this.City = city;
            State = state;
            ZipCode = zipcoe;
            PostalAddress = postaladdress;
            UserId = userid;
            ReciverName = recivername;
        }
        public  UserAddress()
        {

        }
    }
}
