using MongoDB.Driver;
using Store_2.Application.Interface.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_2.Persistance.Contexts.MongoContexts
{
    public class MongoDBContext<T> : IMongoDBContext<T>
    {
        private readonly IMongoDatabase db;
        private readonly IMongoCollection<T> mongoCollection;
        public MongoDBContext()
        {
            var client = new MongoClient();
            db = client.GetDatabase("VisitorDb");
            mongoCollection = db.GetCollection<T>(typeof(T).Name);
        }
        public IMongoCollection<T> GetCollection()
        {
            return mongoCollection;
        }
    }
}
