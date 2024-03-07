using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using PrivateChat.Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateChat.Infrastructure.Data
{
    public class MongoDbContext
    {
        private IMongoDatabase _db { get; set; }
        private MongoClient _mongoClient { get; set; }
        public IClientSessionHandle Session { get; set; }
        public MongoDbContext(IConfiguration configuration)
        {
            _mongoClient = new MongoClient(configuration.GetSection("MongoDbSettings:ConnectionString").Value);
            _db = _mongoClient.GetDatabase(configuration.GetSection("MongoDbSettings:DatabaseName").Value);
        }
        public IMongoDatabase GetDbInstance()
        {
            return _db;
        }
        public IMongoCollection<User> GetUserCollection()
        {
            return _db.GetCollection<User>(typeof(User).Name);
        }
        public IMongoCollection<Messages> GetMessagesCollection()
        {
            return _db.GetCollection<Messages>(typeof(Messages).Name);
        }
    }
}
