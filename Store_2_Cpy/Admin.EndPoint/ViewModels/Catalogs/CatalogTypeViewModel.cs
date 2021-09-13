using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.EndPoint.ViewModels.Catalogs
{
    public class CatalogTypeViewModel
    {
        public int Id { get; set; }
        [Display(Name ="Name Of Category")]
        [Required]
        public string Type { get; set; }
        public int? ParentCatalogTypeId { get; set; }
    }
}
