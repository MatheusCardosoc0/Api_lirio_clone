namespace Api.Models.CityModel
{
    public interface ICityStoreDatabaseSettings
    {
        string CityCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
