using Microsoft.EntityFrameworkCore;
using Store_2.Application.Interface.Context;
using Store_2.ApplicationUriComposer;
using Store_2.Domain.Baskets;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_2.Application.basketsService
{
    public interface IBasketservice
    {
        BasketDto GetOrCreateasketForUser(string BuyerId);
        void AddItemToBasket(int basketid, int catalogitemId, int quantiny = 1);
        bool RemoveItemFromBasket(int ItemId);
        bool SetQouantities(int ItemId, int qouantity);
        BasketDto GetBasketForUser(string UserId);
        void TransferBasket(string anonymousId, string Userid);
    }
    public class Basketservice : IBasketservice
    {
        private readonly IDataBaseContext _context;
        private readonly IUriComposerServicer _uriComposerServicer;
        public Basketservice(IDataBaseContext context, IUriComposerServicer uriComposerServicer)
        {
            _context = context;
            _uriComposerServicer = uriComposerServicer;
        }

        public void AddItemToBasket(int basketid, int catalogitemId, int quantiny = 1)
        {
            var basket = _context.Baskets
                .Include(p => p.Items)
                .ThenInclude(p => p.cataLogItem)
                .ThenInclude(p => p.Discounts)
                .FirstOrDefault(p => p.Id == basketid);
            if (basket == null)
            {
                throw new Exception("Call to the Manager moohamad.maaniat.mm@gmail.com");
            }
            var cataitem = _context.CataLogItems.Find(catalogitemId);
            basket.AddItem(catalogitemId, quantiny, cataitem.Price);
            _context.SaveChanges();
        }

        public BasketDto GetBasketForUser(string UserId)
        {
            var basket = _context.Baskets
                .Include(p => p.Items)
                .ThenInclude(p => p.cataLogItem)
                .ThenInclude(p => p.catalogItemImages)
                .SingleOrDefault(p => p.BuyerId == UserId);
            //        var basket = _context.Baskets
            //.Include(p => p.Items)
            //.SingleOrDefault(p => p.BuyerId == UserId);
            //        var e = _context.CataLogItems
            //            .Include(p => p.catalogItemImages)
            //            .SingleOrDefault(p => basket.BuyerId == UserId);
            if (basket == null)
            {
                return null;
            }
            return new BasketDto
            {
                Id = basket.Id,
                BuyerId = basket.BuyerId,
                Items = basket.Items.Select(Item => new BasKetItemDto
                {
                    CatalogItemId = Item.CataLogItemid,
                    Id = Item.Id,
                    CatalogItemName = Item.cataLogItem.Name,
                    Qountity = Item.Quantity,
                    UnitPrice = Item.UnitPrice,
                    ImageUrl = _uriComposerServicer
                    .ComposeIamgeUri(Item?.cataLogItem?.catalogItemImages?.FirstOrDefault()?.Src ?? ""),
                }).ToList(),
            };
        }

        public BasketDto GetOrCreateasketForUser(string BuyerId)
        {
            var basket = _context.Baskets
                .Include(p=>p.Items)
                .ThenInclude(p=>p.cataLogItem)
                .ThenInclude(p => p.catalogItemImages)
                .Include(p => p.Items)
                .ThenInclude(p => p.cataLogItem)
                .ThenInclude(p=>p.Discounts)
                .SingleOrDefault(p => p.BuyerId == BuyerId);
            if(basket == null)
            {
                return CreateBasketForUser(BuyerId);
            }
            return new BasketDto
            {
                Id = basket.Id,
                BuyerId = basket.BuyerId,
                DiscountAmount=basket.DiscountAmount,
                Items = basket.Items.Select(Item => new BasKetItemDto
                {
                    CatalogItemId = Item.CataLogItemid,
                    Id = Item.Id,
                    CatalogItemName = Item.cataLogItem.Name,
                    Qountity = Item.Quantity,
                    UnitPrice = Item.cataLogItem.Price,
                    ImageUrl = _uriComposerServicer
                    .ComposeIamgeUri(Item?.cataLogItem?.catalogItemImages?.FirstOrDefault()?.Src ?? ""),
                }).ToList(),
            };
        }

        public bool RemoveItemFromBasket(int ItemId)
        {
            var item = _context.BasketItems.SingleOrDefault(p => p.Id == ItemId);
            _context.BasketItems.Remove(item);
            _context.SaveChanges();
            return true;
        }

        public bool SetQouantities(int ItemId, int qouantity)
        {
            var item = _context.BasketItems.SingleOrDefault(p => p.Id == ItemId);
            item.Setquantity(qouantity);
            _context.SaveChanges();
            return true;
        }

        public void TransferBasket(string anonymousId, string Userid)
        {
            var anonymouseBasket = _context.Baskets
                .Include(p=>p.Items)
                .Include(p=>p.ApplieDiscount)
                .SingleOrDefault(p => p.BuyerId == anonymousId);
            if (anonymouseBasket == null) return;
            var userbasket = _context.Baskets.SingleOrDefault(p => p.BuyerId == Userid);
            if (userbasket == null)
            {
                userbasket = new Basket(Userid);
                _context.Baskets.Add(userbasket);
                
            }
            foreach (var item in anonymouseBasket.Items)
            {
                userbasket.AddItem(item.CataLogItemid, item.Quantity, item.UnitPrice);
            }

            if(anonymouseBasket.ApplieDiscount != null)
            {
                userbasket.ApplyDiscountCode(anonymouseBasket.ApplieDiscount);
            }
            _context.Baskets.Remove(anonymouseBasket);
            _context.SaveChanges();
        }

        private BasketDto CreateBasketForUser(string BuyerId)
        {
            Basket basket = new Basket(BuyerId);
            _context.Baskets.Add(basket);
            _context.SaveChanges();
            return new BasketDto()
            {
                BuyerId = basket.BuyerId,
                Id = basket.Id
            };
        }
    }
    public class BasketDto
    {
        public int Id { get; set; }
        public string BuyerId { get; set; }
        public List<BasKetItemDto> items { get; set; } = new List<BasKetItemDto>();
        public int DiscountAmount { get; set; }
        public int Total()
        {
            if (Items.Count > 0)
            {
                int total = Items.Sum(p => p.UnitPrice * p.Qountity);
                total -= DiscountAmount;
                return total;
            }
            return 0;
        }
        public int TotalWithOutDiescount()
        {
            if (Items.Count > 0)
            {
                int total = Items.Sum(p => p.UnitPrice * p.Qountity);
                return total;
            }
            return 0;
        }
        public ICollection<BasKetItemDto> Items { get; set; }
    }
    public class BasKetItemDto
    {
        public int Id { get; set; }
        public int CatalogItemId { get; set; }
        public string CatalogItemName { get; set; }
        public int UnitPrice { get; set; }
        public int Qountity { get; set; }
        public string ImageUrl { get; set; }
    }
}
