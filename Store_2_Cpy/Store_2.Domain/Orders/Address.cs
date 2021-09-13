using Store_2.Domain.Attributes;

namespace Store_2.Domain.Orders
{

    public class Address
    {
        public string State { get; private set; }
        public string City { get; private set; }
        public string ZipCode { get; private set; }
        public string PostalAddress { get; private set; }
        public string UserId { get; private set; }
        public string ReciverName { get; private set; }
        public Address(string city, string state, string zipcode, string postaladdress)
        {

            City = city;
            State = state;
            ZipCode = zipcode;
            PostalAddress = postaladdress;
        }
        public Address()
        {

        }
    }
}
