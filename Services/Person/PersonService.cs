using Api.Models.PersonModel;
using MongoDB.Driver;

namespace Api.Services.Person
{
    public class PersonService : IPersonService
    {
        private readonly IMongoCollection<Models.PersonModel.Person> _users;

        public PersonService(IPersonStoreDatbaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _users = database.GetCollection<Models.PersonModel.Person>(settings.PersonCollectionName);
        }


        public List<Models.PersonModel.Person> Get()
        {
            return _users.Find(user => true).ToList();
        }

        public Models.PersonModel.Person Get(string id)
        {
            return _users.Find(user => user.Id == id).FirstOrDefault();
        }

        public Models.PersonModel.Person Create(Models.PersonModel.Person user)
        {
            _users.InsertOne(user);
            return user;
        }

        public void Update(string id, Models.PersonModel.Person user)
        {
            _users.ReplaceOne(user => user.Id == id, user);
        }

        public void Remove(string id)
        {
            _users.DeleteOne(student => student.Id == id);
        }
    }
}
