using Common;
using Microsoft.EntityFrameworkCore;
using Store_2.Application.Dtos;
using Store_2.Application.Interface.Context;
using Store_2.ApplicationUriComposer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_2.Application.Catalogs.CatalogItems.GetCatalogItemPLP
{
    public interface IGetCatalogItemPLPService
    {
        PageInatedItemDto<CatalogPLPDto> Execute(CatalogPLPRequestDto requestDto);
    }
    public class GetCatalogItemPLPService : IGetCatalogItemPLPService
    {
        private readonly IDataBaseContext _context;
        private readonly IUriComposerServicer _uriService;
        public GetCatalogItemPLPService(IDataBaseContext context, IUriComposerServicer uriService)
        {
            _context = context;
            _uriService = uriService;
        }
        public PageInatedItemDto<CatalogPLPDto> Execute(CatalogPLPRequestDto requestDto)
        {
            int rowcount = 0;
            var query = _context.CataLogItems
                .Include(p => p.catalogItemImages)
                .Include(p => p.Discounts)
                .OrderByDescending(p => p.Id)
                .AsQueryable();
                
            if(requestDto.BrandId != null)
            {
                query = query.Where(p => requestDto.BrandId.Any(b => b == p.CatalogBrandId));
            }
            if (requestDto.CatalogTypeId != null)
            {
                query = query.Where(p =>p.CatalogTypeId==requestDto.CatalogTypeId);
            }
            if (!string.IsNullOrEmpty(requestDto.SeachKey))
            {
                query = query.Where(p =>p.Name.Contains(requestDto.SeachKey)
                || p.Description.Contains(requestDto.SeachKey));
            }
            if (requestDto.AvailableStock ==true)
            {
                query = query.Where(p =>p.AvailableStock>0);
            }
            if (requestDto.SortType == SortType.BestSelling)
            {
                query = query.Include(p => p.OrderItems).OrderByDescending(p => p.OrderItems.Count());
            }
            if (requestDto.SortType == SortType.MostPopular)
            {
                query = query.Include(p => p.CatalogItemFavorites)
                    .OrderByDescending(p => p.CatalogItemFavorites.Count());
            }
            if (requestDto.SortType == SortType.MostVisited)
            {
                query = query.OrderByDescending(p => p.VisitCount);
            }
            if (requestDto.SortType == SortType.BestSelling)
            {
                query = query.OrderByDescending(p =>p.Id);
            }
            if (requestDto.SortType == SortType.Newwest)
            {
                query = query.OrderByDescending(p => p.Id);
            }
            if (requestDto.SortType == SortType.Cheapest)
            {
                query = query.Include(p => p.Discounts).OrderBy(p=>p.Price);
            }
            if (requestDto.SortType == SortType.Cheapest)
            {
                query = query.Include(p => p.Discounts).OrderByDescending(p => p.Price);
            }

            var data= query.PagedResult(requestDto.page, requestDto.PageSize, out rowcount)
                .Select(p => new CatalogPLPDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Rate = 4,
                    Image = _uriService.ComposeIamgeUri(p.catalogItemImages.FirstOrDefault().Src),
                    AvailableStock=p.AvailableStock
                }).ToList();
            return new PageInatedItemDto<CatalogPLPDto>(requestDto.page, requestDto.PageSize, rowcount, data);

        }
    }
    public class CatalogPLPRequestDto
    {
        public int page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public int? CatalogTypeId { get; set; }
        public int[] BrandId { get; set; }
        public bool AvailableStock { get; set; }
        public string SeachKey { get; set; }
        public SortType SortType { get; set; }
    }
    public enum SortType
    {
        None=0,
        MostVisited=1,
        BestSelling=2,
        MostPopular=3,
        Newwest=4,
        Cheapest=5,
        MostExpensive=6

    }
    public class CatalogPLPDto
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public byte Rate { get; set; }
        public int AvailableStock { get; set; }
    }
}
