using Microsoft.EntityFrameworkCore;
using Store_2.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.Builders
{
    public class DatabaseBuilder
    {
        internal DataBaseContext GetDbContext()
        {
            var option = new DbContextOptionsBuilder<DataBaseContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            return new DataBaseContext(option);
        }
    }
}
