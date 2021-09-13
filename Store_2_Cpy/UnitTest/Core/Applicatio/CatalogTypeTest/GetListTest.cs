using Store_2.Application.Catalogs.CatalogTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest.Builders;
using Xunit;
using AutoMapper;
using Store_2.Infrastructure.MappingProfile;

namespace UnitTest.Core.Applicatio.CatalogTypeTest
{
    public class GetListTest
    {
        [Fact]
        public void List_Should_return_List_Of_catalogtypes()
        {
            //Arrange
            var databasebuilder = new DatabaseBuilder();
            var dbcontext = databasebuilder.GetDbContext();
            var mockMapper = new MapperConfiguration(cfg =>
              {
                  cfg.AddProfile(new CatalogMappingProfile());
              });
            var mapper = mockMapper.CreateMapper();
            var service =new CatalogTypeService(dbcontext, mapper);
            service.Add(new CatalogTypeDto
            {
                Id = 2,
                Type = "t21"
            });
            var result = service.GetList(null, 1, 20);
            //Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Count);
        }
    }
}
