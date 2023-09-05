namespace Api.Models.GroupModel
{
    public class GroupStoreDatbaseSettings : IGroupStoreDatbaseSettings
    {
        public string GroupCollectionName { get; set; } = string.Empty;
        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
    }
}
