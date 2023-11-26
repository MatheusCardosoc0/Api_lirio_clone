using Api.Models.Financeiro;
using Api.Models.Pessoal;
using Api.Utilities;
using MongoDB.Driver;

namespace Api.Services.Pessoal.PersonService
{
    public class PersonService : IPersonService
    {
        private readonly IMongoCollection<Person> _person;

        public PersonService(ISystemDBConfiguration settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _person = database.GetCollection<Person>(settings.Collections.PESSOAL.Person);
        }


        public List<Person> Get()
        {
            return _person.Find(person => true).ToList();
        }

        public Person Get(int id)
        {
            return _person.Find(person => person.Id == id).FirstOrDefault();
        }

        public Person Create(Person person)
        {
            person.Id = GeneratedIdSequence.GenerateNumericId(_person.Database, "Person");
            _person.InsertOne(person);
            return person;
        }

        public void Update(int id, Person person)
        {
            _person.ReplaceOne(person => person.Id == id, person);
        }

        public void Remove(int id)
        {
            _person.DeleteOne(student => student.Id == id);
        }
    }
}
