using Store_2.Application.Interface.Context;
using Store_2.Domain.Banners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_2.Application.banners
{
    public interface IBannerService
    {
        void AddBaner(BannerDto banner);
        List<BannerDto> GetBanners();
    }
    public class BannerService : IBannerService
    {
        private readonly IDataBaseContext _context;
        public BannerService(IDataBaseContext context)
        {
            _context = context;
        }
        public void AddBaner(BannerDto banner)
        {
            _context.Banner.Add(new Banner
            {
                Image = banner.Image,
                Name=banner.Name,
                IsActive = banner.IsActive,
                Link = banner.Link,
                Position = banner.Position,
                Priority = banner.Priority
            });
            _context.SaveChanges();
        }

        public List<BannerDto> GetBanners()
        {
            var banners = _context.Banner
                .Select(p => new BannerDto
                {
                    Name=p.Name,
                    Image = p.Image,
                    IsActive = p.IsActive,
                    Link = p.Link,
                    Position = p.Position,
                    Priority = p.Priority
                }).ToList();
            return banners;
        }
    }
    public class BannerDto
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string Link { get; set; }
        public bool IsActive { get; set; }
        public Position Position { get; set; }
        public int  Priority { get; set; }
    }
}
