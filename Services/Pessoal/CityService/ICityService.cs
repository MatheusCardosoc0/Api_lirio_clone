using Api.Models.Pessoal;

namespace Api.Services.Pessoal.CityService
{
    public interface ICityService
    {
        List<City> Get();
        City Get(int id);
        City Create(City city);
        void Update(int id, City city);
        void Remove(int id);
    }
}
