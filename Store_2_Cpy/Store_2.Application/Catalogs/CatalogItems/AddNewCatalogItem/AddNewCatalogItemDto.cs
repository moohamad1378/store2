using FluentValidation;
using System.Collections.Generic;

namespace Store_2.Application.Catalogs.CatalogItems.AddNewCatalogItem
{
    public class AddNewCatalogItemDto
    {
        public string Name { get; set; }
        public string description { get; set; }
        public int Price { get; set; }
        public int CatalogTypeID { get; set; }
        public int CatalogbrandId { get; set; }
        public int Availablestock { get; set; }
        public int RestockTheshold { get; set; }
        public int MaxStockThreshold { get; set; }
        public List<AddNewCatalogItemFeature_Dto> Feature { get; set; }
        public List<AddNewCatalogItemImage_Dto> image { get; set; }
    }
    public class AddNewCatalogItemDtoValidator : AbstractValidator<AddNewCatalogItemDto>
    {
        public AddNewCatalogItemDtoValidator()
        {
            RuleFor(p => p.Name).NotNull().WithMessage("The name of Catalog can not be null");
            RuleFor(p => p.description).NotNull().WithMessage("The name decscription can not be null");
            RuleFor(p => p.Name).Length(2, 100);
            RuleFor(p => p.Availablestock).InclusiveBetween(0, int.MaxValue);
            RuleFor(p => p.Price).InclusiveBetween(0, int.MaxValue);
            RuleFor(p => p.Price).NotNull();
            RuleFor(p => p.image).NotNull();
        }
    }
}
