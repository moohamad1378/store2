using AutoMapper;
using Common;
using Microsoft.EntityFrameworkCore;
using Store_2.Application.Dtos;
using Store_2.Application.Interface.Context;
using Store_2.ApplicationUriComposer;
using Store_2.Domain.Catalogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_2.Application.Catalogs.CatalogItems.CatalogItemService
{
    public interface ICatalogItemService
    {
        List<CatalogBrandDto> GetBrand();
        List<ListCatalogTypeDto> GetCatalogType();
        PageInatedItemDto<CatalogItemListDto> GetCatalogList(int page, int pagesize);
        void AddToMyFavuorite(string UserId, int CatalogItemid);
        PageInatedItemDto<FavouriteCaatalogItemDto> GetMyFavourite(string UserId, int Page = 1,
            int pagesize = 20);
    }
    public class CatalogItemService : ICatalogItemService
    {
        private readonly IDataBaseContext _context;
        private readonly IMapper _mapper;
        private readonly IUriComposerServicer _uriComposerServicer;
        public CatalogItemService(IDataBaseContext context,IMapper mapper
            , IUriComposerServicer uriComposerServicer)
        {
            _context = context;
            _mapper = mapper;
            _uriComposerServicer = uriComposerServicer;
        }

        public void AddToMyFavuorite(string UserId, int CatalogItemid)
        {
            var catalogitem = _context.CataLogItems.Find(CatalogItemid);
            CatalogItemFavorite catalogItemFavorite = new CatalogItemFavorite()
            {
                CataLogItem = catalogitem,
                UserId = UserId,
            };
            _context.CatalogItemFavorites.Add(catalogItemFavorite);
            _context.SaveChanges();
        }

        public List<CatalogBrandDto> GetBrand()
        {
            var brands = _context.CatalogBrands.OrderBy(p => p.Brand).Take(500).ToList();
            var data = _mapper.Map<List<CatalogBrandDto>>(brands);
            return data;
        }

        public PageInatedItemDto<CatalogItemListDto> GetCatalogList(int page, int pagesize)
        {
            int rowcount = 0;
            var data = _context.CataLogItems
                .Include(p=>p.Discounts)
                .Include(p => p.CatalogType)
                .Include(p => p.CatalogBrand)
                .ToPaged(page, pagesize, out rowcount).OrderByDescending(p => p.Id)
                .Select(p => new CatalogItemListDto
                {
                    Availabestock = p.AvailableStock,
                    Id = p.Id,
                    Brand = p.CatalogBrand.Brand,
                    Type = p.CatalogType.Type,
                    MaxStockThreshold = p.MaxStockThresjold,
                    Name = p.Name,
                    Price = p.Price,
                    RestockThreshold = p.RestockThershold
                }).ToList();
            return new PageInatedItemDto<CatalogItemListDto>(page, pagesize, rowcount, data);
        }

        public List<ListCatalogTypeDto> GetCatalogType()
        {
            var types = _context.CatalogTypes.Include(p => p.ParentCatalogType)
                .Include(p => p.ParentCatalogType)
                .ThenInclude(p => p.ParentCatalogType.ParentCatalogType)
                .Include(p => p.SubType).
                Where(p => p.ParentCatalogTypeId != null)
                .Where(p => p.SubType.Count == 0)
                .Select(p => new { p.Id, p.Type, p.ParentCatalogType, p.SubType }).ToList()
                .Select(p => new ListCatalogTypeDto
                {
                    Id = p.Id,
                    Type = $"{p?.Type ?? ""}-{p?.ParentCatalogType?.Type ?? ""} - {p?.ParentCatalogType?.Type??""}"
                }).ToList();
            return types;
            
        }

        public PageInatedItemDto<FavouriteCaatalogItemDto> GetMyFavourite(string UserId, int Page = 1, int pagesize = 20)
        {
            var model = _context.CataLogItems
                .Include(p => p.catalogItemImages)
                .Include(p => p.Discounts)
                .Include(p => p.CatalogItemFavorites)
                .Where(p => p.CatalogItemFavorites.Any(f => f.UserId == UserId))
                .OrderByDescending(p => p.Id)
                .AsQueryable();
            int rowCont = 0;
            var data = model.PagedResult(Page, pagesize, out rowCont)
            .ToList()
            .Select(p => new FavouriteCaatalogItemDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Rate = 4,
                AvaliableStok = p.AvailableStock,
                Image = _uriComposerServicer
                .ComposeIamgeUri(p.catalogItemImages.FirstOrDefault().Src),
            }).ToList();
            return new PageInatedItemDto<FavouriteCaatalogItemDto>(Page, pagesize, rowCont, data);

        }
    }
    public class FavouriteCaatalogItemDto
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public int Rate { get; set; }
        public int AvaliableStok { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
    }
    public class CatalogBrandDto
    {
        public int Id { get; set; }
        public string Brand { get; set; }
    }
    public class ListCatalogTypeDto
    {
        public int Id { get; set; }
        public string Type { get; set; }
    }
    public class CatalogItemListDto
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Brand { get; set; }
        public int Availabestock { get; set; }
        public int RestockThreshold { get; set; }
        public int MaxStockThreshold { get; set; }
    }
}
