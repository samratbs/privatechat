using MongoDB.Bson;
using MongoDB.Driver;
using PrivateChat.Domains;
using PrivateChat.Domains.Models;
using PrivateChat.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateChat.Infrastructure.Repository
{
    public class ChatRepository : IChatRepository
    {
        private readonly MongoDbContext _dbContext;
        public ChatRepository(MongoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Messages>> GetAllMessages()
        {
            var messagesCollection = _dbContext.GetMessagesCollection();
            return await messagesCollection.Find<Messages>(new BsonDocument()).ToListAsync();
        }

        public async Task SaveMessageToDb(Messages message)
        {
            var messagesCollection = _dbContext.GetMessagesCollection();
            await messagesCollection.InsertOneAsync(message);
        }
    }
}
