using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_2.Application.Interface.Context
{
    public interface IMongoDBContext<T>
    {
        public IMongoCollection<T> GetCollection();
    }
}
