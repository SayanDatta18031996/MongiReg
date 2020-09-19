using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using RegMongo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegMongo.Service
{
    public class RegService
    {
        private readonly IMongoCollection<RegModel> reg;

        public RegService(IConfiguration config)
        {
            MongoClient client = new MongoClient(config.GetConnectionString("Test"));
            IMongoDatabase database = client.GetDatabase("Test");
            reg = database.GetCollection<RegModel>("reg");
        }
        public List<RegModel> Get()
        {
            return reg.Find(reg=> true).ToList();
        }

        public RegModel Get(string id)
        {
            return reg.Find(reg => reg.Id == id).FirstOrDefault();
        }
        public RegModel Create(RegModel regModel)
        {
            reg.InsertOne(regModel);
            return regModel;
        }

        public async Task<RegModel> Search(LoginModel loginModel)
        {
            var filter = Builders<RegModel>.Filter.Eq(x => x.Email, loginModel.Email);
            return await reg.Find(filter).FirstOrDefaultAsync();    
        }

    }
}
