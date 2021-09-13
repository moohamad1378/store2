using Microsoft.EntityFrameworkCore;
using Store_2.Application.Interface.Context;
using Store_2.Domain.Attributes;
using Store_2.Domain.Banners;
using Store_2.Domain.Baskets;
using Store_2.Domain.Catalogs;
using Store_2.Domain.Discounts;
using Store_2.Domain.Orders;
using Store_2.Domain.Payments;
using Store_2.Domain.Users;
using Store_2.Persistance.EntityConfigurations;
using Store_2.Persistance.Seeds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Store_2.Persistance.Contexts
{
    public class DataBaseContext : DbContext, IDataBaseContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }
        public DbSet<CataLogItemFeature> CataLogItemFeatures { get; set; }
        public DbSet<CatalogBrand> CatalogBrands { get; set; }
        public DbSet<CataLogItem> CataLogItems { get; set; }
        public DbSet<CatalogType> CatalogTypes { get; set; }
        public DbSet<CatalogItemImage> CatalogItemImages { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<UserAddress> UserAddresses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<DiscountUsageHistory> DiscountUsageHistories { get; set; }
        public DbSet<CatalogItemFavorite> CatalogItemFavorites { get; set; }
        public DbSet<Banner> Banner { get; set; }
        public DbSet<CatalogItemComment> CatalogItemComments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema("dbo");

            foreach (var entitytype in builder.Model.GetEntityTypes())
            {
                if (entitytype.ClrType.GetCustomAttributes(typeof(AuditableAttribute), true).Length > 0)
                {
                    builder.Entity(entitytype.Name).Property<DateTime>("InsertTime").HasDefaultValue(DateTime.Now);
                    builder.Entity(entitytype.Name).Property<DateTime?>("UpdateTime");
                    builder.Entity(entitytype.Name).Property<DateTime?>("RemovedTime");
                    builder.Entity(entitytype.Name).Property<bool>("IsRemoved").HasDefaultValue(false);
                }
            }
            builder.ApplyConfiguration(new CatalogBrandEntityTypeConfiguration());
            builder.ApplyConfiguration(new CatalogTypeEntityTypeConfiguration());



            builder.Entity<CatalogType>()
            .HasQueryFilter(m => EF.Property<bool>(m, "IsRemoved") == false);
            builder.Entity<BasketItem>()
            .HasQueryFilter(m => EF.Property<bool>(m, "IsRemoved") == false);
            builder.Entity<CataLogItem>()
            .HasQueryFilter(m => EF.Property<bool>(m, "IsRemoved") == false);
            builder.Entity<Basket>()
            .HasQueryFilter(m => EF.Property<bool>(m, "IsRemoved") == false);
            builder.Entity<CatalogBrand>()
            .HasQueryFilter(m => EF.Property<bool>(m, "IsRemoved") == false);
            builder.Entity<UserAddress>()
            .HasQueryFilter(m => EF.Property<bool>(m, "IsRemoved") == false);
            builder.Entity<Order>()
            .HasQueryFilter(m => EF.Property<bool>(m, "IsRemoved") == false);
            builder.Entity<OrderItem>()
            .HasQueryFilter(m => EF.Property<bool>(m, "IsRemoved") == false);
            builder.Entity<Discount>()
            .HasQueryFilter(m => EF.Property<bool>(m, "IsRemoved") == false);
            builder.Entity<CatalogItemFavorite>()
            .HasQueryFilter(m => EF.Property<bool>(m, "IsRemoved") == false);



            //DataBaseContextSeed.CatalogSeed(builder);

            builder.Entity<Order>().OwnsOne(p => p.Address);

            base.OnModelCreating(builder);
        }
        public override int SaveChanges()
        {
            var modifiedEntries = ChangeTracker.Entries().Where(p => p.State == EntityState.Modified || p.State == EntityState.Added ||
              p.State == EntityState.Deleted);
            foreach (var item in modifiedEntries)
            {
                var entitytype = item.Context.Model.FindEntityType(item.Entity.GetType());
                if (entitytype != null)
                {
                    var Inserted = entitytype.FindProperty("InsertTime");
                    var updated = entitytype.FindProperty("UpdateTime");
                    var RemodedTime = entitytype.FindProperty("RemovedTime");
                    var IsRemoved = entitytype.FindProperty("IsRemoved");

                    if (item.State == EntityState.Added && Inserted != null)
                    {
                        item.Property("InsertTime").CurrentValue = DateTime.Now;
                    }
                    if (item.State == EntityState.Modified && updated != null)
                    {
                        item.Property("UpdateTime").CurrentValue = DateTime.Now;
                    }
                    if (item.State == EntityState.Deleted && RemodedTime != null && IsRemoved != null)
                    {
                        item.Property("RemovedTime").CurrentValue = DateTime.Now;
                        item.Property("IsRemoved").CurrentValue = true;
                        item.State = EntityState.Modified;
                    }
                }

            }
            return base.SaveChanges();
        }
    }
}
