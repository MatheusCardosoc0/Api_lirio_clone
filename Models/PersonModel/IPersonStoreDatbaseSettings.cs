namespace Api.Models.PersonModel
{
    public interface IPersonStoreDatbaseSettings
    {
        string PersonCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
