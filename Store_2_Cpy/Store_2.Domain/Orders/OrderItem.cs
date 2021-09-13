using Store_2.Domain.Attributes;
using Store_2.Domain.Catalogs;

namespace Store_2.Domain.Orders
{
    [Auditable]
    public class OrderItem
    {
        public int Id { get; set; }
        public int UnitPrice { get; private set; }
        public int Units { get; private set; }
        public CataLogItem CataLogItem { get; set; }
        public int catalogItemId { get; private set; }
        public string ProductName { get; private set; }
        public string PictureUri { get; private set; }
        public OrderItem(int catalogitemid,string productname,string pictureuri, int untiprice, int units)
        {
            UnitPrice = untiprice;
            Units = units;
            catalogItemId = catalogitemid;
            ProductName = productname;
            PictureUri = pictureuri;
        }
        public OrderItem()
        {

        }
    }
}
