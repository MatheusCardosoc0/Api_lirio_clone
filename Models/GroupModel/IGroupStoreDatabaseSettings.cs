namespace Api.Models.GroupModel
{
    public interface IGroupStoreDatbaseSettings
    {
        string GroupCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
