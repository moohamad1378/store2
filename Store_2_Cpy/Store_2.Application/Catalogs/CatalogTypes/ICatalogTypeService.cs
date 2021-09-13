using AutoMapper;
using Common;
using Store_2.Application.Dtos;
using Store_2.Application.Interface.Context;
using Store_2.Domain.Catalogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_2.Application.Catalogs.CatalogTypes
{
    public interface ICatalogTypeService
    {
        BaseDto<CatalogTypeDto> Add(CatalogTypeDto catalogType);
        BaseDto Remove(int Id);
        BaseDto<CatalogTypeDto> Edit(CatalogTypeDto catalogType);
        BaseDto<CatalogTypeDto> FindById(int Id);
        PageInatedItemDto<CatalogTypeListDto> GetList(int? ParentId, int Page,int pageSize);
    }

    public class CatalogTypeService : ICatalogTypeService
    {
        private readonly IDataBaseContext _context;
        private readonly IMapper _mapper;
        public CatalogTypeService(IDataBaseContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public BaseDto<CatalogTypeDto> Add(CatalogTypeDto catalogType)
        {
            var model = _mapper.Map<CatalogType>(catalogType);
            _context.CatalogTypes.Add(model);
            _context.SaveChanges();
            return new BaseDto<CatalogTypeDto>(true, new List<string> { $"{model.Type} Added successfuly" }
            , _mapper.Map<CatalogTypeDto>(model));
        }

        public BaseDto<CatalogTypeDto> Edit(CatalogTypeDto catalogType)
        {
            var model = _context.CatalogTypes.SingleOrDefault(p => p.Id == catalogType.Id);
            _mapper.Map(catalogType, model);
            _context.SaveChanges();
            return new BaseDto<CatalogTypeDto>(true, new List<string> { $"{model.Type} Hase Edited Successfuly" }
            ,_mapper.Map<CatalogTypeDto>(model));
        }

        public BaseDto<CatalogTypeDto> FindById(int Id)
        {
            var data = _context.CatalogTypes.Find(Id);
            var result= _mapper.Map<CatalogTypeDto>(data);
            return new BaseDto<CatalogTypeDto>(true, null, result);
        }

        public PageInatedItemDto<CatalogTypeListDto> GetList(int? ParentId, int Page, int pageSize)
        {
            int totalcount = 0;
            var model = _context.CatalogTypes
                .Where(p=>p.ParentCatalogTypeId==ParentId).AsQueryable().PagedResult(Page, pageSize, out totalcount);
            var result = _mapper.ProjectTo<CatalogTypeListDto>(model).ToList();
            return new PageInatedItemDto<CatalogTypeListDto>(Page, pageSize, totalcount, result);
        }

        public BaseDto Remove(int Id)
        {
            var catalogType = _context.CatalogTypes.Find(Id);
            _context.CatalogTypes.Remove(catalogType);
            _context.SaveChanges();
            return new BaseDto(true, new List<string> { $"Item hase Deleted Successfulty" });
        }
    }
    public class CatalogTypeDto
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int? ParentCatalogTypeId { get; set; }

    }
    public class CatalogTypeListDto
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string SubTypeCount { get; set; }
    }
}
