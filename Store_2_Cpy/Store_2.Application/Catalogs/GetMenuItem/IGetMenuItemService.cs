using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Store_2.Application.Interface.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_2.Application.Catalogs.GetMenuItem
{
    public interface IGetMenuItemService
    {
        List<MenuItemDto> Execute();
    }
    public class GetMenuItemService : IGetMenuItemService
    {
        private readonly IDataBaseContext _context;
        private readonly IMapper _mapper;
        public GetMenuItemService(IDataBaseContext context,IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public List<MenuItemDto> Execute()
        {
            var catalogtype = _context.CatalogTypes.Include(p => p.ParentCatalogType).ToList();
            var data = _mapper.Map<List<MenuItemDto>>(catalogtype);
            return data;
        }
    }
    public class MenuItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public List<MenuItemDto> SubMenu { get; set; }
    }
}
