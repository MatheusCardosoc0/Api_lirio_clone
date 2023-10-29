namespace Api.Utilities
{
    public class SystemDBConfiguration : ISystemDBConfiguration
    {
        public CollectionGroups Collections { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
