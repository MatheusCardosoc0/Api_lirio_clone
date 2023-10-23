using Api.Models.PersonModel;
using MongoDB.Driver;

namespace Api.Services.Pessoal.PersonService
{
    public class PersonService : IPersonService
    {
        private readonly IMongoCollection<Person> _users;

        public PersonService(IPersonStoreDatbaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _users = database.GetCollection<Person>(settings.PersonCollectionName);
        }


        public List<Person> Get()
        {
            return _users.Find(user => true).ToList();
        }

        public Person Get(string id)
        {
            return _users.Find(user => user.Id == id).FirstOrDefault();
        }

        public Person Create(Person user)
        {
            _users.InsertOne(user);
            return user;
        }

        public void Update(string id, Person user)
        {
            _users.ReplaceOne(user => user.Id == id, user);
        }

        public void Remove(string id)
        {
            _users.DeleteOne(student => student.Id == id);
        }
    }
}
