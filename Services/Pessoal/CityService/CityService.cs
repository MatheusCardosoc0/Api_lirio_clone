using Api.Models.Financeiro;
using Api.Models.Pessoal;
using Api.Utilities;
using MongoDB.Driver;

namespace Api.Services.Pessoal.CityService
{
    public class CityService : ICityService
    {
        private readonly IMongoCollection<City> _city;

        public CityService(ISystemDBConfiguration settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _city = database.GetCollection<City>(settings.Collections.PESSOAL.City);
        }
        public City Create(City city)
        {
            city.Id = GeneratedIdSequence.GenerateNumericId(_city.Database, "City");
            _city.InsertOne(city);
            return city;
        }

        public List<City> Get()
        {
            return _city.Find(city => true).ToList();
        }

        public City Get(int id)
        {
            return _city.Find(city => city.Id == id).FirstOrDefault();
        }

        public void Remove(int id)
        {
            _city.DeleteOne(city => city.Id == id);
        }

        public void Update(int id, City city)
        {
            _city.ReplaceOne(city => city.Id == id, city);
        }
    }
}
