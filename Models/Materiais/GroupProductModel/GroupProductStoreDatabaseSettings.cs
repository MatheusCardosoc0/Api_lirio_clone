namespace Api.Models.Materiais.GroupProductModel
{
    public class GroupProductStoreDatabaseSettings : IGroupProductStoreDatabaseSettings
    {
        public string GroupProductCollectionName { get; set; } = string.Empty;
        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
    }
}
