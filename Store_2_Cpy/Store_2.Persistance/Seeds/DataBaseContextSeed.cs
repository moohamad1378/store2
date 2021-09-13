using Microsoft.EntityFrameworkCore;
using Store_2.Domain.Catalogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_2.Persistance.Seeds
{
    public class DataBaseContextSeed
    {
        public static void CatalogSeed(ModelBuilder modelBuilder)
        {
            foreach (var catalog in GetCatalogTypes())
            {
                modelBuilder.Entity<CatalogType>().HasData(catalog);
            }            
            foreach (var brand in CatalogBrands())
            {
                modelBuilder.Entity<CatalogBrand>().HasData(brand);
            }
        }
        private static IEnumerable<CatalogType> GetCatalogTypes()
        {
            return new List<CatalogType>()
            {
                new CatalogType() {  Id=10003,  Type="Digital goods"},
                new CatalogType() {  Id= 10004,  Type="Phone accessories" , ParentCatalogTypeId = 10003},
                new CatalogType() {  Id= 10067,  Type="Phone" , ParentCatalogTypeId = 10003},
                new CatalogType() {  Id= 10005,  Type="Phone holder base" , ParentCatalogTypeId=10004},
                new CatalogType() {  Id= 10006,  Type="Mobile charger power bank", ParentCatalogTypeId=10004},
                new CatalogType() {  Id= 10007,  Type="Phone case and cover", ParentCatalogTypeId=10004},



            };
        }
        private static IEnumerable<CatalogBrand> CatalogBrands()
        {
            return new List<CatalogBrand>()
            {
                new CatalogBrand() {  Id=44,  Brand="Samsung"},
                new CatalogBrand() {  Id= 45,  Brand="Xiaomi" },
                new CatalogBrand() {  Id= 46,  Brand="Apple" },
                new CatalogBrand() {  Id= 47,  Brand="Huawei"},
                new CatalogBrand() {  Id= 48,  Brand="Nokia"},



            };
        }
    }
    
}
