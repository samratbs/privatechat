using MongoDB.Bson;
using MongoDB.Driver;
using PrivateChat.Domains;
using PrivateChat.Domains.Models;
using PrivateChat.Infrastructure.Data;
using System;

namespace PrivateChat.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {   
        private readonly MongoDbContext _dbContext;
        public UserRepository(MongoDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddUserToDB(User user)
        {            
            var userCollection = _dbContext.GetUserCollection();
            await userCollection.InsertOneAsync(user);
        }

        public async Task<bool> IsUserAvailable(User user)
        {
            var userCollection = _dbContext.GetUserCollection();
            var databaseUsers = await userCollection.Find<User>(x => x.Username == user.Username).ToListAsync();
            return databaseUsers.Count()==0 ? true : false;
        }

        public async Task<List<User>> ValidateCredentials(LoginCredentials userCredentials)
        {
            var userCollection = _dbContext.GetUserCollection();
            var user = await userCollection.Find<User>(x => x.Username == userCredentials.Username && x.Password == userCredentials.Password).ToListAsync();
            return user;
        }
    }
}
