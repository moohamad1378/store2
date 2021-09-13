using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Store_2.Domain.Banners;
using Store_2.Domain.Baskets;
using Store_2.Domain.Catalogs;
using Store_2.Domain.Discounts;
using Store_2.Domain.Orders;
using Store_2.Domain.Payments;
using Store_2.Domain.Users;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Store_2.Application.Interface.Context
{
    public interface IDataBaseContext
    {
       
        DbSet<CatalogBrand> CatalogBrands { get; set; }
        DbSet<CataLogItem> CataLogItems { get; set; }
        DbSet<CatalogType> CatalogTypes { get; set; }
        DbSet<CatalogItemImage> CatalogItemImages { get; set; }
        DbSet<CataLogItemFeature> CataLogItemFeatures { get; set; }
        DbSet<Basket> Baskets { get; set; }
        DbSet<BasketItem> BasketItems { get; set; }
        DbSet<UserAddress> UserAddresses { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<OrderItem> OrderItems { get; set; }
        DbSet<Payment> Payments { get; set; }
        DbSet<Discount> Discounts { get; set; }
        DbSet<DiscountUsageHistory> DiscountUsageHistories { get; set; }
        DbSet<CatalogItemFavorite> CatalogItemFavorites { get; set; }
        DbSet<Banner> Banner { get; set; }
        DbSet<CatalogItemComment> CatalogItemComments { get; set; }
        int SaveChanges();
        int SaveChanges(bool acceptAllChangesOnSuccess);
        EntityEntry Entry([NotNullAttribute] object entity);
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
