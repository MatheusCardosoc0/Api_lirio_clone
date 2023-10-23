namespace Api.Models.PersonModel
{
    public class PersonStoreDatbaseSettings : IPersonStoreDatbaseSettings
    {
        public string PersonCollectionName { get; set; } = string.Empty;
        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
    }
}
