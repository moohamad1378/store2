using Store_2.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_2.Domain.Catalogs
{
    [Auditable]
    public class CatalogBrand
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public ICollection<CataLogItem> cataLogItems { get; set; }
    }
}
