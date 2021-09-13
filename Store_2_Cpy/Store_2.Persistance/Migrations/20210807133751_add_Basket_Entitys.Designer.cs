﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Store_2.Persistance.Contexts;

namespace Store_2.Persistance.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20210807133751_add_Basket_Entitys")]
    partial class add_Basket_Entitys
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Store_2.Domain.Baskets.Basket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BuyerId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("InsertTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2021, 8, 7, 18, 7, 50, 284, DateTimeKind.Local).AddTicks(3463));

                    b.Property<bool>("IsRemoved")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<DateTime?>("RemovedTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

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
                        .HasDefaultValue(new DateTime(2021, 8, 7, 18, 7, 50, 301, DateTimeKind.Local).AddTicks(6704));

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

                    b.Property<int?>("CatalogBrandId")
                        .HasColumnType("int");

                    b.Property<int>("CatalogTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("InsertTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2021, 8, 7, 18, 7, 50, 302, DateTimeKind.Local).AddTicks(1660));

                    b.Property<bool>("IsRemoved")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int>("MaxStockThresjold")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<DateTime?>("RemovedTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("RestockThershold")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

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
                        .HasDefaultValue(new DateTime(2021, 8, 7, 18, 7, 50, 302, DateTimeKind.Local).AddTicks(5352));

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

                    b.ToTable("CataLogItemFeature");
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
                        .HasDefaultValue(new DateTime(2021, 8, 7, 18, 7, 50, 302, DateTimeKind.Local).AddTicks(7618));

                    b.Property<bool>("IsRemoved")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<DateTime?>("RemovedTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("CatalogBrand");

                    b.HasData(
                        new
                        {
                            Id = 44,
                            Brand = "Samsung"
                        },
                        new
                        {
                            Id = 45,
                            Brand = "Xiaomi"
                        },
                        new
                        {
                            Id = 46,
                            Brand = "Apple"
                        },
                        new
                        {
                            Id = 47,
                            Brand = "Huawei"
                        },
                        new
                        {
                            Id = 48,
                            Brand = "Nokia"
                        });
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

                    b.ToTable("CatalogItemImage");
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
                        .HasDefaultValue(new DateTime(2021, 8, 7, 18, 7, 50, 303, DateTimeKind.Local).AddTicks(141));

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

                    b.ToTable("CatalogType");

                    b.HasData(
                        new
                        {
                            Id = 10003,
                            Type = "Digital goods"
                        },
                        new
                        {
                            Id = 10004,
                            ParentCatalogTypeId = 10003,
                            Type = "Phone accessories"
                        },
                        new
                        {
                            Id = 10067,
                            ParentCatalogTypeId = 10003,
                            Type = "Phone"
                        },
                        new
                        {
                            Id = 10005,
                            ParentCatalogTypeId = 10004,
                            Type = "Phone holder base"
                        },
                        new
                        {
                            Id = 10006,
                            ParentCatalogTypeId = 10004,
                            Type = "Mobile charger power bank"
                        },
                        new
                        {
                            Id = 10007,
                            ParentCatalogTypeId = 10004,
                            Type = "Phone case and cover"
                        });
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
                        .WithMany()
                        .HasForeignKey("CatalogBrandId");

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

            modelBuilder.Entity("Store_2.Domain.Baskets.Basket", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("Store_2.Domain.Catalogs.CataLogItem", b =>
                {
                    b.Navigation("cataLogItemFeatures");

                    b.Navigation("catalogItemImages");
                });

            modelBuilder.Entity("Store_2.Domain.Catalogs.CatalogType", b =>
                {
                    b.Navigation("SubType");
                });
#pragma warning restore 612, 618
        }
    }
}
