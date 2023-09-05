namespace Api.Models.CityModel
{
    public class CityStoreDatabaseSettings: ICityStoreDatabaseSettings
    {
        public string CityCollectionName { get; set; } = string.Empty;
        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
    }
}
