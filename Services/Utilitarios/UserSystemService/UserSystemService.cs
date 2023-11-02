using Api.Models.Utilitarios;
using Api.Utilities;
using MongoDB.Driver;
using BCrypt.Net;

namespace Api.Services.Utilitarios.UserSystemService
{
    public class UserSystemService : IUserSystemService
    {
        private readonly IMongoCollection<UserSystem> _users;
        public UserSystemService(ISystemDBConfiguration userSystemStoreDatabaseSettings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(userSystemStoreDatabaseSettings.DatabaseName);
            _users = database.GetCollection<UserSystem>(userSystemStoreDatabaseSettings.Collections.UTILITARIOS.UserSystem);
        }

        public UserSystem Authenticate(string username, string password)
        {
            var user = _users.Find(user => user.Name == username).FirstOrDefault();

            if (user == null)
                return null;

            bool validPassword = BCrypt.Net.BCrypt.Verify(password, user.Password);
            if (!validPassword)
                return null;

            return user;
        }

        public void Delete(string id)
        {
            _users.DeleteOne(user => user.Id == id);
        }

        public List<UserSystem> Get()
        {
            var users = _users.Find(user => true).ToList();
            foreach (var user in users)
            {
                user.Password = null; 
            }
            return users;
        }

        public UserSystem Get(string id)
        {
            var user = _users.Find(user => user.Id == id).FirstOrDefault();
            if (user != null)
            {
                user.Password = null;
            }

            return user;
        }

        public UserSystem Post(UserSystem userSystem)
        {
            userSystem.Password = BCrypt.Net.BCrypt.HashPassword(userSystem.Password);

            _users.InsertOne(userSystem);
            userSystem.Password = null;
            return userSystem;
        }

        public void Put(string id, UserSystem userSystem)
        {
            var existingUser = _users.Find(user => user.Id == id).FirstOrDefault();

            if (existingUser == null)
            {
                throw new Exception("User not found."); 
            }

            if (!string.IsNullOrWhiteSpace(userSystem.Password))
            {
                userSystem.Password = BCrypt.Net.BCrypt.HashPassword(userSystem.Password);
            }
            else
            {
                userSystem.Password = existingUser.Password;
            }

            var update = Builders<UserSystem>.Update
                .Set(u => u.Name, userSystem.Name)
                .Set(u => u.Person, userSystem.Person);

            if (!string.IsNullOrWhiteSpace(userSystem.Password))
            {
                update = update.Set(u => u.Password, userSystem.Password);
            }

            _users.UpdateOne(user => user.Id == id, update);
        }
    }
}
