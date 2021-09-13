using Store_2.Application.Catalogs.CatalogItems.GetCatalogItemPLP;
using Store_2.Application.Catalogs.CatalogItems.GetGatalogItemPDP;
using Store_2.Application.Interface.Context;
using Store_2.ApplicationUriComposer;
using Store_2.Domain.Banners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_2.Application.HomePageService
{
    public interface IHomePageService
    {
        HomePageDto GetData();
    }
    public class HomePageService : IHomePageService
    {
        private readonly IDataBaseContext context;
        private readonly IUriComposerServicer uriComposerService;
        private readonly IGetCatalogItemPLPService getCatalogIItemPLPService;

        public HomePageService(IDataBaseContext context
            , IUriComposerServicer uriComposerService
            , IGetCatalogItemPLPService getCatalogIItemPLPService)
        {
            this.context = context;
            this.uriComposerService = uriComposerService;
            this.getCatalogIItemPLPService = getCatalogIItemPLPService;
        }
        public HomePageDto GetData()
        {
            var banners = context.Banner.Where(p => p.IsActive == true)
                .OrderBy(p => p.Priority)
                .ThenByDescending(p => p.Id)
                .Select(p => new BannerDto
                {
                    Id = p.Id,
                    Image = uriComposerService.ComposeIamgeUri(p.Image),
                    Link = p.Link,
                    Position = p.Position,
                }).ToList();

            var Bestselling = getCatalogIItemPLPService.Execute(new CatalogPLPRequestDto
            {
                AvailableStock = true,
                page = 1,
                PageSize = 20,
                SortType = SortType.BestSelling
            }).Data.ToList();

            var MostPopular = getCatalogIItemPLPService.Execute(new CatalogPLPRequestDto
            {
                AvailableStock = true,
                page = 1,
                PageSize = 20,
                SortType = SortType.MostPopular
            }).Data.ToList();

            return new HomePageDto
            {
                Banners = banners,
                BestSellers = Bestselling,
                MostPoPular = MostPopular,
            };
        }
    }
    public class HomePageDto
    {
        public List<BannerDto> Banners { get; set; }
        public List<CatalogPLPDto> MostPoPular { get; set; }
        public List<CatalogPLPDto> BestSellers { get; set; }

    }
    public class BannerDto
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Link { get; set; }
        public Position Position { get; set; }
    }
}
