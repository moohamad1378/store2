using AutoMapper;
using Store_2.Application.Catalogs.CatalogItems.AddNewCatalogItem;
using Store_2.Application.Catalogs.CatalogItems.CatalogItemService;
using Store_2.Application.Catalogs.CatalogTypes;
using Store_2.Application.Catalogs.GetMenuItem;
using Store_2.Domain.Catalogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_2.Infrastructure.MappingProfile
{
    public class CatalogMappingProfile:Profile
    {
        public CatalogMappingProfile()
        {
            CreateMap<CatalogType, CatalogTypeDto>().ReverseMap();
            CreateMap<CatalogType, CatalogTypeListDto>().ForMember(dest => dest.SubTypeCount, options =>
               options.MapFrom(src => src.SubType.Count));

            
            CreateMap<CatalogType, MenuItemDto>()
                .ForMember(dest => dest.Name,opt => opt.MapFrom(src => src.Type))
                .ForMember(dest=>dest.ParentId,opt=>opt.MapFrom(src=>src.ParentCatalogTypeId))
                .ForMember(dest=>dest.SubMenu,opt=>opt.MapFrom(src=>src.SubType));

            CreateMap<CataLogItemFeature, AddNewCatalogItemFeature_Dto>().ReverseMap();
            CreateMap<CatalogItemImage, AddNewCatalogItemImage_Dto>().ReverseMap();

            CreateMap<AddNewCatalogItemFeature_Dto, CataLogItemFeature>().ReverseMap();
            CreateMap<AddNewCatalogItemImage_Dto, CatalogItemImage>().ReverseMap();


            CreateMap<CataLogItem, AddNewCatalogItemDto>()
                .ForMember(dest => dest.Feature, opt => opt.MapFrom(src => src.cataLogItemFeatures))
                .ForMember(dest => dest.image, opt => opt.MapFrom(src => src.catalogItemImages))
                .ForMember(dest=>dest.CatalogbrandId,opt=>opt.MapFrom(src=>src.CatalogBrandId))
                .ForMember(dest=>dest.Availablestock,opt=>opt.MapFrom(src=>src.AvailableStock))
                .ForMember(dest=>dest.description,opt=>opt.MapFrom(src=>src.Description))
                .ForMember(dest=>dest.RestockTheshold,opt=>opt.MapFrom(src=>src.RestockThershold))
                .ForMember(dest=>dest.MaxStockThreshold,opt=>opt.MapFrom(src=>src.MaxStockThresjold))
                .ForMember(dest=>dest.Price,opt=>opt.MapFrom(src=>src.Price))
                .ForMember(dest=>dest.Name,opt=>opt.MapFrom(src=>src.Name))
                .ReverseMap();

            CreateMap<CatalogBrand, CatalogBrandDto>().ReverseMap();
            CreateMap<CatalogType, CatalogTypeDto>().ReverseMap();

            

        }

    }
}
