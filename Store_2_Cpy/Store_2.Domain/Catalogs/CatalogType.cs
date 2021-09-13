using Store_2.Domain.Attributes;
using System.Collections.Generic;

namespace Store_2.Domain.Catalogs
{
    [Auditable]
    public class CatalogType
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int? ParentCatalogTypeId { get; set; }
        public CatalogType ParentCatalogType { get; set; }
        public ICollection<CatalogType> SubType { get; set; }
    }
}
