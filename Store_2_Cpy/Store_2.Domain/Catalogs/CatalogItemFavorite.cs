using Store_2.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_2.Domain.Catalogs
{
    [Auditable]
    public class CatalogItemFavorite
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public CataLogItem CataLogItem { get; set; }
        public int CataLogItemId { get; set; }
    }
}
