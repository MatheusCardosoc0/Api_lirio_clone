using Api.Models.Utilitarios;
using Api.Utilities;
using MongoDB.Driver;

namespace Api.Services.Utilitarios.UserSystemService
{
    public class UserSystemService : IUserSystemService
    {
        private readonly IMongoCollection<UserSystem> _users;
        public UserSystemService(ISystemDBConfiguration userSystemStoreDatabaseSettings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(userSystemStoreDatabaseSettings.DatabaseName);
            _users = database.GetCollection<UserSystem>(userSystemStoreDatabaseSettings.Collections.UTILITÁRIOS.UserSystem);
        }
        public void Delete(string id)
        {
            _users.DeleteOne(user => user.id == id);
        }

        public List<UserSystem> Get()
        {
            return _users.Find(user => true).ToList();
        }

        public UserSystem Get(string id)
        {
            return _users.Find(user => user.id == id).FirstOrDefault();
        }

        public UserSystem Post(UserSystem userSystem)
        {
            _users.InsertOne(userSystem);
            return userSystem;
        }

        public void Put(string id, UserSystem userSystem)
        {
            _users.ReplaceOne(user => user.id == id, userSystem);
        }
    }
}
