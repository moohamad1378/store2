using Store_2.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_2.Domain.Catalogs
{
    [Auditable]
    public class CatalogItemComment
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Comment { get; set; }
        public CataLogItem cataLogItem { get; set; }
        public int cataLogItemId { get; set; }
    }
}
