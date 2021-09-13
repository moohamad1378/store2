using Microsoft.EntityFrameworkCore;
using Store_2.Application.Interface.Context;
using Store_2.ApplicationUriComposer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_2.Application.Catalogs.CatalogItems.GetGatalogItemPDP
{
    public interface IGetCatalogItemPDPService
    {
        CatalogItemPDPDto Execute(int Id);
    }
    public class GetCatalogItemPDPService : IGetCatalogItemPDPService
    {
        private readonly IDataBaseContext _context;
        private readonly IUriComposerServicer _uriComposerServicer;
        public GetCatalogItemPDPService(IDataBaseContext context,IUriComposerServicer uriComposerServicer)
        {
            _context = context;
            _uriComposerServicer = uriComposerServicer;
        }
        public CatalogItemPDPDto Execute(int Id)
        {
            var catalogitem = _context.CataLogItems
                .Include(p => p.cataLogItemFeatures)
                .Include(p => p.catalogItemImages)
                .Include(p => p.CatalogType)
                .Include(p => p.CatalogBrand)
                .Include(p=>p.Discounts)
                .SingleOrDefault(p => p.Id == Id);
            catalogitem.VisitCount++;
            _context.SaveChanges();
            var feature = catalogitem.cataLogItemFeatures
                .Select(p => new PDPFeatureDto
                {
                    Group = p.Group,
                    Key = p.Key,
                    Value = p.Valude
                }).ToList().GroupBy(p => p.Group);
            var similarcatalogitems = _context.CataLogItems
                .Include(p=>p.Discounts)
                .Include(p => p.catalogItemImages)
                .Where(p => p.CatalogTypeId == catalogitem.CatalogTypeId).Take(10)
                .Select(p => new SimilarcatalogItemDto
                {
                    Id = p.Id,
                    Images = p.catalogItemImages.FirstOrDefault().Src,
                    Name = p.Name,
                    Price = p.Price
                }).ToList();
            return new CatalogItemPDPDto
            {
                Feature = feature,
                similarcatalogs = similarcatalogitems,
                Id = catalogitem.Id,
                Name = catalogitem.Name,
                Brand = catalogitem.CatalogBrand.Brand,
                Type = catalogitem.CatalogType.Type,
                Price = catalogitem.Price,
                Description = catalogitem.Description,
                Images = catalogitem.catalogItemImages
                .Select(p => _uriComposerServicer.ComposeIamgeUri(p.Src)).ToList(),
                OldPrice = catalogitem?.OldPrice,
                PercentDiscount = catalogitem.PercentDiscount,
            };
        }
    }

    public class CatalogItemPDPDto
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public int? OldPrice { get; set; }
        public int? PercentDiscount { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public List<string> Images { get; set; }
        public IEnumerable<IGrouping<string,PDPFeatureDto>> Feature { get; set; }
        public List<SimilarcatalogItemDto> similarcatalogs { get; set; }
    }
    public class PDPFeatureDto
    {
        public string Group { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
    public class SimilarcatalogItemDto
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public string Name { get; set; }
        public string Images { get; set; }
    }
}
