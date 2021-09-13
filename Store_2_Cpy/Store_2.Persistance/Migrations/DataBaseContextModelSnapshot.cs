﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Store_2.Persistance.Contexts;

namespace Store_2.Persistance.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    partial class DataBaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CataLogItemDiscount", b =>
                {
                    b.Property<int>("DiscountsId")
                        .HasColumnType("int");

                    b.Property<int>("cataLogItemsId")
                        .HasColumnType("int");

                    b.HasKey("DiscountsId", "cataLogItemsId");

                    b.HasIndex("cataLogItemsId");

                    b.ToTable("CataLogItemDiscount");
                });

            modelBuilder.Entity("Store_2.Domain.Banners.Banner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Link")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Banner");
                });

            modelBuilder.Entity("Store_2.Domain.Baskets.Basket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ApplieDiscountId")
                        .HasColumnType("int");

                    b.Property<string>("BuyerId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DiscountAmount")
                        .HasColumnType("int");

                    b.Property<DateTime>("InsertTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2021, 8, 27, 20, 15, 43, 123, DateTimeKind.Local).AddTicks(5360));

                    b.Property<bool>("IsRemoved")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<DateTime?>("RemovedTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ApplieDiscountId");

                    b.ToTable("Baskets");
                });

            modelBuilder.Entity("Store_2.Domain.Baskets.BasketItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BasketId")
                        .HasColumnType("int");

                    b.Property<int>("CataLogItemid")
                        .HasColumnType("int");

                    b.Property<DateTime>("InsertTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2021, 8, 27, 20, 15, 43, 130, DateTimeKind.Local).AddTicks(796));

                    b.Property<bool>("IsRemoved")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<DateTime?>("RemovedTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("UnitPrice")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BasketId");

                    b.HasIndex("CataLogItemid");

                    b.ToTable("BasketItems");
                });

            modelBuilder.Entity("Store_2.Domain.Catalogs.CataLogItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AvailableStock")
                        .HasColumnType("int");

                    b.Property<int>("CatalogBrandId")
                        .HasColumnType("int");

                    b.Property<int>("CatalogTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("InsertTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2021, 8, 27, 20, 15, 43, 130, DateTimeKind.Local).AddTicks(4613));

                    b.Property<bool>("IsRemoved")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int>("MaxStockThresjold")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OldPrice")
                        .HasColumnType("int");

                    b.Property<int?>("PercentDiscount")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<DateTime?>("RemovedTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("RestockThershold")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("VisitCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CatalogBrandId");

                    b.HasIndex("CatalogTypeId");

                    b.ToTable("CataLogItems");
                });

            modelBuilder.Entity("Store_2.Domain.Catalogs.CataLogItemFeature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CataLogItemId")
                        .HasColumnType("int");

                    b.Property<string>("Group")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("InsertTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2021, 8, 27, 20, 15, 43, 130, DateTimeKind.Local).AddTicks(9638));

                    b.Property<bool>("IsRemoved")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Key")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("RemovedTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Valude")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CataLogItemId");

                    b.ToTable("CataLogItemFeatures");
                });

            modelBuilder.Entity("Store_2.Domain.Catalogs.CatalogBrand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("InsertTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2021, 8, 27, 20, 15, 43, 131, DateTimeKind.Local).AddTicks(1721));

                    b.Property<bool>("IsRemoved")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<DateTime?>("RemovedTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("CatalogBrands");
                });

            modelBuilder.Entity("Store_2.Domain.Catalogs.CatalogItemComment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("InsertTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2021, 8, 27, 20, 15, 43, 131, DateTimeKind.Local).AddTicks(3746));

                    b.Property<bool>("IsRemoved")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<DateTime?>("RemovedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("cataLogItemId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("cataLogItemId");

                    b.ToTable("CatalogItemComments");
                });

            modelBuilder.Entity("Store_2.Domain.Catalogs.CatalogItemFavorite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CataLogItemId")
                        .HasColumnType("int");

                    b.Property<DateTime>("InsertTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2021, 8, 27, 20, 15, 43, 131, DateTimeKind.Local).AddTicks(6021));

                    b.Property<bool>("IsRemoved")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<DateTime?>("RemovedTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CataLogItemId");

                    b.ToTable("CatalogItemFavorites");
                });

            modelBuilder.Entity("Store_2.Domain.Catalogs.CatalogItemImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CataLogItemId")
                        .HasColumnType("int");

                    b.Property<string>("Src")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CataLogItemId");

                    b.ToTable("CatalogItemImages");
                });

            modelBuilder.Entity("Store_2.Domain.Catalogs.CatalogType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("InsertTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2021, 8, 27, 20, 15, 43, 131, DateTimeKind.Local).AddTicks(8844));

                    b.Property<bool>("IsRemoved")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int?>("ParentCatalogTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("RemovedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ParentCatalogTypeId");

                    b.ToTable("CatalogTypes");
                });

            modelBuilder.Entity("Store_2.Domain.Discounts.Discount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CoponCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DiscountAmount")
                        .HasColumnType("int");

                    b.Property<int>("DiscountLimitationId")
                        .HasColumnType("int");

                    b.Property<int>("DiscountPercentage")
                        .HasColumnType("int");

                    b.Property<int>("DiscountTypeid")
                        .HasColumnType("int");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("InsertTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2021, 8, 27, 20, 15, 43, 132, DateTimeKind.Local).AddTicks(2069));

                    b.Property<bool>("IsRemoved")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("RemovedTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("RequiredCouponCode")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("UsePercentage")
                        .HasColumnType("bit");

                    b.Property<int>("limitationTimes")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Discounts");
                });

            modelBuilder.Entity("Store_2.Domain.Discounts.DiscountUsageHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("DiscountId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DiscountId");

                    b.HasIndex("OrderId");

                    b.ToTable("DiscountUsageHistories");
                });

            modelBuilder.Entity("Store_2.Domain.Orders.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AppliedDiscountId")
                        .HasColumnType("int");

                    b.Property<decimal>("DiscountAmout")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("InsertTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2021, 8, 27, 20, 15, 43, 132, DateTimeKind.Local).AddTicks(6722));

                    b.Property<bool>("IsRemoved")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrderStatuse")
                        .HasColumnType("int");

                    b.Property<int>("PaymentMethod")
                        .HasColumnType("int");

                    b.Property<int>("PaymentStatue")
                        .HasColumnType("int");

                    b.Property<DateTime?>("RemovedTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AppliedDiscountId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Store_2.Domain.Orders.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("InsertTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2021, 8, 27, 20, 15, 43, 133, DateTimeKind.Local).AddTicks(1284));

                    b.Property<bool>("IsRemoved")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<string>("PictureUri")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("RemovedTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("UnitPrice")
                        .HasColumnType("int");

                    b.Property<int>("Units")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("catalogItemId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("catalogItemId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("Store_2.Domain.Payments.Payment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Ammount")
                        .HasColumnType("int");

                    b.Property<string>("Authority")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DatePay")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("InsertTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2021, 8, 27, 20, 15, 43, 133, DateTimeKind.Local).AddTicks(3855));

                    b.Property<bool>("IsPay")
                        .HasColumnType("bit");

                    b.Property<bool>("IsRemoved")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<long>("RefId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("RemovedTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("Store_2.Domain.Users.UserAddress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("InsertTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2021, 8, 27, 20, 15, 43, 133, DateTimeKind.Local).AddTicks(5996));

                    b.Property<bool>("IsRemoved")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("PostalAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReciverName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("RemovedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZipCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserAddresses");
                });

            modelBuilder.Entity("CataLogItemDiscount", b =>
                {
                    b.HasOne("Store_2.Domain.Discounts.Discount", null)
                        .WithMany()
                        .HasForeignKey("DiscountsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Store_2.Domain.Catalogs.CataLogItem", null)
                        .WithMany()
                        .HasForeignKey("cataLogItemsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Store_2.Domain.Baskets.Basket", b =>
                {
                    b.HasOne("Store_2.Domain.Discounts.Discount", "ApplieDiscount")
                        .WithMany()
                        .HasForeignKey("ApplieDiscountId");

                    b.Navigation("ApplieDiscount");
                });

            modelBuilder.Entity("Store_2.Domain.Baskets.BasketItem", b =>
                {
                    b.HasOne("Store_2.Domain.Baskets.Basket", null)
                        .WithMany("Items")
                        .HasForeignKey("BasketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Store_2.Domain.Catalogs.CataLogItem", "cataLogItem")
                        .WithMany()
                        .HasForeignKey("CataLogItemid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("cataLogItem");
                });

            modelBuilder.Entity("Store_2.Domain.Catalogs.CataLogItem", b =>
                {
                    b.HasOne("Store_2.Domain.Catalogs.CatalogBrand", "CatalogBrand")
                        .WithMany("cataLogItems")
                        .HasForeignKey("CatalogBrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Store_2.Domain.Catalogs.CatalogType", "CatalogType")
                        .WithMany()
                        .HasForeignKey("CatalogTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CatalogBrand");

                    b.Navigation("CatalogType");
                });

            modelBuilder.Entity("Store_2.Domain.Catalogs.CataLogItemFeature", b =>
                {
                    b.HasOne("Store_2.Domain.Catalogs.CataLogItem", "CataLogItem")
                        .WithMany("cataLogItemFeatures")
                        .HasForeignKey("CataLogItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CataLogItem");
                });

            modelBuilder.Entity("Store_2.Domain.Catalogs.CatalogItemComment", b =>
                {
                    b.HasOne("Store_2.Domain.Catalogs.CataLogItem", "cataLogItem")
                        .WithMany()
                        .HasForeignKey("cataLogItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("cataLogItem");
                });

            modelBuilder.Entity("Store_2.Domain.Catalogs.CatalogItemFavorite", b =>
                {
                    b.HasOne("Store_2.Domain.Catalogs.CataLogItem", "CataLogItem")
                        .WithMany("CatalogItemFavorites")
                        .HasForeignKey("CataLogItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CataLogItem");
                });

            modelBuilder.Entity("Store_2.Domain.Catalogs.CatalogItemImage", b =>
                {
                    b.HasOne("Store_2.Domain.Catalogs.CataLogItem", "CataLogItem")
                        .WithMany("catalogItemImages")
                        .HasForeignKey("CataLogItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CataLogItem");
                });

            modelBuilder.Entity("Store_2.Domain.Catalogs.CatalogType", b =>
                {
                    b.HasOne("Store_2.Domain.Catalogs.CatalogType", "ParentCatalogType")
                        .WithMany("SubType")
                        .HasForeignKey("ParentCatalogTypeId");

                    b.Navigation("ParentCatalogType");
                });

            modelBuilder.Entity("Store_2.Domain.Discounts.DiscountUsageHistory", b =>
                {
                    b.HasOne("Store_2.Domain.Discounts.Discount", "Discount")
                        .WithMany()
                        .HasForeignKey("DiscountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Store_2.Domain.Orders.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Discount");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Store_2.Domain.Orders.Order", b =>
                {
                    b.HasOne("Store_2.Domain.Discounts.Discount", "AppliedDiscount")
                        .WithMany()
                        .HasForeignKey("AppliedDiscountId");

                    b.OwnsOne("Store_2.Domain.Orders.Address", "Address", b1 =>
                        {
                            b1.Property<int>("OrderId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("City")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("PostalAddress")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("ReciverName")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("State")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("UserId")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("ZipCode")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("OrderId");

                            b1.ToTable("Orders");

                            b1.WithOwner()
                                .HasForeignKey("OrderId");
                        });

                    b.Navigation("Address");

                    b.Navigation("AppliedDiscount");
                });

            modelBuilder.Entity("Store_2.Domain.Orders.OrderItem", b =>
                {
                    b.HasOne("Store_2.Domain.Orders.Order", null)
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId");

                    b.HasOne("Store_2.Domain.Catalogs.CataLogItem", "CataLogItem")
                        .WithMany("OrderItems")
                        .HasForeignKey("catalogItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CataLogItem");
                });

            modelBuilder.Entity("Store_2.Domain.Payments.Payment", b =>
                {
                    b.HasOne("Store_2.Domain.Orders.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Store_2.Domain.Baskets.Basket", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("Store_2.Domain.Catalogs.CataLogItem", b =>
                {
                    b.Navigation("CatalogItemFavorites");

                    b.Navigation("cataLogItemFeatures");

                    b.Navigation("catalogItemImages");

                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("Store_2.Domain.Catalogs.CatalogBrand", b =>
                {
                    b.Navigation("cataLogItems");
                });

            modelBuilder.Entity("Store_2.Domain.Catalogs.CatalogType", b =>
                {
                    b.Navigation("SubType");
                });

            modelBuilder.Entity("Store_2.Domain.Orders.Order", b =>
                {
                    b.Navigation("OrderItems");
                });
#pragma warning restore 612, 618
        }
    }
}
