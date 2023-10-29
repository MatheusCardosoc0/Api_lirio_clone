using Api.Models.Pessoal;

namespace Api.Services.Pessoal.CityService
{
    public interface ICityService
    {
        List<City> Get();
        City Get(string id);
        City Create(City city);
        void Update(string id, City city);
        void Remove(string id);
    }
}
