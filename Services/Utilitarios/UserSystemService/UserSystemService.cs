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

            // Verificar a senha usando BCrypt
            bool validPassword = BCrypt.Net.BCrypt.Verify(password, user.Password);  // Modifique aqui
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
            _users.ReplaceOne(user => user.Id == id, userSystem);
        }
    }
}
