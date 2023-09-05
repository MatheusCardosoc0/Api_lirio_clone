namespace Api.Services.CityService
{
    public interface ICityService
    {
        List<Models.CityModel.City> Get();
        Models.CityModel.City Get(string id);
        Models.CityModel.City Create(Models.CityModel.City city);
        void Update(string id, Models.CityModel.City city);
        void Remove(string id);
    }
}
