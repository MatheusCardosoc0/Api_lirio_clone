namespace Api.Utilities
{
    public interface ISystemDBConfiguration
    {
        CollectionGroups Collections { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
