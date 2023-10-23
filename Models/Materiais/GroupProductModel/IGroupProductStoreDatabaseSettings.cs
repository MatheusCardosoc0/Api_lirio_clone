namespace Api.Models.Materiais.GroupProductModel
{
    public interface IGroupProductStoreDatabaseSettings
    {
        string GroupProductCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
