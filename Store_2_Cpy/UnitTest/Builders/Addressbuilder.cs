using Store_2.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.Builders
{
    public class Addressbuilder
    {
        private Address _address;
        public string TestCity => "Tehran";
        public string TestState => "ValiAsr";
        public string TestZipCode => "2784978";
        public string TestPostalAddress => "negar tower";
        public Addressbuilder()
        {
            _address = WithDefaultValues();
        }
        public Address Build()
        {
            return _address;
        }
        private Address WithDefaultValues()
        {
            _address = new Address(TestCity, TestState, TestZipCode, TestPostalAddress);
            return _address;
        }
    }
}
