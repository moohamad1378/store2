using AutoMapper;
using Store_2.Application.Dtos;
using Store_2.Application.Interface.Context;
using Store_2.Domain.Catalogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_2.Application.Catalogs.CatalogItems.AddNewCatalogItem
{
    public interface IAddNewCatalogItemService
    {
        BaseDto<int> Execute(AddNewCatalogItemDto request);
    }
    public class AddNewCatalogItemService : IAddNewCatalogItemService
    {
        private readonly IDataBaseContext _context;
        private readonly IMapper _mapper;
        public AddNewCatalogItemService(IDataBaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public BaseDto<int> Execute(AddNewCatalogItemDto request)
        {
            var newCatalogItem = new CataLogItem
            {
                AvailableStock = request.Availablestock,
                CatalogBrandId = request.CatalogbrandId,
                CatalogTypeId = request.CatalogTypeID,
                Description = request.description,
                MaxStockThresjold = request.MaxStockThreshold,
                Name = request.Name,
                Price = request.Price,
                RestockThershold = request.RestockTheshold
            };

            _context.CataLogItems.Add(newCatalogItem);
            _context.SaveChanges();

            var images = new List<CatalogItemImage>();
            foreach(var image in request.image)
            {
                images.Add(new CatalogItemImage
                {
                    CataLogItemId = newCatalogItem.Id,
                    Src = image.Src
                });
            }

            _context.CatalogItemImages.AddRange(images);
            _context.SaveChanges();
            var features = new List<CataLogItemFeature>();
            foreach (var feature in request.Feature)
            {
                features.Add(new CataLogItemFeature
                {
                    CataLogItemId = newCatalogItem.Id,
                    Group=feature.Group,
                    Valude=feature.Valude,
                    Key=feature.Key

                });
            }
            _context.CataLogItemFeatures.AddRange(features);
            _context.SaveChanges();



            //var catalogitem = _mapper.Map<CataLogItem>(request);
            //_context.CataLogItems.Add(catalogitem);
            //_context.SaveChanges();
            return new BaseDto<int>(true, new List<string> { "Added Successfully" }, newCatalogItem.Id);
        }
    }
    public class AddNewCatalogItemFeature_Dto
    {
        public string Key { get; set; }
        public string Valude { get; set; }
        public string Group { get; set; }
    }

    public class AddNewCatalogItemImage_Dto
    {
        public string Src { get; set; }
    }

}
